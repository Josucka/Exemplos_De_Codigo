using System;

namespace Desig.PattersPrincipio.S.O.L.I.D._2_OCP.Open.ClosePrinciple.Model
{
    public class Motocycle : Vehicle
    {
        public Motocycle(string color, int year, double engine) : base(color, year, engine)
        {
            ConfigureMotorcycle();
        }

        public void ConfigureMotorcycle()
        {
            Console.WriteLine($"Criando Moto {_color}, {_year}");
            StartMotors();
        }
    }
}
