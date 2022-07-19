using Desig.PattersPrincipio.S.O.L.I.D._2_OCP.Open.ClosePrinciple.Model;
using Desig.PattersPrincipio.S.O.L.I.D._2_OCP.Open.ClosePrinciple.TypeEnum;
using DIP.DependencyInjectionPrinciple.Payments;
using ISP.InterfaceSegregationPrinciple.Vehicles;
using LSP.LiskovSubstitutionPriciple.Payments;
using System;

namespace Desig.PattersPrincipio.S.O.L.I.D
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region OCP
            //TypeVehicle type = TypeVehicle.CAR; //troca o type e return o else

            //if (type == TypeVehicle.CAR)
            //{
            //    Car vehicle = new Car("Azul", 2022, 2.0, 5, 4);
            //}
            //else
            //{
            //    Motocycle vehicle = new Motocycle("Branco", 2023, 250);
            //}
            #endregion

            #region LSP
            //CreditCard card = new CreditCard();
            //DebitCard card = new DebitCard();
            //NubankRewards card = new NubankRewards();

            //card.Validate();
            //card.CollectPayment();
            #endregion

            #region ISP

            //Car car = new Car("Azul", 2022, 4.0, 2, 2);
            //Motorcycle motorcycle = new Motorcycle("Branca", 2023, 600);

            #endregion

            #region DIP

            PaymentProcess payment = new PaymentProcess();
            payment.Pay("ABC123");

            #endregion

            Console.WriteLine("Hello World!");
        }
    }
}
