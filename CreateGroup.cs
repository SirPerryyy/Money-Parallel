using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Money_Parallel
{
    public partial class CreateGroup : UserControl
    {
        int people = 2;
        public string[]? peopleInGroupS;
        string dir = AppDomain.CurrentDomain.BaseDirectory;
        public CreateGroup()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (people < 21) { people++; }
            peopleCount.Text = people.ToString();
            confirmiPCount.Text = $"Confirm {peopleCount.Text}";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (people > 2) { people--; }
            peopleCount.Text = people.ToString();
            confirmiPCount.Text = $"Confirm {peopleCount.Text}";
        }
        int currentIndex = 0;
        private void nextPerson_Click(object sender, EventArgs e)
        {
            if (newPersonName.Text.Trim() == "")
            {
                MessageBox.Show("Name cant be null!");
                return;
            }

            if (currentIndex >= people)
            {
                nextPerson.Enabled = false;
                button3.Enabled = true;
                return;
            }
            if (peopleInGroupS != null)
            {
                peopleInGroupS[currentIndex] = newPersonName.Text;
            }
            newPersonName.Clear();
            currentIndex++;

            if (currentIndex >= people)
            {
                nextPerson.Enabled = false;
                button3.Enabled = true;
            }

        }
        private void confirmiPCount_Click(object sender, EventArgs e)
        {
            peopleInGroupS = new string[people];
            nextPerson.Enabled = true;
            button1.Enabled = false;
            button2.Enabled = false;
            confirmiPCount.Enabled = false;
            creationLabel.Visible = false;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            int nextId = 0;

            string path = Path.Combine(dir, "Saves", "groups.json");

            List<GroupClass> groups = new List<GroupClass>();

            if (File.Exists(path))
            {
                string existingJson = File.ReadAllText(path);
                if (!string.IsNullOrWhiteSpace(existingJson))
                {
                    groups = JsonConvert.DeserializeObject<List<GroupClass>>(existingJson) ?? new List<GroupClass>();
                    if (groups.Count > 0) { nextId = groups.Last().Id + 1; }
                }
            }
            else
            {
                Form1 f = new Form1();
                f.LogWriter(new FileNotFoundException(), "Groups save file does not exist!");
            }
                GroupClass newGroup = new GroupClass
                {
                    Id = nextId,
                    Name = groupNameTextbox.Text,
                    People = people,
                    PeopleNames = peopleInGroupS
                };

            groups.Add(newGroup);

            string json = JsonConvert.SerializeObject(groups, Formatting.Indented);
            File.WriteAllText(path, json);

            creationLabel.Visible = true;
        }

    }
}
