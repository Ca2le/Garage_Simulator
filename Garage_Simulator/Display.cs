using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;

namespace Garage_Simulator
{
    internal class Display : GarageHandler
    {
        public bool MainMenuRunning = true;
        public void MainMenu()
        {
            int currentIndex = 0;
            string[] menuChoices = { 
                "Create new vehicle!",      //0
                "Get garage list",          //1
                "GetDiffrentVehicleTypes",  //2
                "GetVehicleByID",           //3
                "FindAllExpensiveVehicles", //4
                "ChangeGarageSize",         //5
                "Delete existing vehicle.", //6
                "Exit." };                  //7
            

            while (MainMenuRunning)
            {    
                Console.WriteLine("============MAIN=MENU============");
                for (int i = 0; i < menuChoices.Length; i++)
                {
                    if (i == currentIndex)
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.WriteLine(menuChoices[i]);
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        Console.WriteLine(menuChoices[i]);
                    }
                }

                Console.WriteLine("=================================");
                string output = WaitForKeyInput();
                // If return value is -1, set index to 2. 
                if (output == "UP" && currentIndex == 0)
                {
                    currentIndex = menuChoices.Length - 1;
                }
                else if (output == "DOWN" && currentIndex == menuChoices.Length - 1)
                {
                    currentIndex = 0;
                }
             
                else if (output == "ENTER") {
                    GoTo(currentIndex);
                }
                else if (output == "EXIT") MainMenuRunning = false;
                
                // If input is in range of menuChoices.
             
                else if(output == "UP") currentIndex--;
                else if(output == "DOWN") currentIndex++;

                Console.Clear();
               
            }
        }
        public void CreateVehicle()
        {
            bool isCreating = true;
            if (!AnyEmptySlotsInGarage())
            {
                isCreating = false;
                Console.WriteLine("Garage is full! Please delete a vehicle before adding a new one.");
                Console.WriteLine("Press any key to continue..");
                Console.ReadKey();
            }

           
          
            int index = 0;
          
            //string[] vehicleDependencies = { "What type is your vehicle? ", "Please provide vehicles registration number", "What did it cost in euro?" };
            //Console.Write(vehicleDependencies[index]);
            string vehicleType = "Car";
            string regNr = "ABC123";
            int price = 1000;
            int size = 1;
            string color = "Green";
       

            while (isCreating)
            {
                Console.WriteLine("=========CREATE=YOUR=VEHICLE=========\n");
                switch (index)
                {
                    case 0:
                        {
                            string output = VehicleMenu();
                            if (output == "EXIT") isCreating = false;
                            else
                            {
                               vehicleType = output;
                            }
                            break;
                        }
                    case 1:
                        {
                            string output = RegPlateMenu();
                            if (output == "EXIT") isCreating = false;
                            else
                            {
                                regNr = output;
                            }
                            break;

                        }
                    case 2:
                        {
                            string output = PriceMenu();
                            if (output == "EXIT") isCreating = false;
                            else
                            {
                                price = int.Parse(output);
                            }

                            break;
                        }
                        case 3:
                        {
                            string output = SizeMenu();
                            if (output == "EXIT") isCreating = false;
                            else
                            {
                                size = int.Parse(output);
                            }

                            break;
                        }
                    case 4:
                        {
                            string output = ColorMenu();
                            if (output == "EXIT") isCreating = false;
                            else
                            {
                                color = output;
                            }

                            break;
                        }
                    case 5:
                        {

                            string output = SaveVehicle(vehicleType, regNr, price, size, color);  
                            if(output == "SAVE")
                            {
                                //(string type, string regPlate, int price, int size, string color
                                AddVehicle(vehicleType, regNr, price, size, color);
                              
                            } 
                            
                            isCreating = false;
                            break;
                        }
                }

                index++;
        
                Console.Clear();
            }
            
        }

        public void Exit()
        {
            MainMenuRunning = false;
        }

