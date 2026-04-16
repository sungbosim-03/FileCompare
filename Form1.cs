using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace FileCompareTool
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void CompareAndDisplay()
        {
            string leftPath = txtLeftDir.Text;
            string rightPath = txtRightDir.Text;

            if (!Directory.Exists(leftPath) || !Directory.Exists(rightPath)) return;

            lvwLeftDir.Items.Clear();
            lvwrightDir.Items.Clear();

            DirectoryInfo leftDir = new DirectoryInfo(leftPath);
            DirectoryInfo rightDir = new DirectoryInfo(rightPath);

            FileInfo[] leftFiles = leftDir.GetFiles();
            FileInfo[] rightFiles = rightDir.GetFiles();

            var allFileNames = leftFiles.Select(f => f.Name)
                                        .Union(rightFiles.Select(f => f.Name))
                                        .OrderBy(n => n)
                                        .ToList();

            lvwLeftDir.BeginUpdate();
            lvwrightDir.BeginUpdate();

            foreach (string fileName in allFileNames)
            {
                var leftFile = leftFiles.FirstOrDefault(f => f.Name == fileName);
                var rightFile = rightFiles.FirstOrDefault(f => f.Name == fileName);

                Color leftColor = Color.Black;
                Color rightColor = Color.Black;

                if (leftFile != null && rightFile != null)
                {
                    string leftTime = leftFile.LastWriteTime.ToString("yyyy-MM-dd HH:mm:ss");
                    string rightTime = rightFile.LastWriteTime.ToString("yyyy-MM-dd HH:mm:ss");

                    long leftSize = leftFile.Length / 1024;
                    long rightSize = rightFile.Length / 1024;

                    bool isSame = (leftSize == rightSize && leftTime == rightTime);

                    if (!isSame)
                    {
                        if (leftFile.LastWriteTime > rightFile.LastWriteTime)
                        {
                            leftColor = Color.Red;
                            rightColor = Color.Gray;
                        }
                        else
                        {
                            leftColor = Color.Gray;
                            rightColor = Color.Red;
                        }
                    }
                    else
                    {
                        leftColor = Color.Black;
                        rightColor = Color.Black;
                    }
                }
                else if (leftFile != null && rightFile == null)
                {
                    leftColor = Color.Purple;
                    rightColor = Color.Gray;
                }
                else if (leftFile == null && rightFile != null)
                {
                    leftColor = Color.Gray;
                    rightColor = Color.Purple;
                }

                AddFileToListView(lvwLeftDir, leftFile, leftColor);
                AddFileToListView(lvwrightDir, rightFile, rightColor);
            }

            lvwLeftDir.EndUpdate();
            lvwrightDir.EndUpdate();
        }

        private void AddFileToListView(ListView lv, FileInfo file, Color itemColor)
        {
            if (file == null)
            {
                ListViewItem emptyItem = new ListViewItem("");
                emptyItem.SubItems.Add("");
                emptyItem.SubItems.Add("");
                emptyItem.ForeColor = itemColor;
                lv.Items.Add(emptyItem);
                return;
            }

            ListViewItem item = new ListViewItem(file.Name);
            item.SubItems.Add($"{(file.Length / 1024.0):N0} KB");
            item.SubItems.Add(file.LastWriteTime.ToString("yyyy-MM-dd tt h:mm"));

            item.ForeColor = itemColor;
            item.UseItemStyleForSubItems = true;
            lv.Items.Add(item);
        }

        private void btnLeftDir_Click_1(object sender, EventArgs e)
        {
            using (var dlg = new FolderBrowserDialog())
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    txtLeftDir.Text = dlg.SelectedPath;
                    CompareAndDisplay();
                }
            }
        }

        private void btnRightDir_Click_1(object sender, EventArgs e)
        {
            using (var dlg = new FolderBrowserDialog())
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    txtRightDir.Text = dlg.SelectedPath;
                    CompareAndDisplay();
                }
            }
        }
    }
}