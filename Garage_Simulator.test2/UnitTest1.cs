namespace Garage_Simulator
{
    public class Tests
    {
      
        [SetUp]
        public void Setup()
        {
           
        }


        [Test]
        public void GarageTest()
        {
            //1.Arrange h�r s�tter ni upp det som ska testas, instansierar objekt och inputs
 
            int size = 9;
            Garage<Vehicle> garage = new Garage<Vehicle>(size);
     
            //2.Act h�r anropar ni metoden som ska testas

            //3.Assert h�r kontrollerar ni att ni f�tt det f�rv�ntade resultatet

            Assert.That(garage.Space.Length, Is.EqualTo(size));
        }
    }
}