namespace MyTaskInteview.Helpers
{
    public class JWT
    {
      

        public string Key { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public double DurationInDays { get; set; }

        public JWT(string key, string issuer, string audience, double durationInDays)
        {
            Key = key;
            Issuer = issuer;
            Audience = audience;
            DurationInDays = durationInDays;
        }

        public JWT()
        {

        }
    }
}
