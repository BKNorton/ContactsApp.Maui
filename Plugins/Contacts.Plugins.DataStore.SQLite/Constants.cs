namespace Contacts.Plugins.DataStore.SQLite
{
    // All the code in this file is included in all platforms.
    public class Constants
    {
        public const string DatabaseFileName = "ContactsSQLite.db3";

        public static string DatabasePath => 
            Path.Combine(FileSystem.AppDataDirectory, DatabaseFileName); 
    }
}