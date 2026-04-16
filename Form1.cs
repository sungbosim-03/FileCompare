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

        // 1. 비교 및 화면 출력 로직
        private void CompareAndDisplay()
        {
            string leftPath = txtLeftDir.Text;
            string rightPath = txtRightDir.Text;

            if (!Directory.Exists(leftPath) || !Directory.Exists(rightPath)) return;

            lvwLeftDir.Items.Clear();
            lvwrightDir.Items.Clear();

            DirectoryInfo leftInfo = new DirectoryInfo(leftPath);
            DirectoryInfo rightInfo = new DirectoryInfo(rightPath);

            // 파일과 폴더를 모두 가져옴
            FileSystemInfo[] leftItems = leftInfo.GetFileSystemInfos();
            FileSystemInfo[] rightItems = rightInfo.GetFileSystemInfos();

            var allNames = leftItems.Select(i => i.Name)
                                    .Union(rightItems.Select(i => i.Name))
                                    .OrderBy(n => n).ToList();

            lvwLeftDir.BeginUpdate();
            lvwrightDir.BeginUpdate();

            foreach (string name in allNames)
            {
                var left = leftItems.FirstOrDefault(i => i.Name == name);
                var right = rightItems.FirstOrDefault(i => i.Name == name);

                Color leftColor = Color.Black;
                Color rightColor = Color.Black;

                if (left != null && right != null)
                {
                    // 초 단위까지 문자열로 변환하여 미세한 시간 차이 무시
                    if (left.LastWriteTime.ToString("yyyy-MM-dd HH:mm:ss") != right.LastWriteTime.ToString("yyyy-MM-dd HH:mm:ss"))
                    {
                        if (left.LastWriteTime > right.LastWriteTime)
                        {
                            leftColor = Color.Red; // 최신 파일 빨강
                            rightColor = Color.Gray; // 예전 파일 회색
                        }
                        else
                        {
                            leftColor = Color.Gray;
                            rightColor = Color.Red;
                        }
                    }
                }
                else if (left != null && right == null)
                {
                    leftColor = Color.Purple; // 한쪽에만 있으면 보라색
                    rightColor = Color.Gray;
                }
                else if (left == null && right != null)
                {
                    leftColor = Color.Gray;
                    rightColor = Color.Purple;
                }

                AddItemToList(lvwLeftDir, left, leftColor);
                AddItemToList(lvwrightDir, right, rightColor);
            }

            lvwLeftDir.EndUpdate();
            lvwrightDir.EndUpdate();
        }

        // 2. 리스트뷰에 아이템 추가 (폴더/파일 구분 표시)
        private void AddItemToList(ListView lv, FileSystemInfo info, Color color)
        {
            if (info == null)
            {
                ListViewItem empty = new ListViewItem("");
                empty.SubItems.Add("");
                empty.SubItems.Add("");
                empty.ForeColor = color;
                lv.Items.Add(empty);
                return;
            }

            ListViewItem item = new ListViewItem(info.Name);
            if (info is DirectoryInfo)
            {
                item.SubItems.Add("<DIR>"); // 폴더 표시
            }
            else
            {
                item.SubItems.Add($"{(((FileInfo)info).Length / 1024.0):N0} KB");
            }

            item.SubItems.Add(info.LastWriteTime.ToString("yyyy-MM-dd tt h:mm"));
            item.ForeColor = color;
            item.UseItemStyleForSubItems = true;
            lv.Items.Add(item);
        }

        // 3. 재귀적 복사 로직 (하위 폴더 포함)
        private void CopyRecursive(string source, string target)
        {
            if (Directory.Exists(source))
            {
                Directory.CreateDirectory(target);
                foreach (string file in Directory.GetFiles(source))
                {
                    File.Copy(file, Path.Combine(target, Path.GetFileName(file)), true);
                }
                foreach (string dir in Directory.GetDirectories(source))
                {
                    CopyRecursive(dir, Path.Combine(target, Path.GetFileName(dir)));
                }
            }
            else
            {
                File.Copy(source, target, true);
            }
        }

        // 4. 복사 실행 및 덮어쓰기 확인 창
        private void ExecuteCopy(string srcDir, string tgtDir, ListView lv)
        {
            if (lv.SelectedItems.Count == 0) return;
            string name = lv.SelectedItems[0].Text;
            if (string.IsNullOrEmpty(name)) return;

            string srcPath = Path.Combine(srcDir, name);
            string tgtPath = Path.Combine(tgtDir, name);

            if (File.Exists(tgtPath) || Directory.Exists(tgtPath))
            {
                DateTime srcT = (File.Exists(srcPath) || Directory.Exists(srcPath)) ? Directory.GetLastWriteTime(srcPath) : DateTime.MinValue;
                DateTime tgtT = (File.Exists(tgtPath) || Directory.Exists(tgtPath)) ? Directory.GetLastWriteTime(tgtPath) : DateTime.MinValue;

                string msg = $"대상이 이미 존재합니다. 덮어쓰시겠습니까?\n\n원본: {srcT}\n대상: {tgtT}";
                if (MessageBox.Show(msg, "덮어쓰기 확인", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;
            }

            try
            {
                CopyRecursive(srcPath, tgtPath);
                CompareAndDisplay(); // 복사 후 리스트 갱신
            }
            catch (Exception ex)
            {
                MessageBox.Show("오류 발생: " + ex.Message);
            }
        }

        // 5. 버튼 이벤트 핸들러
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
            ExecuteCopy(txtLeftDir.Text, txtRightDir.Text, lvwLeftDir);

        }

        private void btnCopyFromRight_Click_1(object sender, EventArgs e)
        {
            ExecuteCopy(txtRightDir.Text, txtLeftDir.Text, lvwrightDir);
        }
    }
}