namespace AppLinq;

public class Customer
{
    public string Name { get; set; }
    public string Email { get; set; }
    public int Age { get; set; }
    public List<Purchase> PurchaseHistory { get; set; }

}

public class Purchase 
{
    public DateTime Date { get; set; }
    public decimal Amount { get; set; }

}