namespace FileCompareTool
{
    partial class Form1
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
            splitContainer1 = new SplitContainer();
            panel2 = new Panel();
            btnLeftDir = new Button();
            txtLeftDir = new TextBox();
            panel3 = new Panel();
            lvwLeftDir = new ListView();
            name = new ColumnHeader();
            size = new ColumnHeader();
            change = new ColumnHeader();
            panel1 = new Panel();
            btnCopyFromLeft = new Button();
            lblAppName = new Label();
            panel5 = new Panel();
            btnRightDir = new Button();
            txtRightDir = new TextBox();
            panel6 = new Panel();
            lvwrightDir = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            columnHeader3 = new ColumnHeader();
            panel4 = new Panel();
            btnCopyFromRight = new Button();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            panel1.SuspendLayout();
            panel5.SuspendLayout();
            panel6.SuspendLayout();
            panel4.SuspendLayout();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(panel2);
            splitContainer1.Panel1.Controls.Add(panel3);
            splitContainer1.Panel1.Controls.Add(panel1);
            splitContainer1.Panel1.Padding = new Padding(50, 50, 30, 30);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(panel5);
            splitContainer1.Panel2.Controls.Add(panel6);
            splitContainer1.Panel2.Controls.Add(panel4);
            splitContainer1.Panel2.Padding = new Padding(50, 50, 0, 0);
            splitContainer1.Panel2.Tag = "bin parex`";
            splitContainer1.Size = new Size(1194, 815);
            splitContainer1.SplitterDistance = 591;
            splitContainer1.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel2.Controls.Add(btnLeftDir);
            panel2.Controls.Add(txtLeftDir);
            panel2.Location = new Point(27, 100);
            panel2.Name = "panel2";
            panel2.Size = new Size(531, 60);
            panel2.TabIndex = 2;
            // 
            // btnLeftDir
            // 
            btnLeftDir.Anchor = AnchorStyles.Right;
            btnLeftDir.Location = new Point(417, 17);
            btnLeftDir.Name = "btnLeftDir";
            btnLeftDir.Size = new Size(94, 29);
            btnLeftDir.TabIndex = 2;
            btnLeftDir.Text = "폴더선택";
            btnLeftDir.UseVisualStyleBackColor = true;
            btnLeftDir.Click += btnLeftDir_Click;
            // 
            // txtLeftDir
            // 
            txtLeftDir.Anchor = AnchorStyles.Right;
            txtLeftDir.Location = new Point(98, 17);
            txtLeftDir.Name = "txtLeftDir";
            txtLeftDir.Size = new Size(287, 27);
            txtLeftDir.TabIndex = 0;
            // 
            // panel3
            // 
            panel3.Controls.Add(lvwLeftDir);
            panel3.Location = new Point(27, 176);
            panel3.Name = "panel3";
            panel3.Size = new Size(557, 555);
            panel3.TabIndex = 2;
            // 
            // lvwLeftDir
            // 
            lvwLeftDir.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            lvwLeftDir.Columns.AddRange(new ColumnHeader[] { name, size, change });
            lvwLeftDir.FullRowSelect = true;
            lvwLeftDir.GridLines = true;
            lvwLeftDir.Location = new Point(3, 3);
            lvwLeftDir.Name = "lvwLeftDir";
            lvwLeftDir.Size = new Size(508, 538);
            lvwLeftDir.TabIndex = 0;
            lvwLeftDir.UseCompatibleStateImageBehavior = false;
            lvwLeftDir.View = View.Details;
            // 
            // name
            // 
            name.Text = "이름";
            name.Width = 250;
            // 
            // size
            // 
            size.Text = "크기";
            size.Width = 100;
            // 
            // change
            // 
            change.Text = "수정일";
            change.Width = 160;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel1.Controls.Add(btnCopyFromLeft);
            panel1.Controls.Add(lblAppName);
            panel1.Location = new Point(43, 34);
            panel1.Name = "panel1";
            panel1.Size = new Size(515, 60);
            panel1.TabIndex = 1;
            // 
            // btnCopyFromLeft
            // 
            btnCopyFromLeft.Anchor = AnchorStyles.Right;
            btnCopyFromLeft.Location = new Point(401, 17);
            btnCopyFromLeft.Name = "btnCopyFromLeft";
            btnCopyFromLeft.Size = new Size(94, 29);
            btnCopyFromLeft.TabIndex = 1;
            btnCopyFromLeft.Text = ">>>";
            btnCopyFromLeft.UseVisualStyleBackColor = true;
            // 
            // lblAppName
            // 
            lblAppName.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblAppName.AutoSize = true;
            lblAppName.Font = new Font("맑은 고딕", 20F);
            lblAppName.Location = new Point(0, 0);
            lblAppName.Name = "lblAppName";
            lblAppName.Size = new Size(223, 46);
            lblAppName.TabIndex = 0;
            lblAppName.Text = "File Compare";
            // 
            // panel5
            // 
            panel5.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel5.Controls.Add(btnRightDir);
            panel5.Controls.Add(txtRightDir);
            panel5.Location = new Point(16, 100);
            panel5.Name = "panel5";
            panel5.Size = new Size(560, 60);
            panel5.TabIndex = 2;
            // 
            // btnRightDir
            // 
            btnRightDir.Anchor = AnchorStyles.Left;
            btnRightDir.Location = new Point(445, 15);
            btnRightDir.Name = "btnRightDir";
            btnRightDir.Size = new Size(94, 29);
            btnRightDir.TabIndex = 3;
            btnRightDir.Text = "폴더선택";
            btnRightDir.UseVisualStyleBackColor = true;
            btnRightDir.Click += btnRightDir_Click;
            // 
            // txtRightDir
            // 
            txtRightDir.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtRightDir.Location = new Point(18, 17);
            txtRightDir.Name = "txtRightDir";
            txtRightDir.Size = new Size(409, 27);
            txtRightDir.TabIndex = 1;
            // 
            // panel6
            // 
            panel6.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel6.Controls.Add(lvwrightDir);
            panel6.Location = new Point(16, 176);
            panel6.Name = "panel6";
            panel6.Size = new Size(560, 617);
            panel6.TabIndex = 2;
            // 
            // lvwrightDir
            // 
            lvwrightDir.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lvwrightDir.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2, columnHeader3 });
            lvwrightDir.FullRowSelect = true;
            lvwrightDir.GridLines = true;
            lvwrightDir.Location = new Point(18, 3);
            lvwrightDir.Name = "lvwrightDir";
            lvwrightDir.Size = new Size(521, 552);
            lvwrightDir.TabIndex = 1;
            lvwrightDir.UseCompatibleStateImageBehavior = false;
            lvwrightDir.View = View.Details;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "이름";
            columnHeader1.Width = 250;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "크기";
            columnHeader2.Width = 100;
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "수정일";
            columnHeader3.Width = 160;
            // 
            // panel4
            // 
            panel4.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel4.Controls.Add(btnCopyFromRight);
            panel4.Location = new Point(16, 34);
            panel4.Name = "panel4";
            panel4.Size = new Size(560, 60);
            panel4.TabIndex = 2;
            // 
            // btnCopyFromRight
            // 
            btnCopyFromRight.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            btnCopyFromRight.Location = new Point(18, 17);
            btnCopyFromRight.Name = "btnCopyFromRight";
            btnCopyFromRight.Size = new Size(113, 29);
            btnCopyFromRight.TabIndex = 2;
            btnCopyFromRight.Text = "<<<";
            btnCopyFromRight.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1194, 815);
            Controls.Add(splitContainer1);
            Name = "Form1";
            Text = "File Compare v1.0";
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            panel6.ResumeLayout(false);
            panel4.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private Panel panel2;
        private Panel panel3;
        private Panel panel1;
        private Panel panel5;
        private Panel panel6;
        private Panel panel4;
        private Button btnCopyFromLeft;
        private Label lblAppName;
        private Button btnCopyFromRight;
        private Button btnLeftDir;
        private TextBox txtLeftDir;
        private Button btnRightDir;
        private TextBox txtRightDir;
        private ListView lvwLeftDir;
        private ListView lvwrightDir;
        private ColumnHeader name;
        private ColumnHeader size;
        private ColumnHeader change;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
    }
}
