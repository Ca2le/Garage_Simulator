using System;
using System.Collections.Generic;
using System.Drawing;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Garage_Simulator
{
    public class GarageConfig
    {
        public int GridSize { get; set; }
        public List<VehicleType> VehicleTypes { get; set; }

        public static GarageConfig Get
        {
            get {
                string app = AppDomain.CurrentDomain.BaseDirectory;
                // No clean code... Unfortunatly there is no better way to get the project directory.
                string projectDirectory = Directory.GetParent(app).Parent.Parent.Parent.FullName;
                string filePath = Path.Combine(projectDirectory, "GarageConfig", "GarageConfig.json");
        
                string json = File.ReadAllText(filePath);

                GarageConfig config = JsonSerializer.Deserialize<GarageConfig>(json);
                return config;
            }
            //C:\Users\carls\source\repos\Garage_Simulator\Garage_Simulator\GarageConfig\GarageConfig.json
        }
    }

    public class VehicleType
    {
        public string Color { get; set; }
        public string Vehicle { get; set; }

        public int Size { get; set; }
    }
}
