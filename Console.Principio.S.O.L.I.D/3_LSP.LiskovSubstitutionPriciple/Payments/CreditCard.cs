using System;

namespace LSP.LiskovSubstitutionPriciple.Payments
{
    public class CreditCard : NubankCard
    {
        public override void Validate()
        {
            //onde eu pposso colocar as regras pra validar de verdade o cartao
            Console.WriteLine("validando limite...");
            Console.WriteLine("Limite OK");
        }
    }
}
