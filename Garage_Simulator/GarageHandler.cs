using Garage_Simulator;

namespace Garage_Simulator
{
    internal class GarageHandler
    {
   
        public GarageHandler()
        {
            Garage = new Garage<Vehicle>();

        }

        public Garage<Vehicle> Garage { get; set; }
       

        public bool AnyEmptySlotsInGarage()
        {
            bool containsEmptySpace = Garage.Space.Any(space => space == null);
            return containsEmptySpace;
        }

        public void AddVehicle(string type, string regPlate, int price, int size, string color)
        {
            int emptySpace = Array.FindIndex(Garage.Space, space => space == null);
            switch (type)
            {
                case "Car":
                    {
                      
                        bool waitingForUserInput = true;
                        bool haveRoof = false;
                        while (waitingForUserInput)
                        {
                            Console.WriteLine("Does the car have a roof? y/n");
                            string input = Console.ReadLine();
                            if (input != "y" && input != "n")
                            {
                                Console.WriteLine("Try again. invalid input");
                            }
                            else
                            {
                                haveRoof = input == "y";
                                waitingForUserInput = false;
                            }
                            
                        }

                        Car car = new Car(haveRoof, regPlate, price, size, color);
                        Garage.Space[emptySpace] = car;
                        break;
                    }
                case "MC":
                    {

                        bool waitingForUserInput = true;
                        string cubicCentimeter = "50cc";
                        while (waitingForUserInput)
                        {
                            Console.WriteLine("Motorsize? For example: Press 1 for 50cc.");
                            Console.WriteLine("1. 50cc");
                            Console.WriteLine("2. 500cc");
                            Console.WriteLine("3. 1000cc");

                            string input = Console.ReadLine();
                            switch(input)
                            {
                                case "1":
                                    {
                                        cubicCentimeter = "50cc";
                                        break;
                                    }
                                case "2":
                                    {
                                        cubicCentimeter = "500cc";
                                        break;
                                    }
                                case "3":
                                    {
                                        cubicCentimeter = "1000cc";
                                        break;
                                    }
                                default:
                                    {
                                        Console.WriteLine("Invalid input. Try again.");
                                        break;
                                    }
                            }

                           
                        }
                        Vehicle mc = new MC(cubicCentimeter, regPlate, price, size, color);
                        Garage.Space[emptySpace] = mc;
                        break;
                    }
                case "BattleTank":
                    {
                        bool waitingForUserInput = true;
                        int cannonBalls = 0;
                        while (waitingForUserInput)
                        {
                            Console.WriteLine("How many cannonballs does the vehicle contain?");
                            string input = Console.ReadLine();
                            if(int.TryParse(input, out cannonBalls))
                            {
                                cannonBalls = int.Parse(input);
                                waitingForUserInput = false;
                            } else
                            {
                                Console.WriteLine("Invalid input. Try again.");
                            }
                        }
                        Vehicle battleTank = new BattleTank(cannonBalls, regPlate, price, size, color);
                        Garage.Space[emptySpace] = battleTank;
                        break;
                    }
                case "AirPlane":
                    {
                        bool waitingForUserInput = true;
                        int passangers = 1;
                        while (waitingForUserInput)
                        {
                            Console.WriteLine("How many cannonballs does the vehicle contain?");
                            string input = Console.ReadLine();
                            if (int.TryParse(input, out passangers))
                            {
                                passangers = int.Parse(input);
                                waitingForUserInput = false;
                            }
                            else
                            {
                                Console.WriteLine("Invalid input. Try again.");
                            }
                        }
                        Vehicle airPlane = new AirPlane(passangers, regPlate, price, size, color);
                        Garage.Space[emptySpace] = airPlane;
                        break;
                    }
                default: {
                        throw new ArgumentException($"{type} dont exist..");
                 
                    }
            }
        }
        public void GetAllVehicles()
        {
            var vehicles = Garage.Space;
            foreach (var vehicle in vehicles)
            {
                if (vehicle != null)
                {
                    Console.Write($"Registration Plate: {vehicle.RegistrationPlate} Price: {vehicle.Price} Size: {vehicle.Size} Color: {vehicle.Color} ");
                    if(vehicle is Car)
                    {
                        Car car = (Car)vehicle;
                        Console.WriteLine($"With roof: {car.WithRoof}");
                    }
                    else if(vehicle is MC)
                    {
                        MC mc = (MC)vehicle;
                        Console.WriteLine($"Motor size: {mc.CubicCentimeter}");
                    }
                    else if(vehicle is BattleTank)
                    {
                        BattleTank battleTank = (BattleTank)vehicle;
                        Console.WriteLine($"Cannonballs: {battleTank.CannonBalls}");
                    }
                    else if(vehicle is AirPlane)
                    {
                        AirPlane airPlane = (AirPlane)vehicle;
                        Console.WriteLine($"Passangers: {airPlane.Passangers}");
                    }   
                    Console.WriteLine();
                }
            }
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }

        public void DestroyAVehicle()
        {
            var vehicles = Garage.Space;

            var noNulls = vehicles.Where(vehicle => vehicle != null);

            if (noNulls.Count() > 0)
            {
               Vehicle firstVehicle = noNulls.ElementAt(0);
                string firstVehicleRegPlate = firstVehicle.RegistrationPlate;
                vehicles[0] = null;
                Console.WriteLine($"Vehicle with registration plate {firstVehicleRegPlate} has been destroyed.");
            }
           
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }

        public void GetDiffrentVehicleTypes()
        {
            HashSet<string> list = new HashSet<string>();
            foreach (var vehicle in Garage.Space)
            {
                if (vehicle != null)
                {
                   list.Add(vehicle.GetType().Name);
                }
            }

            foreach (var vehicleType in list)
            {
                Console.WriteLine(vehicleType);
            }
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }

        public void GetVehicleByID(string ID)
        {
            if (string.IsNullOrEmpty(ID) || ID.Length != 6)
            {
                Console.WriteLine("Invalid Registration number.");
                Console.WriteLine("Press any key to continue.");
                Console.ReadKey();
            }
            else
            {
                var vehicles = Garage.Space;
                var match = vehicles.First(vehicle => vehicle?.RegistrationPlate == ID.ToUpper());

                if (match != null)
                {
                    Console.WriteLine($"Registration Plate: {match.RegistrationPlate} Price: {match.Price}");
                }
                else
                {
                    Console.WriteLine("No vehicle with that ID found.");
                }

                Console.WriteLine("Press any key to continue.");
                Console.ReadKey();
            }
        }


        public void ChangeGarageSize(string newSize)
        {
            if(!string.IsNullOrEmpty(newSize) && int.TryParse(newSize, out int result)){
                int size = int.Parse(newSize);
                Garage<Vehicle> newGarage = new Garage<Vehicle>(size);
                Garage.Space = newGarage.Space;
                Console.WriteLine($"Size is set to {size}.");
                Console.WriteLine("Press any key to continue.");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Invalid size.");
            }
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();

        }

        public void FindAllExpensiveVehicles()
        {
            Vehicle[] vehicles = Garage.Space;

            var noNulls = vehicles.Where(vehicle => vehicle != null);
           
            if(noNulls.Count() > 0)
            {
                var expensiveVehicles = noNulls.Where(vehicle => vehicle.Price > 10000);
                if (expensiveVehicles.Count() > 0)
                {
                    foreach (var vehicle in expensiveVehicles)
                    {
                        Console.WriteLine($"Registration Plate: {vehicle.RegistrationPlate} Price: {vehicle.Price} $");
                    }
                }
                else
                {
                    Console.WriteLine("No expensive vehicles found in your garage.. :'( ");
                }
            }
            else
            {
                Console.WriteLine("No vehicles in your garage.. ");
            }
            

            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        
        }

    }
}