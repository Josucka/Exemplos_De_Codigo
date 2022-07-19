using System;

namespace LSP.LiskovSubstitutionPriciple.Payments
{
    public class DebitCard : NubankCard
    {
        public override void Validate()
        {
            //onde eu pposso colocar as regras pra validar de verdade o cartao
            Console.WriteLine("Verificando Saldo limite...");
            Console.WriteLine("Saldo disponivel");
        }
    }
}
