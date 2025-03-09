namespace HomeBillings.Core.Identidade
{
    public class AppSettings
    {
        public string Secret { get; set; }
        public int ExpiresIn { get; set; }
        public string Emissor { get; set; }
        public string ValideIn { get; set; }
    }
}