        public void GoTo(int index)
        {
            Console.Clear();
            switch (index)
            {
                case 0:
                    {
                       
                        CreateVehicle();
                        break;
                    }
                case 1:
                    {
                        GetAllVehicles(); 
                        break;
                    }
                case 2:
                    {
                        GetDiffrentVehicleTypes();
                        break;
                    }
                    case 3:
                    {
                        Console.WriteLine("Please enter 6 digits registration number.");
                        string regNr = Console.ReadLine();
                        GetVehicleByID(regNr);
                        break;
                    }
                    case 4:
                    {
                        FindAllExpensiveVehicles();
                        break;
                    }
                    case 5:
                    {
                        Console.WriteLine("Please enter size of garage.");
                        string size = Console.ReadLine();
                        ChangeGarageSize(size);
                        break;
                    }
                case 6:
                    {
                        DestroyAVehicle();
                        break;
                    }
                case 7:
                    {
                        Exit();
                        break;
                    }
            }
        }


        public string WaitForKeyInput()
        {
            ConsoleKeyInfo input = Console.ReadKey();
            switch (input.Key)
            {
                case ConsoleKey.UpArrow:
                    {
                        return "UP";
                    }
                case ConsoleKey.DownArrow:
                    {
                        return "DOWN";
                    }
                case ConsoleKey.LeftArrow:
                    {
                        return "LEFT";
                    }
                case ConsoleKey.RightArrow:
                    {
                        return "RIGHT";
                    }
                case ConsoleKey.Enter:
                    {
                        return "ENTER";
                    }
                case ConsoleKey.Escape:
                    {
                        return "EXIT";
                    }
                default:
                    {
                        return "ERROR";

                    }
            }
        }

        public string VehicleMenu()
        {
            bool userIsChoosing = true;
            List<VehicleType> vechileTypes = GarageConfig.Get.VehicleTypes;
   
            int currentIndex = 0;
            while (userIsChoosing)
            {
                Console.Clear();
                Console.WriteLine("=========CREATE=YOUR=VEHICLE===========");
                Console.WriteLine();
                Console.WriteLine(" What type is your vehicle?");
                Console.WriteLine();
                for (int i = 0; i < vechileTypes.Count ; i++)
                {
                
                    Console.ForegroundColor = ConsoleColor.White;
                    if (i == currentIndex)
                    {
                        Console.BackgroundColor = ColorBook.GetColor(vechileTypes[i].Color);
                        Console.Write(" " + vechileTypes[i].Vehicle + " ");
                        Console.BackgroundColor = ConsoleColor.Black;
                    }
                    else
                    {
                        Console.Write(" " + vechileTypes[i].Vehicle + " ");
                    }
                }
                string output = WaitForKeyInput();

                if (output == "LEFT" && currentIndex == 0)
                {
                    currentIndex = vechileTypes.Count - 1;
                }
                else if (output == "RIGHT" && currentIndex == vechileTypes.Count - 1)
                {
                    currentIndex = 0;
                }
                else if (output == "ENTER")
                {
                    userIsChoosing = false;
                    return vechileTypes[currentIndex].Vehicle;

                }
                else if (output == "EXIT")
                {
                    userIsChoosing = false;
                }
                else if (output == "LEFT") currentIndex--;
                else if (output == "RIGHT") currentIndex++;

            }
            return "EXIT";
        }

