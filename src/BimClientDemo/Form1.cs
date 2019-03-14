using System;
using System.Windows.Forms;

namespace BimClientDemo
{
    public partial class Form1 : Form
    {
        private string url = "https://thisisanexperimentalserver.com/json";
        private string token = "";

        public Form1()
        {
            InitializeComponent();
            tbServer.Text = url;
        }

        private async void IsLoggedIn_Click(object sender, EventArgs e)
        {
            var body = BimRequestBody.GetIsLoggedIn(token);
            var response = await BimRequestSender.SendBimRequest<BimResponse<IsLoggedInResponse>>(url, body);
            btnIsLoggedIn.Text = response.response.result.ToString();
        }

        private async void GetAllProjects_Click(object sender, EventArgs e)
        {
            var body = BimRequestBody.GetAllProjects(token);
            var response = await BimRequestSender.SendBimRequest<BimResponse<GetAllProjectsResponse>>(url, body);
            btnGetAllProjects.Text = response.response.result[0].name;
        }

        private async void Login_Click(object sender, EventArgs e)
        {
            var body = BimRequestBody.GetLogin(token, tbUsername.Text,tbPassword.Text);
            var response = await BimRequestSender.SendBimRequest<BimResponse<LoginResponse>>(url, body);
            token = response.response.result;
            btnLogin.Text = response.response.result;
            btnGetAllProjects.Enabled = true;
            btnIsLoggedIn.Enabled = true;
        }
    }
}
