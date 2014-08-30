namespace Bunniverse.MongoDatabase
{
    using System;
    using MongoDB.Bson;
    public class Cargo
    {
        public ObjectId Id { get; set; }

        public Ship Ship { get; set; }

        public Food Food { get; set; }

        public int FoodQuantity { get; set; }

    }
}
