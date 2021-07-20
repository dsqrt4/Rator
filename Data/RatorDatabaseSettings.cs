namespace Rator.Data
{
    public class RatorDatabaseSettings : IRatorDatabaseSettings
    {
        public string ToDosCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IRatorDatabaseSettings
    {
        string ToDosCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}