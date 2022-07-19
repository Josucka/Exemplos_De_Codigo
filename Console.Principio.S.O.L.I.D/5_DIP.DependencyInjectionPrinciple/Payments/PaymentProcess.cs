using DIP.DependencyInjectionPrinciple.Factory;
using DIP.DependencyInjectionPrinciple.Model;
using System;

namespace DIP.DependencyInjectionPrinciple.Payments
{
    public class PaymentProcess
    {
        public void Pay(string id)
        {
            IDbProduct product = DbProductFactory.Create();
            string productData = product.GetProductById(id);
            Console.WriteLine(productData);
        }
    }
}
