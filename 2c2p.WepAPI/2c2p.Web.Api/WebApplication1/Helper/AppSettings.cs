using Microsoft.Extensions.Configuration;

namespace WebApi2c2p.Helper
{
    public class AppSettings
    {     
        public string ReadConfig(string section , string name)
        {
            var MyConfig = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            string configValue = MyConfig.GetValue<string>(section+":"+ name);
           
            
            return configValue;
        } 
    }
}
