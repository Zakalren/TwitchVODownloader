using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TwitchVODownloader
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            ValidateLinks();
            CheckAndCreateDirectory();        

            string resolution = GetResolution();

            if (MessageBox.Show("정말 " + resolution + " 화질의 영상을 다운로드 하시겠습니까?", "알림", MessageBoxButtons.YesNo) == DialogResult.No)
                return;

            StartDownload();                             
        }

        private void btnPath_Click(object sender, EventArgs e)
        {
            using (var dialog = new FolderBrowserDialog())
            {
                DialogResult result = dialog.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(dialog.SelectedPath))
                {
                    txtBoxPath.Text = dialog.SelectedPath;
                }
            }
        }

        private void ValidateLinks()
        {
            if (string.IsNullOrWhiteSpace(txtBoxPath.Text))
            {
                MessageBox.Show("비디오 파일 경로가 입력되어 있는지 확인해주세요.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtBoxLink.Text))
            {
                MessageBox.Show("다시보기 링크가 입력되어 있는지 확인해주세요.");
                return;
            }
        }

        private void CheckAndCreateDirectory()
        {
            string data_folder_path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "TwitchVODownloader");

            if (!Directory.Exists(data_folder_path))
                Directory.CreateDirectory(data_folder_path);
        }

        private string GetResolution()
        {
            string resolution = "";

            if (chkBox160p.Checked)
            {
                resolution = "160p30";
            }

            else if (chkBox360p.Checked)
            {
                resolution = "360p30";
            }

            else if (chkBox480p.Checked)
            {
                resolution = "480p30";
            }

            else if (chkBox720p.Checked)
            {
                resolution = "720p30";
            }

            else if (chkBox720p60.Checked)
            {
                resolution = "720p60";
            }

            else if (chkBox1080p60.Checked)
            {
                resolution = "1080p60";
            }

            return resolution;
        }

        private void StartDownload()
        {
            btnDownload.Enabled = false;

            string resolution = GetResolution().Equals("1080p60") ? "chunked" : GetResolution();

            string data_folder_path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "TwitchVODownloader");
            string video_list_path = Path.Combine(data_folder_path, "video_list");

            DownloadVideoListFile(video_list_path);
            QueueAndDownloadTSFiles(resolution, data_folder_path, video_list_path);
        }

        private void DownloadVideoListFile(string video_list_path)
        {
            using (var client = new WebClient())
            {
                client.DownloadFile(txtBoxLink.Text.Trim(), video_list_path);
            }
        }

        private void QueueAndDownloadTSFiles(string resolution, string data_folder_path, string video_list_path)
        {
            string[] lines = File.ReadAllLines(video_list_path);
            string vodUrl;

            foreach (string line in lines)
            {
                if (line.StartsWith("#"))
                    continue;

                if (!line.Contains("cloudfront.net") && line.Contains("vod-secure.twitch.tv"))
                {
                    DownloadVideoListFile(video_list_path);
                    QueueAndDownloadTSFiles(resolution, data_folder_path, video_list_path);
                    return;
                }

                if (line.Contains(resolution))
                {
                    btnDownload.Text = "다운로드 받는 중...";

                    string sub = line.Substring(0, line.LastIndexOf('/'));
                    vodUrl = line.Substring(0, sub.LastIndexOf('/') + 1) + resolution + '/';

                    string video_info_path = Path.Combine(data_folder_path, "video_info");

                    using (var client = new WebClient())
                    {
                        client.DownloadFile(line.Trim(), video_info_path);
                    }

                    string[] video_info = File.ReadAllLines(video_info_path);
                    string lastFile = video_info[video_info.Length - 2].Replace("-muted", "");
                    int lastFileIndex = int.Parse(lastFile.Substring(0, lastFile.IndexOf('.')).Trim()) + 1;

                    List<Task> tasks = new List<Task>();

                    for (int i = 0; i < lastFileIndex; i++)
                    {
                        using (var client = new WebClient())
                        {
                            tasks.Add(client.DownloadFileTaskAsync(new Uri(vodUrl + i + ".ts"), Path.Combine(txtBoxPath.Text, i + ".ts")));
                        }
                    }

                    DownloadTSFilesAsync(tasks);

                    break;
                }
            }
        }
        

        private async void DownloadTSFilesAsync(IEnumerable<Task> tasks)
        {
            await Task.WhenAll(tasks);
            CompressTSFiles(tasks.Count());           
        }

        private void CompressTSFiles(int lastFileIndex)
        {
            btnDownload.Text = "영상 합치는 중...";

            string video_folder_path = txtBoxPath.Text;
            string tsFilesList = "";

            Process process;

            ProcessStartInfo processStartInfo = new ProcessStartInfo("cmd.exe");
            processStartInfo.UseShellExecute = true;
            processStartInfo.WorkingDirectory = Path.GetFullPath(video_folder_path);

            string argument = "";

            if (lastFileIndex > 300)
            {
                List<string> tmpCompressedList = new List<string>();

                int part = lastFileIndex / 300;

                for (int j = 0; j < part + 1; j++)
                {
                    for (int i = (j * 300); i < (j * 300) + 300; i++)
                    {
                        if (tsFilesList.Equals(""))
                            tsFilesList = i + ".ts";

                        else
                            tsFilesList += "+" + i + ".ts";

                        if (i == lastFileIndex || i == (j * 300) + 299)
                        {
                            argument = "/c copy /b " + tsFilesList + " " + GetColumnName(j) + ".ts";

                            processStartInfo.Arguments = argument;

                            process = Process.Start(processStartInfo);
                            process.WaitForExit();

                            tsFilesList = "";                          

                            tmpCompressedList.Add(GetColumnName(j));

                            if (i == lastFileIndex)
                                break;
                        }                    
                    }                  
                }

                tsFilesList = "";

                foreach (string letter in tmpCompressedList)
                {
                    if (tsFilesList.Equals(""))
                        tsFilesList = "a.ts";

                    else
                        tsFilesList += "+" + letter + ".ts";
                }

                argument = "/c copy /b " + tsFilesList + " combined.ts";

                Debug.WriteLine("argument : " + argument);

                processStartInfo.Arguments = argument;

                process = Process.Start(processStartInfo);
                process.WaitForExit();
            }

            else
            {
                tsFilesList = "0.ts";

                for (int i = 1; i < lastFileIndex; i++)
                {
                    tsFilesList += "+" + i + ".ts";
                }

                argument = "/c copy /b " + tsFilesList + " combined.ts";

                Debug.WriteLine("argument : " + argument);

                processStartInfo.Arguments = argument;

                process = Process.Start(processStartInfo);
                process.WaitForExit();
            }

            foreach (FileInfo file in new DirectoryInfo(video_folder_path).GetFiles("*.ts"))
            {
                if (file.Name.Equals("combined.ts"))
                    continue;

                file.Delete();
            }

            btnDownload.Enabled = true;
            btnDownload.Text = "다운로드";
            MessageBox.Show("다운로드를 완료했습니다.");
        }

        private string GetColumnName(int index)
        {
            const string letters = "abcdefghijklmnopqrstuvwxyz";

            string value = "";

            if (index >= letters.Length)
                value += letters[index / letters.Length - 1];

            value += letters[index % letters.Length];

            return value;
        }
    }
}
