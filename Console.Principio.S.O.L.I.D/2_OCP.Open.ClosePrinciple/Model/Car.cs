using System;

namespace Desig.PattersPrincipio.S.O.L.I.D._2_OCP.Open.ClosePrinciple.Model
{
    public class Car : Vehicle
    {
        private int _seats;
        private int _doors;

        public Car(string color, int year, double engine, int seats, int doors) : base(color, year, engine)
        {
            _seats = seats;
            _doors = doors;
            ConfigureCar();
        }

        public void ConfigureCar()
        {
            Console.WriteLine($"Criando carro {_color}, {_year}, {_doors}, {_seats}");
            StartMotors();
        }
    }
}
