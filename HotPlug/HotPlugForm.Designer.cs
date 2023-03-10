namespace HotPlug
{
    partial class HotPlugForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            RunPlug = new Button();
            dataGridView1 = new DataGridView();
            button2 = new Button();
            button3 = new Button();
            openFileDialog1 = new OpenFileDialog();
            button1 = new Button();
            Id = new DataGridViewTextBoxColumn();
            Name = new DataGridViewTextBoxColumn();
            Version = new DataGridViewTextBoxColumn();
            Status = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // RunPlug
            // 
            RunPlug.Location = new Point(95, 198);
            RunPlug.Name = "RunPlug";
            RunPlug.Size = new Size(77, 33);
            RunPlug.TabIndex = 0;
            RunPlug.Text = "执行";
            RunPlug.UseVisualStyleBackColor = true;
            RunPlug.Click += button1_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Id, Name, Version, Status });
            dataGridView1.Location = new Point(3, 16);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(344, 165);
            dataGridView1.TabIndex = 1;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // button2
            // 
            button2.Location = new Point(185, 198);
            button2.Name = "button2";
            button2.Size = new Size(69, 33);
            button2.TabIndex = 2;
            button2.Text = "卸载";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(8, 198);
            button3.Name = "button3";
            button3.Size = new Size(71, 33);
            button3.TabIndex = 3;
            button3.Text = "加载";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // button1
            // 
            button1.Location = new Point(271, 198);
            button1.Name = "button1";
            button1.Size = new Size(73, 33);
            button1.TabIndex = 4;
            button1.Text = "\u007f移除";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click_1;
            // 
            // Id
            // 
            Id.DataPropertyName = "Id";
            Id.HeaderText = "Id";
            Id.Name = "Id";
            // 
            // Name
            // 
            Name.DataPropertyName = "Name";
            Name.HeaderText = "插件";
            Name.Name = "Name";
            // 
            // Version
            // 
            Version.DataPropertyName = "Version";
            Version.HeaderText = "版本";
            Version.Name = "Version";
            // 
            // Status
            // 
            Status.DataPropertyName = "Status";
            Status.HeaderText = "状态";
            Status.Name = "Status";
            // 
            // HotPlugForm
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(349, 257);
            Controls.Add(button1);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(dataGridView1);
            Controls.Add(RunPlug);
            Name = new DataGridViewTextBoxColumn();
            StartPosition = FormStartPosition.CenterScreen;
            Text = "热插拔";
            Load += HotPlugForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button RunPlug;
        private DataGridView dataGridView1;
        private Button button2;
        private Button button3;
        private OpenFileDialog openFileDialog1;
        private Button button1;
        private DataGridViewTextBoxColumn Id;
        private DataGridViewTextBoxColumn Name;
        private DataGridViewTextBoxColumn Version;
        private DataGridViewTextBoxColumn Status;
    }
}