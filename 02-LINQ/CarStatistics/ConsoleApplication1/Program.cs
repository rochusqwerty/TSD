using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using TSD.Linq.Cars;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            CarSalesBook carSalesBook = new CarSalesBook();

            carSalesBook._cars = carSalesBook.ReadCarsFromFile();
            /*
            foreach (var item in carSalesBook._cars)
            {
                Console.WriteLine(item.Make);
            }
            */

            //Top 3
            var top3 = (from item in carSalesBook._cars
                orderby item.Sales2014 descending
                select item).Take(3);

            //least50%
            var least50 = from item in carSalesBook._cars
                           where item.Sales2015 >= item.Sales2014 *1.5 
                           select item;

            //3makesOpens
            var makesOpens = (from item in carSalesBook._cars
                orderby item.Sales2015 descending
                select item).Skip(10).Take(3);

            //total
            var total = from item in carSalesBook._cars
                group item by 1
                into g
                select new
                {
                    SumTotal = g.Sum(x => x.Sales2014),
                    SumDone = g.Sum(x => x.Sales2015)
                };

            //top10last10
            var tmp = from item in carSalesBook._cars
                orderby item.Sales2015 descending
                select item;
            var top10last10 = tmp.Take(10).Concat(tmp.Skip(Math.Max(0, tmp.Count() - 10)));

            //saveToXML
            var filename = "save.xml";
            var currentDirectory = Directory.GetCurrentDirectory();
            var filepath = Path.Combine(currentDirectory, filename);

            var xml = new XElement("Cars", carSalesBook._cars.Select(x => new XElement("Car",
                new XElement("Make", x.Make),
                new XElement("Sales2014", x.Sales2014),
                new XElement("Sales2015", x.Sales2015))));

            xml.Save(filepath);

            //loadFromXML
            XElement loadingElement = XElement.Load(filepath);
            var carsLoad = from item in loadingElement.Descendants("Car")
                select item;

            foreach (var row in carsLoad)
            {
                Console.WriteLine(row.Element("Make").Value + ", " + row.Element("Sales2014").Value + ", " + row.Element("Sales2015").Value);
            }

            Console.WriteLine(carSalesBook._cars.LastOrDefault().Make);

            Console.ReadLine();

        }
    }
}