        public string RegPlateMenu()
        {
            bool noValidInput = false;
            do
            {
                Console.WriteLine("Please provide vehicles registration number.");
                Console.WriteLine();
               
                string regnum = Console.ReadLine();

                if ( regnum.Length != 6)
                {
                    Console.WriteLine();
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine("Not a valid registration number! Try again.");
                    Console.BackgroundColor = ConsoleColor.Black;
                   
                    noValidInput = true;
                }

                else
                {
                    return regnum;
                }
            } while (noValidInput);

            return "EXIT";
        }
        public string PriceMenu()
        {
            bool validInput = true;
            while (validInput)
            {
                Console.WriteLine("What did it cost in dollars?");
                Console.WriteLine();
                string price = Console.ReadLine();
                if(!string.IsNullOrEmpty(price))
                {
                    if (int.TryParse(price, out int result))
                    {
                        return price;
                    }
                }
                
                else
                {
                    Console.WriteLine();
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine("Not a valid price! Try again.");
                    Console.BackgroundColor = ConsoleColor.Black;
                   
                }
            }
            return "EXIT";

        }
        public string SizeMenu()
        {
            bool validInput = true;
            while (validInput)
            {
                Console.WriteLine("What size is your vehicle?");
                Console.WriteLine();
                string size = Console.ReadLine();
                if (!string.IsNullOrEmpty(size))
                {
                    if (int.TryParse(size, out int result))
                    {
                        return size;
                    }
                }

                else
                {
                    Console.WriteLine();
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine("Not a valid size! Try again.");
                    Console.BackgroundColor = ConsoleColor.Black;

                }
            }
            return "EXIT";

        }

        public string ColorMenu()
        {
            bool validInput = true;
            while (validInput)
            {
                Console.WriteLine("What color is your vehicle?");
                Console.WriteLine();
                string color = Console.ReadLine();
                if (!string.IsNullOrEmpty(color))
                {
                    return color;
                }

                else
                {
                    Console.WriteLine();
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine("Not a valid color! Try again.");
                    Console.BackgroundColor = ConsoleColor.Black;

                }

            }
            return "EXIT";
        }
        public string SaveVehicle(string vehicleType, string regNr, int price, int size, string color)
        {

            regNr = regNr.Insert(3, " ");
          
            bool userIsChoosing = true;
            VehicleType vehicleSpecs = GarageConfig.Get.VehicleTypes.Find((key) => key.Vehicle == vehicleType);
            int currentIndex = 0;

            while (userIsChoosing)
            {
                Console.Write($"Would you like to save your ");
                BackGroundColor(vehicleSpecs.Color);
                Console.Write(" " + vehicleType + " ");
                BackGroundColor("Black");
                Console.WriteLine(" ?");

                Console.WriteLine();

                Console.WriteLine($"Vehicle: {vehicleType}");
                Console.WriteLine($"RegNr:   {regNr}");
                Console.WriteLine($"Value:   {price} $");
                Console.WriteLine($"Size:    {size}");
                Console.WriteLine($"Color:   {color}");
                Console.WriteLine();


                string[] choices = { " YES ", " NO WAY! " };
                string[] colors = { "Green", "Red" };
              
              

                for (int i = 0; i < choices.Length; i++)
                {

                    Console.ForegroundColor = ConsoleColor.White;
                    if (i == currentIndex)
                    {
                        if (i == 1) Console.Write(" or ");
                        BackGroundColor(colors[currentIndex]);
                        Console.Write(choices[i]);
                        BackGroundColor("Black");
                        if(i == 0) Console.Write(" or ");
                 
                    }
                    
                    else
                    {
                        BackGroundColor("Black");
                        Console.Write(choices[i]);
                       
                    }
                }

                string output = WaitForKeyInput();

                if (output == "LEFT" && currentIndex == 0)
                {
                    currentIndex = choices.Length - 1;
    
                }
                else if (output == "RIGHT" && currentIndex == choices.Length - 1)
                {
                    currentIndex = 0;
                }
                else if (output == "ENTER")
                {
                    userIsChoosing = false;
                    return "SAVE";

                }
                else if (output == "EXIT")
                {
                    userIsChoosing = false;
                }
                else if (output == "LEFT") currentIndex--;
                else if (output == "RIGHT") currentIndex++;
                Console.Clear();
                Console.WriteLine("=========CREATE=YOUR=VEHICLE===========");
                Console.WriteLine();
            }
          
            return "EXIT";
        }

        public void BackGroundColor(string color)
        {
            Console.BackgroundColor = ColorBook.GetColor(color);
        }
    }
    

}


