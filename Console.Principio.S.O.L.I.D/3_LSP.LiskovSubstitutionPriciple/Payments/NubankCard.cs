using System;

namespace LSP.LiskovSubstitutionPriciple.Payments
{
    public abstract class NubankCard : IPaymentInstrument
    {
        public void CollectPayment()
        {
            Console.WriteLine("Pagamento realizado!");
        }

        public virtual void Validate()
        {
            //Validaçao do cartao
        }
    }
}
