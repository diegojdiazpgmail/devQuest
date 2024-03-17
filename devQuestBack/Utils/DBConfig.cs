using Utils;

namespace devQuestBack.Utils
{
    public class DBConfig : IDBConfig
    {
        private readonly IConfiguration _configuration;

        public DBConfig(IConfiguration configuration)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }


        public string GetDB()
        {
            return _configuration.GetSection("ConnectionStrings:VivelusoContext").Value.ToString();
        }
    }
}
