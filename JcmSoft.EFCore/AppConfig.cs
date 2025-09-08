namespace JcmSoft.EFCore
{
    public static class AppConfig
    {
        public static string GetConnectionString()
        {
            return "Data Source=DEYVID-02\\MSSQLSERVERAULAS;Initial Catalog=JcmSoftDatabase;Integrated Security=True;TrustServerCertificate=True";
        }
    }
}
