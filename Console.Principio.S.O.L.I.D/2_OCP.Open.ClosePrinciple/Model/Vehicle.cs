using Desig.PattersPrincipio.S.O.L.I.D._2_OCP.Open.ClosePrinciple.Interface;
using System;

namespace Desig.PattersPrincipio.S.O.L.I.D._2_OCP.Open.ClosePrinciple.Model
{
    public class Vehicle : IVehicle
    {
        protected string _color;
        protected int _year;
        protected double _engene;

        public Vehicle(string color, int year, double engene)
        {
            _color = color;
            _year = year;
            _engene = engene;
        }

        public void StartMotors()
        {
            Console.WriteLine("Contrato com a interface");
        }
    }
}
