using ISP.InterfaceSegregationPrinciple.Interfaces;
using System;

namespace ISP.InterfaceSegregationPrinciple.Vehicles
{
    public class Motorcycle : IVehicleMotorcycle
    {
        private string _color;
        private int _year;
        private double _engine;

        public Motorcycle(string color, int year, double engine)
        {
            ConfigureMotorcycle(color, year, engine);
        }

        public void ConfigureMotorcycle(string color, int year, double engine)
        {
            _color = color;
            _year = year;
            _engine = engine;

            Console.WriteLine($"Criando Moto Ano {year}, Cor {color} Potencia {engine}");

            StartVehicle();
        }

        public void StartVehicle()
        {
            Console.WriteLine("Ligando Motores");
        }
    }
}
