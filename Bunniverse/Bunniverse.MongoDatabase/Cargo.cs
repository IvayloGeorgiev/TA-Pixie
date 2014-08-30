namespace Bunniverse.MongoDatabase
{
    using System;
    using MongoDB.Bson;
    public class Cargo
    {
        public ObjectId ShipId { get; set; }

        public ObjectId FoodId { get; set; }

        public int FoodQuantity { get; set; }

    }
}
