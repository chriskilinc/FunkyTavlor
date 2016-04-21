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
                "DefaultEndpointsProtocol=https;AccountName=t4boys2016;AccountKey=fo02pXwYf4RxEvWA/cElvgz/OYdvqoniVuzAJ/7odeXLcVtoh+MFTmpzz3JT3uUrTxyF/gkbKdtv6c8ILMJ2hg==";
            return _connectionString;
        }
    }
}
