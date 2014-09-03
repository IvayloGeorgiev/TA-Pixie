namespace Bunniverse.MySqlDatabase
{
    using Bunniverse.Data;
    using Telerik.OpenAccess;

    class MySqlCreator
    {       
        public static void CreateDatabase()
        {
            using (var context = new MySqlEntities())
            {                
                var schemaHandler = context.GetSchemaHandler();
                EnsureDB(schemaHandler);
            }
        }

        private static void EnsureDB(ISchemaHandler schemaHandler)
        {
            string script = null;
            if (schemaHandler.DatabaseExists())
            {
                schemaHandler.ExecuteDDLScript(string.Format("TRUNCATE TABLE {0}", "ShipsTravel"));
            }
            else
            {
                schemaHandler.CreateDatabase();
                script = schemaHandler.CreateDDLScript();
            }

            if (!string.IsNullOrEmpty(script))
            {
                schemaHandler.ExecuteDDLScript(script);
            }
        }
    }
}
