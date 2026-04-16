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

        // 파일 복사 핵심 로직
        private void CopyFile(string sourceDir, string targetDir, ListView sourceLv)
        {
            if (sourceLv.SelectedItems.Count == 0) return;

            string fileName = sourceLv.SelectedItems[0].Text;
            if (string.IsNullOrEmpty(fileName)) return;

            string sourcePath = Path.Combine(sourceDir, fileName);
            string targetPath = Path.Combine(targetDir, fileName);

            if (File.Exists(targetPath))
            {
                DateTime srcTime = File.GetLastWriteTime(sourcePath);
                DateTime destTime = File.GetLastWriteTime(targetPath);

                string msg = $"대상에 동일한 이름의 파일이 이미 있습니다.\n" +
                             $"대상 파일이 더 {(srcTime > destTime ? "오래된" : "신규")} 파일입니다. 덮어쓰시겠습니까?\n\n" +
                             $"원본: {srcTime:yyyy-MM-dd tt h:mm}\n" +
                             $"대상: {destTime:yyyy-MM-dd tt h:mm}";

                if (MessageBox.Show(msg, "덮어쓰기 확인", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;
            }

            try
            {
                File.Copy(sourcePath, targetPath, true);
                CompareAndDisplay();
            }
            catch (Exception ex)
            {
                MessageBox.Show("복사 중 오류 발생: " + ex.Message);
            }
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
        private void btnCopyFromLeft_Click_1(object sender, EventArgs e)
        {
            CopyFile(txtLeftDir.Text, txtRightDir.Text, lvwLeftDir);
        }

        private void btnCopyFromRight_Click_1(object sender, EventArgs e)
        {
            CopyFile(txtRightDir.Text, txtLeftDir.Text, lvwrightDir);
        }
    }
}