using Newtonsoft.Json;
using System.Dynamic;
using System.Net.Http;

namespace BimClientDemo
{
    public static class BimRequestBody
    {
        // login
        public static StringContent GetLogin(string token, string username, string password)
        {
            dynamic par = new ExpandoObject();
            par.username = username;
            par.password = password;
            return GetBody(token, "AuthInterface", "login",par);
        }

        // login
        public static StringContent GetIsLoggedIn(string token)
        {
            dynamic par = new ExpandoObject();
            return GetBody(token, "AuthInterface", "isLoggedIn", par);
        }

        // GetAllProjects
        public static StringContent GetAllProjects(string token)
        {
            dynamic par = new ExpandoObject();
            par.onlyTopLevel = false;
            par.onlyActive = false;
            return GetBody(token, "ServiceInterface", "getAllProjects", par);
        }

        private static StringContent GetBody(string token, string @interface, string method, ExpandoObject par)
        {
            var body = new RootobjectRequest();
            body.token = token;
            var request = new Request() { @interface = @interface, method = method, parameters = par };
            body.request = request;
            var json = JsonConvert.SerializeObject(body);
            return new StringContent(json);
        }
    }
}
