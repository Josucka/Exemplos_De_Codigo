using ISP.InterfaceSegregationPrinciple.Vehicles;

namespace ISP.InterfaceSegregationPrinciple.Interfaces
{
    public interface IVehicleMotorcycle : IVehicle
    {
        void ConfigureMotorcycle(string color, int year, double engine);
    }
}
