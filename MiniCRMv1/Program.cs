using MiniCRMv1;
CustomerService customerService = new();
Console.WriteLine("===== MINI CRM =====");
while (true)
{
    ShowMenu();
    
    var input = Console.ReadLine();
    switch (input)
    {
        case "1":
            AddCustomer(customerService);
            break;
        case "2":
            ShowAllCustomers(customerService);
            break;
        case "3":
            FindCustomerById(customerService);
            break;
        case "4":
            FindCustomerByEmail(customerService);
            break;
        case "5":
            UpdateCustomer(customerService);
            break;
        case "6":
            RemoveCustomer(customerService);
            break;
        case "0":
            Console.WriteLine("Goodbye!");
            return;
        default:
            Console.WriteLine("Invalid option.");
            break;
    }
}

static void ShowMenu()
    {
        Console.WriteLine();
        Console.WriteLine("===== MINI CRM =====");
        Console.WriteLine("1. Add customer");
        Console.WriteLine("2. Show all customers");
        Console.WriteLine("3. Find customer by ID");
        Console.WriteLine("4. Find customer by email");
        Console.WriteLine("5. Update customer");
        Console.WriteLine("6. Remove customer");
        Console.WriteLine("0. Exit");
        Console.Write("Choose option: ");
    }
    
    static void AddCustomer(CustomerService customerService)
    {
        Console.Write("Enter customer name: ");
        string? name = Console.ReadLine();

        Console.Write("Enter customer email: ");
        string? email = Console.ReadLine();

        Console.Write("Enter customer age: ");

        if (!int.TryParse(Console.ReadLine(), out int age))
        {
            Console.WriteLine("Invalid age.");
            return;
        }

        Console.Write("Enter customer city: ");
        string? city = Console.ReadLine();

        Console.Write("Enter customer balance: ");

        if (!decimal.TryParse(Console.ReadLine(), out decimal balance))
        {
            Console.WriteLine("Invalid balance.");
            return;
        }

        Customer customer = new()
        {
            Name = name,
            Email = email,
            Age = age,
            City = city,
            Balance = balance
        };

        customerService.AddCustomer(customer);
    }
    
    static void ShowAllCustomers(CustomerService customerService)
    {
        IEnumerable<Customer> customers = customerService.GetAllCustomers();

        if (!customers.Any())
        {
            Console.WriteLine("No customers found.");
            return;
        }

        foreach (Customer customer in customers)
        {
            PrintCustomer(customer);
        }
    }
    
    static void PrintCustomer(Customer customer)
    {
        Console.WriteLine("--------------------");
        Console.WriteLine($"ID: {customer.Id}");
        Console.WriteLine($"Name: {customer.Name}");
        Console.WriteLine($"Email: {customer.Email}");
        Console.WriteLine($"Age: {customer.Age}");
        Console.WriteLine($"City: {customer.City}");
        Console.WriteLine($"Balance: {customer.Balance}");
        Console.WriteLine("--------------------");
    }
    
    static void FindCustomerById(CustomerService customerService)
    {
        Console.Write("Enter customer ID: ");

        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            Console.WriteLine("Invalid ID.");
            return;
        }

        Customer? customer = customerService.GetCustomerById(id);

        if (customer is null)
        {
            Console.WriteLine("Customer not found.");
            return;
        }

        PrintCustomer(customer);
    }
    
    static void FindCustomerByEmail(CustomerService customerService)
    {
        Console.Write("Enter customer email: ");
        string? email = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(email))
        {
            Console.WriteLine("Email is required.");
            return;
        }

        Customer? customer = customerService.GetCustomerByEmail(email);

        if (customer is null)
        {
            Console.WriteLine("Customer not found.");
            return;
        }

        PrintCustomer(customer);
    }
    
    static void UpdateCustomer(CustomerService customerService)
    {
        Console.Write("Enter customer ID: ");

        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            Console.WriteLine("Invalid ID.");
            return;
        }

        Console.Write("Enter new name: ");
        string? name = Console.ReadLine();

        Console.Write("Enter new email: ");
        string? email = Console.ReadLine();

        Console.Write("Enter new age: ");

        if (!int.TryParse(Console.ReadLine(), out int age))
        {
            Console.WriteLine("Invalid age.");
            return;
        }

        Console.Write("Enter new city: ");
        string? city = Console.ReadLine();

        Console.Write("Enter new balance: ");

        if (!decimal.TryParse(Console.ReadLine(), out decimal balance))
        {
            Console.WriteLine("Invalid balance.");
            return;
        }

        Customer updatedCustomer = new()
        {
            Name = name,
            Email = email,
            Age = age,
            City = city,
            Balance = balance
        };

        Customer? updated = customerService.UpdateCustomer(id, updatedCustomer);

        if (updated is null)
        {
            Console.WriteLine("Customer was not updated.");
            return;
        }

        Console.WriteLine("Customer updated successfully.");
        PrintCustomer(updated);
    }
    
    static void RemoveCustomer(CustomerService customerService)
    {
        Console.Write("Enter customer ID: ");

        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            Console.WriteLine("Invalid ID.");
            return;
        }

        Customer? removed = customerService.RemoveCustomer(id);

        if (removed is null)
        {
            Console.WriteLine("Customer was not removed.");
            return;
        }

        Console.WriteLine($"Customer with ID {removed.Id} has been removed.");
    }

