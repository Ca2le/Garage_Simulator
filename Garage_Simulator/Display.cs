namespace Garage_Simulator
{
    internal static class Display
    {
        public static string Menu()
        {
            return "====================MENU=================\n" +
                    "1.) Press 1 to create new vehicle.\n" +
                    "2.) Press 2 to delete existing vehicle.\n" +
                    "0.) Press 0 to exit.\n"+
                    "========================================";
        }
        public static void CreateVehicleMenu()
        {
            bool isCreating = true;
            int index = 0;
            Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();
            string[] vehicleDependencies = { "Model: ", "Vehicles registration number: ", "Price: "};
            while(isCreating)
            {
                Console.WriteLine("=========CREATE=YOUR=VEHICLE=========\n");
                Console.Write(vehicleDependencies[index]);
                string input = Console.ReadLine();
                index++;
                Console.WriteLine("=====================================");

            }
            
        }
    }
}