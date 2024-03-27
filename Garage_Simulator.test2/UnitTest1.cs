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
            //1.Arrange här sätter ni upp det som ska testas, instansierar objekt och inputs
 
            int size = 9;
            Garage<Vehicle> garage = new Garage<Vehicle>(size);
     
            //2.Act här anropar ni metoden som ska testas

            //3.Assert här kontrollerar ni att ni fått det förväntade resultatet

            Assert.That(garage.Space.Length, Is.EqualTo(size));
        }
    }
}