using DIP.DependencyInjectionPrinciple.Model;
using System.Configuration;

namespace DIP.DependencyInjectionPrinciple.Factory
{
    public class DbProductFactory
    {
        public static IDbProduct Create()
        {
            if(ConfigurationManager.AppSettings["DB"] == "SQLSERVER")
            {
                return new SQLServerProduct();
            }
            else
            {
                return new MongoDBProduct();
            }
        }
    }
}
