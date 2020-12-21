namespace FunWithAutomaticProperties
{
    public class Garage
    {
        // The hidden backing field is set to 1.
        public int NumberOfCars { get; set; } = 1;

        // The hidden backing field is set to a new Car object.
        public Car MyAuto { get; set; } = new Car();

        public Garage() { }
        public Garage(Car car, int number)
        {
            MyAuto = car;
            NumberOfCars = number;
        }
    }
}