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
                "DefaultEndpointsProtocol=https;AccountName=artstone;AccountKey=Tb+NOz2SZ9VWexTIVJsXvHrpk3FWW2VF9QOUjU6eM9OaxkAaXF08jdSJ2n4JKHtpFmQ93omO1tL6q/VmkjASpw==";
            return _connectionString;
        }
    }
}
