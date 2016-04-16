namespace MvcArtStone.Repository
{
    public class DatabaseHelper
    {
        private static string _connectionString;

        public string GetConnectionString()
        {
            if (!string.IsNullOrEmpty(_connectionString))
                return _connectionString;

            _connectionString =
                "";
            return _connectionString;
        }
    }
}
