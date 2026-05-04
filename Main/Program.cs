using System.Xml.Serialization;
using System;
using Main;
internal class Program
{
    private static void Main(string[] args)
    {
        string path = "C:\\Users\\elise\\OneDrive\\УНИК\\2Курс\\2\\ЯП\\kt3\\lab8\\Main\\DB.bin";
        int x = 0;
        bool loop = true;
        string str = "0";

        List<Product> list = new List<Product>();
        List<Product> list2 = new List<Product>();
        Product products = new Product();
        StoreManager storeManager = new StoreManager();

        //list.Add(products);

        //StoreManager storeManager = new StoreManager();
        //storeManager.GenBin(path, list);
        Console.WriteLine("МАГАЗИН 'Местный'");
        while (loop)
        {
            Console.WriteLine("\nВведите цифры:\n1 - Показать всё\n2 - Добавить\n3 - Удалить");
            Console.WriteLine("4 - Товары в наличии\n5 - Отсортировать по цене\n6 - Минимальная цена");
            Console.WriteLine("7 - Максимальная цена\n0 - Завершение программы");
            Console.Write("Ввод: ");
            x = Enter();

            switch (x)
            {
                case 0:
                    loop = false;
                    break;
                case 1:
                    list = storeManager.ReadBin(path);
                    foreach (var i in list)
                    {
                        Console.WriteLine(i.ToString());
                    }
                    break;
                case 2:
                    list = storeManager.ReadBin(path);

                    Console.Write("Введите ID: ");
                    int id = Enter();
                    Console.Write("Введите имя товара: ");
                    string name = Console.ReadLine();
                    Console.Write("Введите цену: ");
                    int price = Enter();
                    Console.Write("Введите наличие(0 - нет, 1 - есть): ");
                    bool availability = EnterT_F();
                    Console.Write("Введите категорию: ");
                    string category = Console.ReadLine();
                    Product newP = new Product(id, name, price, availability, category);
                        
                    storeManager.AddProducts(list, newP);
                    storeManager.GenBin(path, list);
                    break;
                case 3:
                    Console.Write("Введите ID товара: ");
                    x = Enter();
                    list = storeManager.ReadBin(path);

                    storeManager.RemoveProducts(list, x);
                    storeManager.GenBin(path, list);
                    break;
                case 4:
                    list = storeManager.ReadBin(path);

                    list2 = storeManager.GetProducts(list);
                    foreach (var i in list2)
                    {
                        Console.WriteLine(i);
                    }
                    break;
                case 5:
                    list = storeManager.ReadBin(path);
                    list2 = storeManager.GetSort(list);
                    foreach (var i in list2)
                    {
                        Console.WriteLine(i);
                    }
                    break;
                case 6:
                    list = storeManager.ReadBin(path);
                    str = storeManager.GetMin(list);
                    Console.WriteLine(str);
                    break;
                case 7:
                    list = storeManager.ReadBin(path);
                    str = storeManager.GetMax(list);
                    Console.WriteLine(str);
                    break;
            }
        }
    }
    private static int Enter()
    {
        int x;
        while (!int.TryParse(Console.ReadLine(), out x))
        {
            Console.WriteLine("Ошибка ввода, повторите попытку!");
            Console.Write("Ввод: ");
        }

        return x;
    }
    private static bool EnterT_F()
    {
        int x = 0;
        bool b = false;
        while(x != 100)
        {
            while (!int.TryParse(Console.ReadLine(), out x))
            {
                Console.WriteLine("Ошибка ввода, повторите попытку!");
                Console.Write("Ввод: ");
            }
            if (x == 0)
            {
                b = false;
                x = 100;
            }
            if (x == 1)
            {
                b = true;
                x = 100;
            }
            else
            {
                Console.WriteLine("Введите '0' или '1'");
            }
        }
        return b;
        
    }
}