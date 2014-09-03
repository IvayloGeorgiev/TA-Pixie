namespace Bunniverse
{
    using Bunniverse.Data;
    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Xml.Linq;

    internal class XMLReport
    {
        public static void GenerateReports()
        {
            var ctx = new BunniverseEntities();

            var shipsData = ctx.Ships.Select(ship => new
            {
                ShipName = ship.ShipName,
                BunniesCount = ship.Bunnies.Count(),
                Dates = ctx.Meals.Join(
                   ship.Bunnies, meal => meal.Bunny.BunnyId, bunny => bunny.BunnyId, (meal, bunny) => meal)
                   .GroupBy(b => b.Date)
                   .Select(g => new
                   {
                       Quantity = g.Sum(x => x.FoodQuantity),
                       Date = g.Key
                   })
            });

            var filePath = @"..\..\XML-Reports\shipsXml.xml";
            FileInfo newFile = new FileInfo(filePath);
            if (newFile.Exists)
            {
                newFile.Delete();  // ensures we create a new xml
                newFile = new FileInfo(filePath);
            }

            Console.WriteLine("Building new XML Report: {0}", filePath);

            var shipsXml = new XElement("ships");
            foreach (var ship in shipsData)
            {
                var shipXml = new XElement("ship", new XAttribute("name", ship.ShipName), new XAttribute("crew-count", ship.BunniesCount));
                foreach (var item in ship.Dates)
                {
                    var activity = new XElement("activity");
                    activity.Add(new XAttribute("date", item.Date), new XAttribute("food-consumed", item.Quantity));
                    shipXml.Add(activity);
                }
                shipsXml.Add(shipXml);
            }

            shipsXml.Save(filePath);

            // ...and start a viewer.
            Process.Start(filePath);
        }
    }
}