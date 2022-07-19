namespace DIP.DependencyInjectionPrinciple.Model
{
    public class SQLServerProduct : IDbProduct
    {
        public string GetProductById(string id)
        {
            return $"SQLServer: exibindo dados {id}.";
        }
    }
}
