using BusinessDomain;

#region Products
List<Product> products = new();

Product product1 = new("Banan", 2.5);
Product product2 = new("Fanta", 13);
Product product3 = new("Candy", 1);

products.Add(product1);
products.Add(product2);
products.Add(product3);
#endregion

#region Baskets
Basket basket1 = new(0, new());
Basket basket2 = new(0, new());
Basket basket3 = new(0, new());
#endregion

#region Customers
List<Customer> customers = new();

Customer customer1 = new("Jens Andersen", "ja@gmail.com", basket1);
Customer customer2 = new("Jesper Audisen", "jema@aspit.dk", basket2);
Customer customer3 = new("Vladimir Vodka", "Putin@Russia.net", basket3);

customers.Add(customer1);
customers.Add(customer2);
customers.Add(customer3);
#endregion

Customer chosenCustomer;
while (true)
{
    Console.WriteLine("Hvem vil du købe som?\nTryk E for at slutte\n\n");
    {
        for (int i = 0; i < customers.Count; i++)
        {
            Console.WriteLine($"{i + 1}: {customers[i].Name}");
        }
        ConsoleKey inputKey = Console.ReadKey().Key;
        if (inputKey == ConsoleKey.E)
        {
            goto breakloops;
        }
        else if (inputKey == ConsoleKey.D1)
        {
            chosenCustomer = customer1;
        }
        else if (inputKey == ConsoleKey.D2)
        {
            chosenCustomer = customer2;
        }
        else if (inputKey == ConsoleKey.D3)
        {
            chosenCustomer = customer3;
        }
        else
        {
            break;
        }
        while (true)
        {
            Console.WriteLine("\nHvad vil du lægge i din indkøbskurv?\nTryk E for at slutte\n\n");
            for (int i = 0; i < products.Count; i++)
            {
                Console.WriteLine($"{i + 1}: {products[i].Name}");
            }
            inputKey = Console.ReadKey().Key;
            if (inputKey == ConsoleKey.E)
            {
                goto breakloops;
            }
            else if (inputKey == ConsoleKey.D1)
            {
                chosenCustomer.Basket.Products.Add(product1);
            }
            else if (inputKey == ConsoleKey.D2)
            {
                chosenCustomer.Basket.Products.Add(product2);
            }
            else if (inputKey == ConsoleKey.D3)
            {
                chosenCustomer.Basket.Products.Add(product3);
            }
            else
            {
                break;
            }

            double totalPrice = 0;
            for (int i = 0; i < chosenCustomer.Basket.Products.Count; i++)
            {
                totalPrice = totalPrice + chosenCustomer.Basket.Products[i].Price;
            }
            Console.WriteLine($"\nTotalpris: {totalPrice}");
            Console.WriteLine($"Totalpris + moms: {totalPrice * 1.25}\n");

            Console.WriteLine("Vil du stoppe med at købe?\n");
            inputKey = Console.ReadKey().Key;
            if (inputKey == ConsoleKey.J)
            {
                break;
            }
        }
    }
breakloops:
    break;
}