

using System.IO;

namespace accountsClassLibrary_Custom
{
    public static class CustomAplication
    {
        public enum Customers { General, Geotexniki }
            
        public static Customers GetApplication()
        {
            string Customer = "General";
            string path =  @"customization\Customization.txt";
            if (File.Exists(path))
                Customer = File.ReadAllText(path);

            switch (Customer.ToLower())
            {
                case "geotexniki":
                    return Customers.Geotexniki;
                default:
                    return Customers.General;
            }
        }

    }
}
