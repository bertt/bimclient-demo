using System.Dynamic;

namespace BimClientDemo
{
    public class RootobjectRequest
    {
        public string token { get; set; }
        public Request request { get; set; }
    }

    public class Request
    {
        public string @interface { get; set; }
        public string method { get; set; }
        public ExpandoObject parameters { get; set; }
    }


    /**public class Result
    {
        public string result { get; set; }
    }*/
}
