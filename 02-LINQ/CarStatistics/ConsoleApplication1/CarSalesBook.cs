using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApplication1;
using TSD.Linq.Cars;

namespace TSD.Linq.Cars
{
    public class CarSalesBook
    {
        public IList<Car> _cars;

        public CarSalesBook()
        {
            _cars = GenerateCars();
        }

        private IList<Car> GenerateCars()
        {
            List<Car> cars = new List<Car>
            {
                new Car("Skoda") {Sales2015 = 45529, Sales2014 = 44243},
                new Car("Toyota") {Sales2015 = 36465, Sales2014 = 31484},
                new Car("BMW") {Sales2015 = 9549, Sales2014 = 7714}
            };
                
            Car myCar = new Car("Toyota") { NumberOfSeats = 5 };
            myCar.Sales2015 = 9549;
            myCar.Sales2014 = 7714;

            //cars.Add(myCar);

            IList<Car> sortedCars = cars.OrderBy(c => c.Sales2015).ToList();

            return cars;
        }

        public IList<Car> ReadCarsFromFile()
        {
            return CarDataFileReader.ReadCarsFromCSVFile();
        }
    }
}
