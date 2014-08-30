namespace Bunniverse.Models
{
    using System;
    using System.Data.OleDb;
    using System.Data;    
    using System.Linq;
    using System.IO;
    using System.IO.Compression;

    public class ExcelZipReader
    {
        private const string DestinationPath = "MealsData";
        private string sourcePath;        

        public ExcelZipReader(string sourcePath)
        {
            this.sourcePath = sourcePath;
        }        

        public void FillFramework()
        {
            UnzipArchive();
            string[] excelEntries = Directory.GetDirectories(DestinationPath);
            foreach (var directory in excelEntries)
            {
                Console.WriteLine(directory);
                string[] excelFiles = Directory.GetFiles(directory);
                foreach (var path in excelFiles)
                {                                        
                    ReadExcel(path);
                }
            }
            Cleanup();
        }

        private void UnzipArchive()
        {
            ZipFile.ExtractToDirectory(sourcePath, DestinationPath);
        }

        private void Cleanup()
        {
            Directory.Delete(DestinationPath, true);
        }

        private void ReadExcel(string path)
        {
            string conString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + ";Extended Properties='Excel 8.0;HDR=Yes'";
            string[] splitPath = path.Split(new char[] { '\\' }, StringSplitOptions.RemoveEmptyEntries);
            DateTime mealDate = DateTime.Parse(splitPath[splitPath.Length - 2]);
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
            
            foreach (DataRow row in data.Rows)
            {
                string bunnyName = (string)row[0];
                string foodName = (string)row[1];
                float quantity = float.Parse((string)row[2]);
                Console.WriteLine(bunnyName + " " + foodName + " " + quantity + " " + mealDate.ToString("dd-MMM-yyyy"));
                // TODO: Call to EF here.
            } 
        }
    }
}
