namespace Garage_Simulator
{
    internal class Grid
    {
        private ColorBook _colorBook;
        public Grid()
        {
            this.CreateEmptyGrid(10);
            this._colorBook = new ColorBook();
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
                    string color = grid[i, j].Color();
                    ConsoleColor currentColor = _colorBook.GetColor(color);
                    string texture = grid[i, j].Texture();
                    Console.BackgroundColor = currentColor;

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

