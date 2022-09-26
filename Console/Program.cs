using BusinessDomain;

List<Product> products = new()
{
    new("Banan", 2.5),
    new("Fanta", 13),
    new("Candy", 1)
};
List<Customer> customers = new();

Console.WriteLine("Velkommen til mit program");
while (true)
{
    Console.WriteLine("Hvordan vil du fortsætte?\n1. Køb ind\n2. Tilføj ny bruger (Admin)\n3. Opret nyt produkt (Admin)\n4. Afslut");
    ConsoleKey inputKey = Console.ReadKey().Key;
    if (inputKey == ConsoleKey.D1)
    {
        Console.WriteLine("\nSkriv navn på bruger du vil købe ind som");
        string user = Console.ReadLine();
        Customer chosenCustomer;
        foreach(Customer customer in customers)
        {
            chosenCustomer = customer;
            if (customer.Name == user)
            {
                while (true)
                {

                    Console.WriteLine("Hvad vil du købe?");
                    for(int i = 0; i < products.Count; i++)
                    {
                        Console.WriteLine($"{products[i].Name}: {products[i].Price} Kr.");
                    }
                    string productName = Console.ReadLine();
                    foreach (Product product in products)
                    {
                        if (productName.ToLower() == product.Name.ToLower())
                        {
                            Console.WriteLine("Hvor mange vil du købe?");
                            int numberOfProducts = Convert.ToInt32(Console.ReadLine());
                            if (numberOfProducts > 0)
                            {
                                for(int i = 0; numberOfProducts > i; i++)
                                {
                                    chosenCustomer.Basket.Products.Add(product);
                                    chosenCustomer.Basket.TotalPrice += chosenCustomer.Basket.Products[i].Price;
                                }
                                Console.WriteLine("Pris: " + (chosenCustomer.Basket.TotalPrice - (chosenCustomer.Basket.TotalPrice * chosenCustomer.CustomerType.Discount / 100)));
                                Console.WriteLine("Pris inkl moms: " + ((chosenCustomer.Basket.TotalPrice - (chosenCustomer.Basket.TotalPrice * chosenCustomer.CustomerType.Discount / 100)) * 1.25));
                                if (!(Continue()))
                                {
                                    goto BREAKLOOP;
                                }
                            }
                            else
                            {
                                Console.WriteLine("Man kan ikke købe produkter i minus");
                            }
                        }
                    }
                }
            BREAKLOOP:
                continue;
            }
            else
            {
                Console.WriteLine("Den bruger findes ikke\n");
            }
        }
    }
    if (inputKey == ConsoleKey.D2)
    {
        if (LogIn())
        {
            while (true)
            {
                Console.WriteLine("Indtast navn");
                string name = Console.ReadLine();
                Console.WriteLine("Indtast mail");
                string mail = Console.ReadLine();
                inputKey = ConsoleKey.G;
                while(!(inputKey == ConsoleKey.D1 || inputKey == ConsoleKey.D2 || inputKey == ConsoleKey.D3))
                {
                    Console.WriteLine("Vil du købe et bedre medlemskab?\n1. Køb Premium for 150 DKK/m (Modtag 2.45% Rabat)\n2. Køb Gold for 350 DKK/m (Modtag 6.25% Rabat)\n3. Fortsæt som basiskunde");
                    inputKey = Console.ReadKey().Key;
                }
                CustomerTypes customerType;
                if (inputKey == ConsoleKey.D1)
                {
                    customerType = CustomerTypes.Premium;
                }
                else if (inputKey == ConsoleKey.D2)
                {
                    customerType = CustomerTypes.Gold;
                }
                else if (inputKey == ConsoleKey.D3)
                {
                    customerType = CustomerTypes.Basis;
                }
                else
                {
                    customerType = CustomerTypes.Basis;
                }
                try
                {
                    Customer customer = new(name, mail, customerType, new(0, new()));
                    customers.Add(customer);
                    Console.WriteLine("Kunde tilføjet!");
                    if (!(Continue()))
                    {
                        break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Fejl: {ex.Message}. Prøv igen!\n");
                }
            }
        }
        else
        {
            break;
        }
    }
    if (inputKey == ConsoleKey.D3)
    {
        if (LogIn())
        {
            while (true)
            {
                Console.WriteLine("Indtast navnet på produktet");
                string productName = Console.ReadLine();
                Console.WriteLine("Indtast prisen på produktet");
                double productPrice = Convert.ToDouble(Console.ReadLine());
                try
                {
                    Product product = new(productName, productPrice);
                    products.Add(product);
                    Console.WriteLine("Produkt tilføjet!");
                    if (!(Continue()))
                    {
                        break;
                    }
                }
                catch(Exception e)
                {
                    Console.WriteLine($"Fejl: {e.Message}. Prøv igen!\n");
                }
            }
        }
        else
        {
            break;
        }
    }
    if (inputKey == ConsoleKey.D4)
    {
        break;
    }
}

#region Methods
bool Continue()
{
    bool continueOutput = false;
    while (true)
    {
        Console.WriteLine("Vil du tilføje flere / mere? [J/N]");
        ConsoleKey inputKey = Console.ReadKey().Key;
        if (inputKey == ConsoleKey.J)
        {
            continueOutput = true;
            break;
        }
        else if (inputKey == ConsoleKey.N)
        {
            break;
        }
    }
    return continueOutput;
}

bool LogIn()
{
    Console.WriteLine("\nIndtast admin kodeordet");
    string password = Console.ReadLine();
    if (password == "123")
    {
        Console.WriteLine("Korrekt password!\n");
        return true;
    }
    else
    {
        Console.WriteLine("Forkert password!\n");
        return false;
    }
} 
#endregion