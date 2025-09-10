namespace Money_Parallel
{
    partial class CreateGroup
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            newGroup = new Label();
            label1 = new Label();
            label2 = new Label();
            groupNameTextbox = new TextBox();
            button1 = new Button();
            button2 = new Button();
            peopleCount = new Label();
            newPersonName = new TextBox();
            button3 = new Button();
            nextPerson = new Button();
            label3 = new Label();
            confirmiPCount = new Button();
            creationLabel = new Label();
            SuspendLayout();
            // 
            // newGroup
            // 
            newGroup.AutoSize = true;
            newGroup.Font = new Font("Courier New", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            newGroup.ForeColor = Color.ForestGreen;
            newGroup.Location = new Point(51, 10);
            newGroup.Name = "newGroup";
            newGroup.Size = new Size(138, 27);
            newGroup.TabIndex = 0;
            newGroup.Text = "New Group";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Courier New", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(15, 48);
            label1.Name = "label1";
            label1.Size = new Size(77, 16);
            label1.TabIndex = 1;
            label1.Text = "Group Name";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Courier New", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(15, 120);
            label2.Name = "label2";
            label2.Size = new Size(49, 16);
            label2.TabIndex = 2;
            label2.Text = "People";
            // 
            // groupNameTextbox
            // 
            groupNameTextbox.BorderStyle = BorderStyle.FixedSingle;
            groupNameTextbox.Location = new Point(15, 75);
            groupNameTextbox.Name = "groupNameTextbox";
            groupNameTextbox.Size = new Size(207, 23);
            groupNameTextbox.TabIndex = 3;
            // 
            // button1
            // 
            button1.Location = new Point(110, 117);
            button1.Name = "button1";
            button1.Size = new Size(21, 22);
            button1.TabIndex = 4;
            button1.Text = "+";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(64, 117);
            button2.Name = "button2";
            button2.Size = new Size(21, 22);
            button2.TabIndex = 5;
            button2.Text = "-";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // peopleCount
            // 
            peopleCount.AutoSize = true;
            peopleCount.Location = new Point(91, 121);
            peopleCount.Name = "peopleCount";
            peopleCount.Size = new Size(13, 15);
            peopleCount.TabIndex = 6;
            peopleCount.Text = "2";
            // 
            // newPersonName
            // 
            newPersonName.BorderStyle = BorderStyle.FixedSingle;
            newPersonName.Location = new Point(15, 142);
            newPersonName.MaxLength = 32;
            newPersonName.Name = "newPersonName";
            newPersonName.ShortcutsEnabled = false;
            newPersonName.Size = new Size(207, 23);
            newPersonName.TabIndex = 0;
            // 
            // button3
            // 
            button3.Enabled = false;
            button3.Font = new Font("Courier New", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button3.ForeColor = Color.ForestGreen;
            button3.Location = new Point(37, 311);
            button3.Name = "button3";
            button3.Size = new Size(164, 28);
            button3.TabIndex = 7;
            button3.Text = "Create";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // nextPerson
            // 
            nextPerson.AutoSize = true;
            nextPerson.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            nextPerson.Enabled = false;
            nextPerson.Font = new Font("Courier New", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            nextPerson.ImageAlign = ContentAlignment.MiddleLeft;
            nextPerson.Location = new Point(127, 180);
            nextPerson.Name = "nextPerson";
            nextPerson.Size = new Size(94, 24);
            nextPerson.TabIndex = 8;
            nextPerson.Text = "Next Person";
            nextPerson.TextAlign = ContentAlignment.MiddleLeft;
            nextPerson.UseVisualStyleBackColor = true;
            nextPerson.Click += nextPerson_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Cascadia Mono", 8F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label3.ForeColor = SystemColors.ControlDark;
            label3.Location = new Point(3, 168);
            label3.Name = "label3";
            label3.Size = new Size(139, 45);
            label3.TabIndex = 9;
            label3.Text = "Click \"Next Person\" \r\nwhen you're done \r\nwriting person's name.";
            // 
            // confirmiPCount
            // 
            confirmiPCount.AutoSize = true;
            confirmiPCount.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            confirmiPCount.Font = new Font("Courier New", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            confirmiPCount.Location = new Point(137, 117);
            confirmiPCount.Name = "confirmiPCount";
            confirmiPCount.Size = new Size(80, 24);
            confirmiPCount.TabIndex = 10;
            confirmiPCount.Text = "Confirm 2";
            confirmiPCount.TextAlign = ContentAlignment.MiddleLeft;
            confirmiPCount.UseVisualStyleBackColor = true;
            confirmiPCount.Click += confirmiPCount_Click;
            // 
            // creationLabel
            // 
            creationLabel.AutoSize = true;
            creationLabel.Font = new Font("Courier New", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            creationLabel.ForeColor = Color.LimeGreen;
            creationLabel.Location = new Point(9, 225);
            creationLabel.Name = "creationLabel";
            creationLabel.Size = new Size(231, 64);
            creationLabel.TabIndex = 11;
            creationLabel.Text = "Grop succesfully cretaed.\r\nClose this dialog and press \r\nthe refresh button on \r\nthe left.";
            creationLabel.Visible = false;
            // 
            // CreateGroup
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(creationLabel);
            Controls.Add(confirmiPCount);
            Controls.Add(nextPerson);
            Controls.Add(label3);
            Controls.Add(button3);
            Controls.Add(newPersonName);
            Controls.Add(peopleCount);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(groupNameTextbox);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(newGroup);
            Name = "CreateGroup";
            Size = new Size(240, 342);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label newGroup;
        private Label label1;
        private Label label2;
        private TextBox groupNameTextbox;
        private Button button1;
        private Button button2;
        private Label peopleCount;
        private TextBox newPersonName;
        private Button button3;
        private Button nextPerson;
        private Label label3;
        private Button confirmiPCount;
        private Label creationLabel;
    }
}
