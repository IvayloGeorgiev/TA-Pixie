namespace Bunniverse
{
    using MongoDB.Bson;
    using MongoDB.Driver;
    using MongoDB.Driver.Builders;
    using MongoDB.Driver.GridFS;
    using MongoDB.Driver.Linq;
    using System;
    using System.Linq;
    using System.Web;
    using Newtonsoft.Json;
    using System.IO;
    using System.Runtime.Serialization.Json;

    class BunniverseEntryPoint
    {
        static void Main(string[] args)
        {
            var bunnyVerse = new BunnyverseEntities();
            var planets = bunnyVerse.Planets.AsQueryable().ToList();
            var ships = bunnyVerse.Ships.AsQueryable();
            var visits = bunnyVerse.Visits.AsQueryable();
            MemoryStream stream = new MemoryStream();
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(Planet));
            foreach (var entityPlanet in planets)
            {
                var planet = new Planet();
                planet.PlanetName = entityPlanet.PlanetName;
                planet.PlanetID = entityPlanet.PlanetID;
                planet.Ships = entityPlanet.Ships;
                planet.X = entityPlanet.X;
                planet.Y = entityPlanet.Y;
                planet.Z = entityPlanet.Z;
                planet.Visits = entityPlanet.Visits;

                ser.WriteObject(stream, planet);
            }
            stream.Position = 0;

            using (StreamReader sr = new StreamReader(stream))
            {
                Console.WriteLine(sr.ReadToEnd());
            }
        }
    }
}
