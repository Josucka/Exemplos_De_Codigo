using System;

namespace LSP.LiskovSubstitutionPriciple.Payments
{
    public class NubankRewards : IPaymentInstrument
    {
        public void CollectPayment()
        {
            Console.WriteLine("Pagamento realizado com sucesso");
            Console.WriteLine("Pontuaçao creditada");
        }

        public void Validate()
        {
            Console.WriteLine("Limite OK, Rewards");
        }
    }
}
