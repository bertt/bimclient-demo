using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BimClientDemo
{
    public partial class Form1 : Form
    {
        private string baseurl = "https://thisisanexperimentalserver.com";
        private string jsonurl, downloadurl;
        private string token = "";

        public Form1()
        {
            InitializeComponent();
            jsonurl = baseurl + "/json";
            downloadurl = baseurl + "/download";
            tbServer.Text = jsonurl;
        }

        private async void IsLoggedIn_Click(object sender, EventArgs e)
        {
            var body = BimRequestBody.GetIsLoggedIn(token);
            var response = await BimRequestSender.SendBimRequest<BimResponse<IsLoggedInResponse>>(jsonurl, body);
            btnIsLoggedIn.Text = response.response.result.ToString();
        }

        private async void GetAllProjects_Click(object sender, EventArgs e)
        {
            var body = BimRequestBody.GetAllProjects(token);
            var response = await BimRequestSender.SendBimRequest<BimResponse<GetAllProjectsResponse>>(jsonurl, body);
            btnGetAllProjects.Text = response.response.result[0].name;
        }

        private async void Login_Click(object sender, EventArgs e)
        {
            var body = BimRequestBody.GetLogin(token, tbUsername.Text,tbPassword.Text);
            var response = await BimRequestSender.SendBimRequest<BimResponse<LoginResponse>>(jsonurl, body);
            token = response.response.result;
            btnLogin.Text = response.response.result;
            btnGetAllProjects.Enabled = true;
            btnIsLoggedIn.Enabled = true;
        }

        private async void BtnDownload_Click(object sender, EventArgs e)
        {
            var body = BimRequestBody.GetDownload(token, new int[] { 11927555 });
            var response = await BimRequestSender.SendBimRequest<BimResponse<DownloadResponse>>(jsonurl, body);
            var topicid =response.response.result;
            var downloadTopicUrl = downloadurl + $"?token={token}&topicId={topicid}";
            await Download(downloadTopicUrl, topicid);
            btnDownload.Text = $"{topicid}.ifc created!";
        }


        static async Task Download(string url, int topicid)
        {
            using (HttpClient client = new HttpClient())
            {
                using (var response = await client.GetAsync(url, HttpCompletionOption.ResponseHeadersRead))
                using (var streamToReadFrom = await response.Content.ReadAsStreamAsync())
                {
                    using (var streamToWriteTo = File.Open(topicid + ".ifc", FileMode.Create))
                    {
                        await streamToReadFrom.CopyToAsync(streamToWriteTo);
                    }
                }
            }
        }
    }
}
