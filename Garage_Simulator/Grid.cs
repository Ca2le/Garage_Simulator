using System.Text.Json;

namespace Garage_Simulator
{
    internal class Grid
    {
        public Grid()
        {
           
            this.CreateEmptyGrid(GarageConfig.Get.GridSize);
       
        }
        public Square[,] CurrentGrid { get; set; }

        private void CreateEmptyGrid(int size)
        {
            Square[,] grid = new Square[size,size];
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    grid[i, j] = new EmptySquare();
                }
            }

            CurrentGrid = grid;
        }
        //public void Update()
        public void Render(Square[, ] grid)
        {
            for (int i = 0; i < grid.GetLength(0); i++)
            {
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    ConsoleColor color = grid[i, j].Color();
               
                    string texture = grid[i, j].Texture();
                    Console.BackgroundColor = color;

                    if (j == grid.GetLength(1)-1)
                    {
                        Console.Write(texture + "\n");
                    }else
                    {
                        Console.Write(texture);
                    }

                    Console.BackgroundColor = ConsoleColor.Black;


                }
              
            }
        }
    }
}

