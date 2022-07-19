using ISP.InterfaceSegregationPrinciple.Interfaces;
using System;

namespace ISP.InterfaceSegregationPrinciple.Vehicles
{
    public class Car : IVehicleCar
    {
        private string _color;
        private int _year;
        private double _engine;
        private int _seats;
        private int _doors;

        public Car(string color, int year, double engine, int seats, int doors)
        {
            ConfigureCar(color, year, engine, seats, doors);    
        }

        public void ConfigureCar(string color, int year, double engine, int seats, int doors)
        {
            _color = color;
            _year = year;
            _engine = engine;
            _seats = seats;
            _doors = doors;

            Console.WriteLine($"Criando carro Ano {year}, Cor {color} Potencia {engine}");
        
            StartVehicle();
        }

        public void StartVehicle()
        {
            Console.WriteLine("Ligando Motores");
        }
    }
}
