namespace DIP.DependencyInjectionPrinciple.Model
{
    public class MongoDBProduct : IDbProduct
    {
        public string GetProductById(string id)
        {
            return $"MongoDB: exibindo dados do produto {id}";
        }
    }
}
