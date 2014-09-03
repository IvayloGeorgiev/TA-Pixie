namespace Bunniverse
{
    using Bunniverse.Data;
    using System.IO;
    using System.Linq;
    using System.Xml.Linq;

    internal class XMLReport
    {
        public static void GenerateReports()
        {
            var ctx = new BunniverseEntities();

            // var shipsData = ctx.Ships.Select(ship => new
            // {
            //     ShipID = ship.ShipId,
            //     ShipName = ship.ShipName,
            //     BunniesCount = ship.Bunnies.Count(),
            //     FoodPerDay = ctx.Meals.Join(
            //        ship.Bunnies, meal => meal.Bunny.BunnyId, bunny => bunny.BunnyId, (meal, bunny) => meal)
            //        .GroupBy(b => b.Date)
            //        .Select(g => g.Sum(x => x.FoodQuantity)).First(),
            //     FoodInCargo = ship.Cargoes.Sum(x => x.FoodQuantity)
            // });

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

            // var shipsData3 = ctx.Ships.Join(
            //         ctx.Bunnies, s => s.ShipId, b => b.Ship.ShipId, (s, b) => b.Meals)
            //     );
            var filePath = @"..\..\XML-Reports\shipsXml.xml";
            FileInfo newFile = new FileInfo(filePath);
            if (newFile.Exists)
            {
                newFile.Delete();  // ensures we create a new workbook
                newFile = new FileInfo(filePath);
            }
            XElement shipsXml = new XElement("ships");
            foreach (var ship in shipsData)
            {
                var activity = new XElement("activity");
                foreach (var item in ship.Dates)
                {
                    activity.Add(new XAttribute("date", item.Date), new XAttribute("food-consumed", item.Quantity));
                }
                shipsXml.Add(
                    new XElement("ship", new XAttribute("name", ship.ShipName), new XAttribute("crew-count", ship.BunniesCount), activity));
            }

            System.Console.WriteLine(shipsXml);

            shipsXml.Save(filePath);
        }
    }
}