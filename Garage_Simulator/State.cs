using Garage_Simulator.Vehicles;

namespace Garage_Simulator
{
    internal class State
    {
        private List<Vehicle> _vehicles;
        public void AddVehicle(string type, string model, double price, string regPlate)
        {
            switch (type)
            {
                case "car":
                    {
                        Vehicle car = new Car(model, price, regPlate);
                        _vehicles.Add(car);
                        break;
                    }
                case "mc":
                    {
                        
                        break;
                    }
                case "battletank":
                    {
                        break;
                    }
                case "airplane":
                    {
                        break;
                    }
                default: {
                        throw new ArgumentException($"{type} dont exist..");
                 
                    }
            }
        }
        public void DeleteVehicle(string regPlate)
        {
            _vehicles.FirstOrDefault( (vehicle) => vehicle.RegistrationPlate == regPlate );

        }
    }
}