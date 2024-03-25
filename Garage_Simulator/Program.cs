namespace Garage_Simulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Controller controller = new Controller();
            Grid grid = new Grid();
            Keyboard keyboard = new Keyboard();
            keyboard.Off();
            Display display = new Display();
            grid.Render(grid.CurrentGrid);
        }
    }
}
