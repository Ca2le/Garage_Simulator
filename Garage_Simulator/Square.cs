namespace Garage_Simulator
{

    internal abstract class Square : ISquare
    {
        private int _width = 1; //JSON SETTING LATER
        private int _height = 1; //JSON SETTING LATER

        public abstract bool Active();
        public abstract string Color();
        public abstract char Texture();

    }
}