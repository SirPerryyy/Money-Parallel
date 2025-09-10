using Microsoft.VisualBasic;
using Microsoft.VisualBasic.ApplicationServices;
using Money_Parallel.Properties;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Reflection;
using System.Reflection.Metadata;
using System.Security.Policy;
using System.Text.RegularExpressions;
using System.Timers;
using System.Transactions;
using System.Windows.Forms;

namespace Money_Parallel
{
    public partial class Form1 : Form
    {
        int currentGroupIndex = 0;
        string dir = AppDomain.CurrentDomain.BaseDirectory;
        public Form1()
        {
            InitializeComponent();
            //sets up lists
            InizializeGroup();
            //visual tweaks
            GroupNameAling();
            //transations table Inizializer
            TransationsDatatableInizializer();
        }

        //| SHUOLD BE EXECUTED ONLY ONCE
        private void TransationsDatatableInizializer()
        {
            dataGridTransations.Columns.Add(new DataGridViewTextBoxColumn());
            dataGridTransations.Columns.Add(new DataGridViewTextBoxColumn());
            dataGridTransations.Columns.Add(new DataGridViewTextBoxColumn());
            dataGridTransations.Columns.Add(new DataGridViewTextBoxColumn());
            dataGridTransations.Columns.Add(new DataGridViewTextBoxColumn());
            dataGridTransations.Columns.Add(new DataGridViewTextBoxColumn());
            DataGridViewColumn column1 = dataGridTransations.Columns[0];
            column1.Width = 150;
            column1.HeaderText = "Transation Name";
            DataGridViewColumn column2 = dataGridTransations.Columns[1];
            column2.Width = 50;
            column2.HeaderText = "Tot. Ammount";
            DataGridViewColumn column3 = dataGridTransations.Columns[2];
            column3.Width = 50;
            column3.HeaderText = "Tot./Person";
            DataGridViewColumn column4 = dataGridTransations.Columns[3];
            column4.Width = 70;
            column4.HeaderText = "Paytor";
            DataGridViewColumn column5 = dataGridTransations.Columns[5];
            column5.Width = 45;
            column5.HeaderText = "Draw";
            DataGridViewColumn column6 = dataGridTransations.Columns[4];
            column6.Width = 100;
            column6.HeaderText = "Date";
            column6.SortMode = DataGridViewColumnSortMode.Automatic;
            DataGridViewImageColumn column7 = new DataGridViewImageColumn();
            Image img = Image.FromFile(Path.Combine(dir, "Resources", "GUI", "bin.png"));
            column7.Width = 49;
            column7.Image = img;
            column7.ImageLayout = DataGridViewImageCellLayout.Zoom;
            column7.HeaderText = "Delete";
            dataGridTransations.Columns.Insert(6, column7);
            dataGridTransations.Sort(column6, ListSortDirection.Descending);

        }
        // |
        private List<GroupClass> GroupClassMet()
        {
            string path = Path.Combine(dir, "Saves", "groups.json");
            List<GroupClass> groups = new List<GroupClass>();

            string existingJson = File.ReadAllText(path);

            return groups = JsonConvert.DeserializeObject<List<GroupClass>>(existingJson) ?? new List<GroupClass>();
        }

        public void LogWriter(Exception exception, string message)
        {
            string path = Path.Combine(dir, "logs", "logs.txt");

            DateTime time = DateTime.Now;

            string[] finalMessage = { $"[{time.Date}|{time.TimeOfDay}]|ERROR|", $"{exception.Message}|StackTrace:{exception.StackTrace}||", $"{message}" };

            File.AppendAllLines(path, finalMessage);
        }

        public void InizializeGroup()
        {
            List<GroupClass> groups = GroupClassMet();

            InizializeGroupsList(groups);

            try
            {
                GroupClass currentGroup = groups[currentGroupIndex];
                TableRowsUpdater(GetTransationsList(currentGroup));

            }
            catch (Exception ex)
            {
                string message = "Nothing found at this index";
                LogWriter(ex, message);
            }
        }
        private void InizializeGroupName(GroupClass group)
        {
            groupName.Text = group != null ? group.Name ?? "{Group Name}" : "{Group Name}";
        }
        private void InizializeGroupsList(List<GroupClass> groups)
        {
            for (int i = 0; i < groups.Count; i++)
            {
                if (groups[i].Name != null)
                {
#pragma warning disable CS8604 // Possible null reference argument.
                    groupsList.Items.Add(groups[i].Name);
#pragma warning restore CS8604 // Possible null reference argument.
                }
            }

        }
        private void InizializeGroupMembers(GroupClass group)
        {
            int people = 0;
            if (group != null && group.PeopleNames != null)
            {
                foreach (string person in group.PeopleNames)
                {
                    groupMembers.Items.Add(person);
                    comboBox1.Items.Add(person);
                    people++;
                }
                label5.Text = $"People ({people})";
            }
        }

