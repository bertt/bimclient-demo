namespace BimClientDemo
{
    public class BimResponse<T>
    {
        public T response { get; set; }
    }

    public class DownloadResponse
    {
        public int result { get; set; }
    }

    public class LoginResponse
    {
        public string result { get; set; }
    }

    public class IsLoggedInResponse
    {
        public bool result { get; set; }
    }

    public class GetAllProjectsResponse
    {
        public Project[] result { get; set; }
    }

    public class Project
    {
        public string __type { get; set; }
        public int checkinInProgress { get; set; }
        public object[] checkouts { get; set; }
        public object[] concreteRevisions { get; set; }
        public int createdById { get; set; }
        public long createdDate { get; set; }
        public string description { get; set; }
        public string exportLengthMeasurePrefix { get; set; }
        public object[] extendedData { get; set; }
        public int geoTagId { get; set; }
        public int[] hasAuthorizedUsers { get; set; }
        public int id { get; set; }
        public int lastConcreteRevisionId { get; set; }
        public int lastRevisionId { get; set; }
        public int[] logs { get; set; }
        public object[] modelCheckers { get; set; }
        public string name { get; set; }
        public object[] newServices { get; set; }
        public int oid { get; set; }
        public int parentId { get; set; }
        public object[] revisions { get; set; }
        public int rid { get; set; }
        public string schema { get; set; }
        public bool sendEmailOnNewRevision { get; set; }
        public object[] services { get; set; }
        public string state { get; set; }
        public object[] subProjects { get; set; }
        public string uuid { get; set; }
    }
}
