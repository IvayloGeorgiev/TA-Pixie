namespace Bunniverse
{
    using System;
    using System.Data.OleDb;
    using System.Data;
    using System.Linq;
    using System.IO;
    using System.IO.Compression;

    using Bunniverse.Models;
    using Bunniverse.Data;
    using System.Collections.Generic;

    public class ExcelZipReader
    {
        private string destinationPath;
        private string sourcePath;
        private Dictionary<string, Bunny> bunnyNameToID;
        private Dictionary<string, Food> foodNameToID;

        public ExcelZipReader(string sourcePath, string destinationPath)
        {
            this.sourcePath = sourcePath;
            this.destinationPath = destinationPath;
            bunnyNameToID = new Dictionary<string, Bunny>();
            foodNameToID = new Dictionary<string, Food>();
            InitializeDicionaries();
        }

        /// <summary>
        /// Reads the zip file from source path, extracts all information from its zip files and saves them to the database.
        /// </summary>
        public void ReadExcels()
        {
            this.UnzipArchive();
            string[] excelEntries = Directory.GetDirectories(destinationPath);
            foreach (var directory in excelEntries)
            {
                Console.WriteLine(directory);
                string[] excelFiles = Directory.GetFiles(directory);
                foreach (var path in excelFiles)
                {
                    var data = this.ReadExcel(path);
                    var date = this.ExtractMealDate(path);
                    this.SaveDataToDatabase(data, date);
                }
            }

            this.Cleanup();
        }

        /// <summary>
        /// Initializes dictionaries with keys the names of food/bunny and values - their ids.
        /// </summary>
        private void InitializeDicionaries()
        {
            BunniverseEntities dbContext = new BunniverseEntities();
            using (dbContext)
            {
                var bunnies = dbContext.Bunnies.ToList();
                this.bunnyNameToID = new Dictionary<string, Bunny>();
                foreach (var bunny in bunnies)
                {
                    this.bunnyNameToID.Add(bunny.BunnyName, bunny);
                }

                var foods = dbContext.Foods.ToList();
                this.foodNameToID = new Dictionary<string, Food>();
                foreach (var food in foods)
                {
                    this.foodNameToID.Add(food.FoodName, food);
                }
            }
        }

        /// <summary>
        /// Unzips the given zip file at the specified path.
        /// </summary>
        private void UnzipArchive()
        {
            ZipFile.ExtractToDirectory(sourcePath, destinationPath);
        }

        /// <summary>
        /// Deletes the temp folder where the MealData was stored.
        /// </summary>
        private void Cleanup()
        {
            Directory.Delete(destinationPath, true);
        }

        /// <summary>
        /// Reads the excel file at the given path and returns a DataTable object with its contents.
        /// </summary>
        /// <param name="path">The excel file path</param>
        /// <returns>A DateTable object with all the data from the excel file.</returns>
        private DataTable ReadExcel(string path)
        {
            string conString = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties='Excel 8.0;HDR=Yes'", path);
            OleDbConnection excelCon = new OleDbConnection(conString);
            DataTable data = new DataTable();
            OleDbCommand com = new OleDbCommand("Select * FROM [Meals$]", excelCon);
            using (com)
            {
                OleDbDataAdapter adapter = new OleDbDataAdapter(com);
                using (adapter)
                {
                    adapter.Fill(data);
                }
            }

            return data;
        }

        /// <summary>
        ///  Extracts the date from a given excel file path.
        /// </summary>
        /// <param name="path">The excel file path</param>
        /// <returns>The date contained within</returns>
        private DateTime ExtractMealDate(string path)
        {
            int lastFolderEnd = path.LastIndexOf('\\');
            int startIndex = lastFolderEnd - 1;
            while (path[startIndex] != '\\')
            {
                startIndex--;
            }
            DateTime mealDate = DateTime.Parse(path.Substring(startIndex + 1, lastFolderEnd - startIndex - 1));
            return mealDate;
        }

        /// <summary>
        /// Saves the given meal table data and meal date to the bunnieverse database.
        /// </summary>
        /// <param name="data">Table data holding the bunny name, food name and quantity consumed.</param>
        /// <param name="mealDate">The date on which the meal was consumed.</param>
        private void SaveDataToDatabase(DataTable data, DateTime mealDate)
        {
            BunniverseEntities dbContext = new BunniverseEntities();
            using (dbContext)
            {
                foreach (DataRow row in data.Rows)
                {
                    string bunnyName = (string)row[0];
                    string foodName = (string)row[1];
                    float quantity = float.Parse((string)row[2]);

                    // Add the meal to the database.
                    if (this.bunnyNameToID.ContainsKey(bunnyName) && this.foodNameToID.ContainsKey(foodName))
                    {
                        var bunny = this.bunnyNameToID[bunnyName];
                        var food = this.foodNameToID[foodName];
                        var meal = new Meal() { Bunny = bunny, Food = food, Date = mealDate, FoodQuantity = quantity };
                        dbContext.Meals.Add(meal);
                    }
                }

                dbContext.SaveChanges();
            }
        }
    }
}
