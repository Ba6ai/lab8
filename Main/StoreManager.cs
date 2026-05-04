using System.Linq;

namespace Main
{
    internal class StoreManager
    {
        public void GenBin(string path, List<Product> products)
        {
            try
            {
                BinaryWriter writer = new BinaryWriter(File.Open(path, FileMode.Create));

                writer.Write(products.Count);
                foreach (Product item in products)
                {
                    writer.Write(item.ID);
                    writer.Write(item.Name);
                    writer.Write(item.Price);
                    writer.Write(item.Availability);
                    writer.Write(item.Category);
                }
                writer.Close();
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                return;
            }
        }
        public List<Product> ReadBin(string path)
        {
            List<Product> products = new List<Product>();
            try
            {
                BinaryReader reader = new BinaryReader(File.Open(path,FileMode.Open));
                int count = reader.ReadInt32();
                
                for (int i = 0; i < count; i++)
                {
                    int id = reader.ReadInt32();
                    string name = reader.ReadString();
                    int price = reader.ReadInt32();
                    bool availability = reader.ReadBoolean();
                    string category = reader.ReadString();

                    Product p = new Product(id, name, price, availability, category);
                    products.Add(p);
                }
                reader.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine (e);
                return null;
            }
            return products;
        }

        public List<Product> GetProducts(List<Product> products)
        {
            return products.Where(x => x.Availability == true).ToList();
        }

        public List<Product> GetSort(List<Product> products)
        {
            return products.OrderBy(x => x.Price).ToList();
        }

        public string GetMax(List<Product> products)
        {
            return products.Max(x => x.Price).ToString();
        }

        public string GetMin(List<Product> products)
        {
            return products.Min(x  => x.Price).ToString();
        }

        public void AddProducts(List<Product> products, Product item)
        {
            products.Add(item);
        }

        public void RemoveProducts(List<Product> products, int targetID)
        {
            products.RemoveAll(x => x.ID == targetID);
        }
    }
}