        private void GroupNameAling()
        {
            groupName.Location = new System.Drawing.Point((mainPanel.Width - groupName.Width) / 2);
        }

        private void TableRowsUpdater(List<Transations> transationsLst)
        {
            dataGridTransations.Rows.Clear();
            string t = "Y";
            string f = "N";
            foreach (Transations transation in transationsLst)
            {
                dataGridTransations.Rows.Add(transation.TransitionName, transation.TransitionAmmount, transation.TransitionCostPerPerson, transation.Paytor, transation.TransitionDate, transation.DebtsPayed ? t : f);

            }
        }
        private List<Transations> GetTransationsList(GroupClass group)
        {
            string path = Path.Combine(dir, "Transactions", "TransactionsSave.json");

            string json = File.ReadAllText(path);

            List<Transations> fullList = new List<Transations>();
            fullList = JsonConvert.DeserializeObject<List<Transations>>(json) ?? new List<Transations>();

            List<Transations> newList = new List<Transations>();

            foreach (Transations trans in fullList)
            {
                if (trans.TransactionGroupId == group.Id)
                {
                    newList.Add(trans);
                }
            }
            return newList;
        }


        private string Sum(decimal money, GroupClass g)
        {
            string err = "Error! Create a group first or see log.";

            if (g == null)
            {
                string message = "Null Reference. Parameter group was null or 0.";
                LogWriter(new NullReferenceException(), message);
                return "";
            }

            if (g.People == 0)
            {
                string message = "People in the group was 0. Make sure a group was created and done it correctly!";
                LogWriter(new DivideByZeroException(), message);
                return "";
            }

            try
            {
                int people = g.People;
                decimal price = money / people;
                return price.ToString("0.00") + "€";

            }
            catch (Exception e)
            {
                string message = "An error occurred. See log for more informations.";
                LogWriter(e, message);
                MessageBox.Show(message);
                return err;
            }
        }

