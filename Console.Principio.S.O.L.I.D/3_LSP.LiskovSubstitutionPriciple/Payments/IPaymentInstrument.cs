namespace LSP.LiskovSubstitutionPriciple.Payments
{
    public interface IPaymentInstrument
    {
        void Validate();
        void CollectPayment();
    }
}
