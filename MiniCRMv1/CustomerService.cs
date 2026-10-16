namespace MiniCRMv1;

public class CustomerService
{
    List<Customer> _customers = new List<Customer>();
    private int _nextId = 1;

    public void AddCustomer(Customer customer)
    {
        if (string.IsNullOrWhiteSpace(customer.Name))
        {
            Console.WriteLine("Customer name is required.");
            return;
        }

        if (string.IsNullOrWhiteSpace(customer.Email))
        {
            Console.WriteLine("Customer email is required.");
            return;
        }

        if (customer.Age < 0 || customer.Age > 120)
        {
            Console.WriteLine("Customer age is required.");
            return;
        }

        if (customer.Balance < 0)
        {
            Console.WriteLine("Customer balance is required.");
            return;
        }

        if (_customers.Any(c => c.Email == customer.Email))
        {
            Console.WriteLine("Email exists.");
            return;
        }
        
        customer.Id = _nextId;
        _nextId++;

        _customers.Add(customer);
        Console.WriteLine($"Customer added successfully.");
    }

    public IEnumerable<Customer> GetAllCustomers()
    {
        return _customers;
    }
    
    public Customer? GetCustomerByEmail(string email)
    {
        Customer? customer = _customers.FirstOrDefault(c => c.Email == email);
        if (customer is not null)
        {
            return customer;
        }

        return null;
    }

    public Customer? GetCustomerById(int id)
    {
        Customer? customer = _customers.FirstOrDefault(c => c.Id == id);
        if (customer is not null)
        {
            return customer;
        }

        return null;
    }

    public Customer? RemoveCustomer(int Id)
    {
        Customer? customer = _customers.FirstOrDefault(c => c.Id == Id);
        if (customer is not null)
        {
            _customers.Remove(customer);
            return customer;
        }

        return null;
    }
    
    public Customer? UpdateCustomer(int id, Customer updatedCustomer)
    {
        Customer? customer = GetCustomerById(id);
        if (customer is null)
        {
            return null;
        }
        
        if (string.IsNullOrWhiteSpace(updatedCustomer.Name))
        {
            Console.WriteLine("Customer name is required.");
            return null;
        }

        if (string.IsNullOrWhiteSpace(updatedCustomer.Email))
        {
            Console.WriteLine("Customer email is required.");
            return null;
        }

        if (updatedCustomer.Age < 0 || updatedCustomer.Age > 120)
        {
            Console.WriteLine("Customer age is required.");
            return null;
        }

        if (updatedCustomer.Balance < 0)
        {
            Console.WriteLine("Customer balance is required.");
            return null;
        }

        if (_customers.Any(c => c.Email == updatedCustomer.Email && c.Id != id))
        {
            Console.WriteLine("Email exists.");
            return null;
        }
        
        customer.Name = updatedCustomer.Name;
        customer.Email = updatedCustomer.Email;
        customer.Age = updatedCustomer.Age;
        customer.City = updatedCustomer.City;
        customer.Balance = updatedCustomer.Balance;
        Console.WriteLine($"Customer with Id {customer.Id} has been updated.");
        return customer;
    }
}



















