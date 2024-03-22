namespace Garage_Simulator
{
    internal class Grid
    {
        private int[][] _grid;
        private ColorBook _colorBook;
        public Grid()
        {
            this._grid = this.CreateEmptyGrid(10);
            this._colorBook = new ColorBook();
        }

        private int[][] CreateEmptyGrid(int size)
        {
            int[][] grid = new int[size][];
            for (int i = 0; i < size; i++)
            {
                grid[i] = new int[size];
                for (int j = 0; j < size; j++)
                {
                    grid[i][j] = 0;
                }
            }

            return grid;
        }

        public Square[][] FillGridWithSquares()
        {
            Square[][] renderdMap = new Square[_grid.Length][];
            for(int i = 0; i < _grid.Length; i++)
            {
                Square[] col = new Square[_grid.Length];
                
                for (int j = 0; j < _grid.Length; j++)
                {
                    if (_grid[i][j] == 0)
                    {
                        col[j] = new EmptySquare();
                    }
                    else
                    {
                        col[j] = new BusySquare();
                    }
                }
            }
            return renderdMap;
        }

        public void Render(Square[][] grid)
        {
            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid.Length; j++)
                {
                    string color = grid[i][j].Color();
                    ConsoleColor currentColor = _colorBook.GetColor(color);
                    char texture = grid[i][j].Texture();
                    Console.BackgroundColor = currentColor;
                    Console.Write(texture);


                }
              
            }
        }
    }
}

