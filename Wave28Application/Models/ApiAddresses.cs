namespace Wave28Application.Models
{
    public static class ApiAddresses
    {
        public static string busAdminaddress { get; set; } = "http://localhost:63789/api/BusinessAdminRegistration";
        public static string custAddress { get; set; } = "http://localhost:63789/api/CustomerRegistration";
        public static string loginAddress { get; set; } = "http://localhost:63789/api/AuthorizeUser/LogInUser";
        public static string logoffAddress { get; set; } = "http://localhost:63789/api/api/AuthorizeUser/LogOff";
    }
}