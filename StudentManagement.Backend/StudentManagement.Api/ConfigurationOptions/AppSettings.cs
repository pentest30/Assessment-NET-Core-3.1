namespace StudentManagement.Api.ConfigurationOptions
{
    public class AppSettings
    {
        public  ConnectionStrings ConnectionStrings { get; set; }
        public CORS Cors { get; set; }
        public string Secret { get; set; }
    }
}