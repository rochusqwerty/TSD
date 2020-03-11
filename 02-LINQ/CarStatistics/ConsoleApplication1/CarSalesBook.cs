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
            List<Car> cars = new List<Car>();
            Car car1 = new Car("Skoda");
            car1.Sales2015 = 45529;
            car1.Sales2014 = 44243;

            cars.Add(car1);

            Car car2 = new Car("Toyota");
            car2.Sales2015 = 36465;
            car2.Sales2014 = 31484;

            cars.Add(car2);

            Car car3 = new Car("BMW");
            car3.Sales2015 = 9549;
            car3.Sales2014 = 7714;

            cars.Add(car3);

            Car myCar = new Car("Toyota") { NumberOfSeats = 5 };
            myCar.Sales2015 = 9549;
            myCar.Sales2014 = 7714;

            cars.Add(myCar);

            IList<Car> sortedCars = cars.OrderBy(c => c.Sales2015).ToList();

            return cars;
        }

        public IList<Car> ReadCarsFromFile()
        {
            return CarDataFileReader.ReadCarsFromCSVFile();
        }
    }
}
