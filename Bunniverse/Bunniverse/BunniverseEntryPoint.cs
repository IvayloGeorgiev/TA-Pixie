namespace Bunniverse
{
    using System.Collections.Generic;
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
    using Bunniverse.Models;
    using MongoDB.Bson.Serialization;
    using Bunniverse.Contracts;
    using Bunniverse.MongoDatabase;

    class BunniverseEntryPoint
    {
        static void Main(string[] args)
        {
            //var dbFactory = new BunniverseFactory();
            //dbFactory.GenerateMongoData();

            //IMongoDBToSQLConverter sqlConverter = new MongoDBToSQLConverter();
            //sqlConverter.ConvertMongoToSQL();

            //IXMLParser xmlParser = new XMLParser();
            //xmlParser.ParseXML();

            //var zipReader = new ExcelZipReader("..\\..\\..\\Files\\MealsData.zip", "..\\..\\..\\Files\\Temp");
            //zipReader.ReadExcels();

            JsonReporter jsonReport = new JsonReporter("..\\..\\..\\");
            jsonReport.GenerateReport();
            //AstrogationPDFReport.GenerateReports();
            //XMLReport.GenerateReports();            
            // MySqlDatabase.MySqlCreator.CreateDatabase();
            // Excell2007ReportGenerator.GenerateExcell2007Report();
        }
    }
}