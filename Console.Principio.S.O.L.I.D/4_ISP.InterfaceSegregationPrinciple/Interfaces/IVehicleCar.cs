using ISP.InterfaceSegregationPrinciple.Vehicles;

namespace ISP.InterfaceSegregationPrinciple.Interfaces
{
    public interface IVehicleCar : IVehicle
    {
        void ConfigureCar(string color, int year, double engine, int seats, int doors);
    }
}