        private GroupClass CurrentGroup(List<GroupClass> groups)
        {
            try
            {
                GroupClass currentGroup = groups[currentGroupIndex];
                return currentGroup;
            }
            catch (ArgumentOutOfRangeException e)
            {
                string message = "No groups created! Create one first.";
                LogWriter(e, message);
                MessageBox.Show(message);
#pragma warning disable CS8603 // Possible null reference return.
                return null;
#pragma warning restore CS8603 // Possible null reference return.
            }
            catch (Exception e)
            {
                string message = "An unknown error caused application to crash. Contact owner or open the log for more informations.";
                LogWriter(e, message);
                MessageBox.Show(message);
#pragma warning disable CS8603 // Possible null reference return.
                return null;
#pragma warning restore CS8603 // Possible null reference return.
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bool validMoneyAmm = decimal.TryParse(textBox1.Text, out decimal money);

            GroupClass? currentGroup = CurrentGroup(GroupClassMet());

            if (validMoneyAmm)
            {
                try
                {
                    textBox3.Text = Sum(money, currentGroup);
                }
                catch (Exception ex)
                {
                    LogWriter(ex, "An error occurred");
                    MessageBox.Show($"{ex.Message}|| An error occurred ");
                }
                if (currentGroup != null && comboBox1.SelectedItem != null)
                {
                    DateTime dateTime = DateTime.Now;

                    string tt = textBox3.Text;

                    Transations transation = new Transations
                    {
                        TransactionGroupId = currentGroup.Id,
                        TransitionName = transationNameInsert.Text,
                        TransitionAmmount = money,
                        TransitionCostPerPerson = Convert.ToDecimal(tt.Remove(tt.IndexOf('€'))),
                        TransitionDate = $"{dateTime.ToString("dd/MM/yyyy")}|{dateTime.ToString("HH:mm")}",
                        Paytor = comboBox1.SelectedItem.ToString(),
                        DebtsPayed = false
                    };

                    string path = Path.Combine(dir, "Transactions", "TransactionsSave.json");

                    if (File.Exists(path))
                    {
                        List<Transations> transationsLst = new List<Transations>();
                        transationsLst = JsonConvert.DeserializeObject<List<Transations>>(File.ReadAllText(path)) ?? new List<Transations>();

                        transationsLst.Add(transation);

                        string json = JsonConvert.SerializeObject(transationsLst, Formatting.Indented);

                        File.WriteAllText(path, json);
                    }
                    else
                    {
                        LogWriter(new FileNotFoundException(), "Transations Save File Missing.");
                        MessageBox.Show("Transations save file is missing!");
                    }

                    TableRowsUpdater(GetTransationsList(currentGroup));
                    dataGridTransations.Sort(dataGridTransations.Columns[4], ListSortDirection.Descending);
                }
                else
                {
                    MessageBox.Show("Select the paytor from the combo box!");
                    LogWriter(new Exception(), "No paytor");
                }
            }
            else
            {
                textBox1.Text = "Please enter a valid number!";
                textBox3.Text = "";
            }
        }

        private void groupsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (groupsList.SelectedIndex != -1)
            {
                currentGroupIndex = groupsList.SelectedIndex;
            }
            List<GroupClass> groups = GroupClassMet();

            groupMembers.Items.Clear();
            comboBox1.Items.Clear();
            transationNameInsert.Clear();
            textBox1.Clear();
            textBox3.Clear();
            InizializeGroupName(CurrentGroup(groups));
            InizializeGroupMembers(CurrentGroup(groups));
            TableRowsUpdater(GetTransationsList(CurrentGroup(groups)));
            dataGridTransations.Sort(dataGridTransations.Columns[4], ListSortDirection.Descending);
            GroupNameAling();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            groupsList.Items.Clear();
            Refresh(GroupClassMet());
        }
        private void Refresh(List<GroupClass> groups)
        {

            for (int i = 0; i < groups.Count; i++)
            {
                if (groups[i].Name != null)
                {
#pragma warning disable CS8604 // Possible null reference argument.
                    groupsList.Items.Add(groups[i].Name);
#pragma warning restore CS8604 // Possible null reference argument.
                }
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            List<GroupClass> groups = GroupClassMet();

            if (groups.Count > 0 && currentGroupIndex <= groups.Count)
            {
                if (MessageBox.Show($"Are you sure you want to delete {groups[currentGroupIndex].Name}?", "Delete Group?", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    //Group Remover
                    string gPath = Path.Combine(dir, "Saves", "groups.json");

                    //Transitions Remover
                    string tPath = Path.Combine(dir, "Transactions", "TransactionsSave.json");
                    string tJson = File.ReadAllText(tPath);
                    List<Transations> transations = JsonConvert.DeserializeObject<List<Transations>>(tJson) ?? new List<Transations>();
                    List<Transations> newLst = new List<Transations>();

                    foreach (Transations trans in transations)
                    {
                        if (trans.TransactionGroupId != groups[currentGroupIndex].Id)
                        {
                            newLst.Add(trans);
                        }
                    }
                    string newTJson = JsonConvert.SerializeObject(newLst, Formatting.Indented);

                    groups.Remove(groups[currentGroupIndex]);
                    string gJson = JsonConvert.SerializeObject(groups, Formatting.Indented);

                    //File Rewriter
                    File.WriteAllText(gPath, gJson);
                    File.WriteAllText(tPath, newTJson);

                    //GUI cleaner
                    textBox1.Text = "";
                    textBox3.Text = "";
                    transationNameInsert.Text = "";
                    groupName.Text = "{Group Name}";
                    label5.Text = "People";
                    groupsList.Items.Clear();
                    groupMembers.Items.Clear();
                    dataGridTransations.Rows.Clear();
                    debtsList.Items.Clear();
                    GroupNameAling();

                    Refresh(groups);
                }
            }

        }

        private void creationPanelShow_Click(object sender, EventArgs e)
        {
            Form2 creationPanel = new Form2();
            creationPanel.ShowDialog();
        }

        private void groupMembers_SelectedIndexChanged(object sender, EventArgs e)
        {
            debtsList.Items.Clear();

            List<GroupClass> groups = GroupClassMet();
            if (currentGroupIndex < 0 || currentGroupIndex >= groups.Count)
            {
                LogWriter(new IndexOutOfRangeException(), "currentGroupIndex was out of range!");
                return;
            }

            if (groupMembers.SelectedIndex < 0)
            {
                LogWriter(new IndexOutOfRangeException(), "groupMember selected index was out of range!");
                return;
            }

            string? currentMember = groupMembers.Items[groupMembers.SelectedIndex].ToString();
            List<Transations> transations = GetTransationsList(groups[currentGroupIndex]);
            List<string> debtsLst = new List<string>();
            foreach (Transations trans in transations)
            {
                if (trans.TransactionGroupId == groups[currentGroupIndex].Id && currentMember != trans.Paytor && !trans.DebtsPayed)
                {
                    debtsLst.Add($"{currentMember} owes {trans.Paytor}: {trans.TransitionCostPerPerson}€");
                }
            }
            Dictionary<string, decimal> sums = new Dictionary<string, decimal>();

            for (int i = 0; i < debtsLst.Count; i++)
            {
                string item = debtsLst[i];

                int sepIndex = item.IndexOf(':');

                string phrase = item.Substring(0, sepIndex).Trim();
                string ammount = item.Substring(sepIndex + 1).Trim();

                if (decimal.TryParse(ammount.Replace("€", ""), out decimal value))
                {
                    if (!sums.ContainsKey(phrase))
                        sums[phrase] = 0;
                    sums[phrase] += value;
                }
            }
            debtsList.Items.Clear();
            foreach (var k in sums)
            {
                debtsList.Items.Add($"{k.Key}: {k.Value}€");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string path = Path.Combine(dir, "Transactions", "TransactionsSave.json");
            if (MessageBox.Show("Are you sure you want to reset debts?", "Reset Debts", MessageBoxButtons.YesNoCancel) == DialogResult.Yes && currentGroupIndex > -1)
            {
                List<GroupClass> groups = GroupClassMet();
                List<Transations>? currentJson = JsonConvert.DeserializeObject<List<Transations>>(File.ReadAllText(path));
                if (currentJson != null)
                {
                    List<Transations> newJson = new List<Transations>();
                    foreach (Transations t in currentJson)
                    {
                        if (t.TransactionGroupId == groups[currentGroupIndex].Id)
                        {
                            t.DebtsPayed = true;
                        }
                        newJson.Add(t);
                    }
                    string json = JsonConvert.SerializeObject(newJson, Formatting.Indented);
                    File.WriteAllText(path, json);
                    try
                    {
                        TableRowsUpdater(GetTransationsList(groups[currentGroupIndex]));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Select a group first");
                        LogWriter(ex, "Group not inizialized or created yet, currentGroupIndex might be bigger than the size of the collection");
                    }
                }
                else
                {
                    MessageBox.Show("No transation to reset was found.");
                    LogWriter(new NullReferenceException(), "No transation was found. Unable to reset debts");
                }
            }
            else if (currentGroupIndex < 0)
            {
                MessageBox.Show("Select a group first!");
            }

        }
        private void WriteTransations(List<Transations> newList)
        {
            string path = Path.Combine(dir, "Transactions", "TransactionsSave.json");
            string json = JsonConvert.SerializeObject(newList, Formatting.Indented);
            File.WriteAllText(path, json);
        }
        private void dataGridTransations_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex > -1 && e.ColumnIndex == 6 && MessageBox.Show($"Are you sure you want to permanently delete \"{dataGridTransations.Rows[e.RowIndex].Cells[0].Value.ToString()}\"?", "Delete Transation?", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
            {
                List<Transations> trans = GetTransationsList(CurrentGroup(GroupClassMet()));
                List<Transations> newList = new List<Transations>();
                foreach (Transations t in trans)
                {
                    if (t.TransitionName != dataGridTransations.Rows[e.RowIndex].Cells[0].Value.ToString())
                    {
                        newList.Add(t);
                    }
                    else
                    {
                        MessageBox.Show($"{dataGridTransations.Rows[e.RowIndex].Cells[0].Value.ToString()} has been succesfully deleted");
                    }
                }
                WriteTransations(newList);
            }
            TableRowsUpdater(GetTransationsList(CurrentGroup(GroupClassMet())));
        }

        private void label1_boubleClick(object sender, EventArgs e)
        {
            Label[] labels = { easterEgg1, easterEgg2, easterEgg3, easterEgg4, easterEgg5, easterEgg6, easterEgg7, easterEgg8 };
            Random r = new Random();
            foreach (Label label in labels)
            {
                label.Visible = true;
                label.Enabled = true;
                label.BringToFront();
                int x = r.Next(0, this.Width);
                int y = r.Next(0, this.Height);
                label.Location = new Point(x, y);
                label.BackColor = Color.Transparent;
            }
            Thread.Sleep(1000);

            foreach (Label label in labels)
            {
                label.Enabled = false;
                label.Visible = false;
            }
        }
    }
}
        