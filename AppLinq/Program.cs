//Task 1

using System.Text.RegularExpressions;
using AppLinq;

// Console.WriteLine("Task 1");
// List<string> words = new List<string> { "apple", "banana", "orange", "grape", "mango" };
//
// var result = words.OrderByDescending(x=>x.Length).FirstOrDefault();
//
// Console.WriteLine(result); 
//

/////////////////////////////////////////////////////


// //Task 2
// Console.WriteLine("Task 2");
//
//  List<Person> people = new List<Person> {
//     new Person { Name = "Alice", Age = 31, IsStudent = true },
//     new Person { Name = "Bob", Age = 30, IsStudent = false },
//     new Person { Name = "Charlie", Age = 25, IsStudent = true },
//     new Person { Name = "Dave", Age = 35, IsStudent = false },
//     new Person { Name = "Eve", Age = 28, IsStudent = true } 
// };
// //method
// var query2 = people.Where(x => x.IsStudent == true).Average(x => x.Age);
//
// Console.WriteLine(query2);


///////////////////////////////////////////////////////////////////////////////////
// Task 3
// List<Customer> customers = new List<Customer> {
//     new Customer {
//         Name = "Alice",
//         Email = "alice@example.com",
//         Age = 25,
//         PurchaseHistory = new List<Purchase> {
//             new Purchase { Date = new DateTime(2022, 1, 1), Amount = 100.00M },
//             new Purchase { Date = new DateTime(2022, 2, 1), Amount = 50.00M },
//             new Purchase { Date = new DateTime(2022, 3, 1), Amount = 75.00M }
//         }
//     },    new Customer {
//         Name = "Bob",
//         Email = "bob@example.com",
//         Age = 35,
//         PurchaseHistory = new List<Purchase> {
//             new Purchase { Date = new DateTime(2022, 1, 1), Amount = 150.00M },
//             new Purchase { Date = new DateTime(2022, 2, 1), Amount = 75.00M },
//             new Purchase { Date = new DateTime(2022, 3, 1), Amount = 125.00M }
//         }
//     },
//     new Customer {
//         Name = "Charlie",
//         Email = "charlie@example.com",
//         Age = 30,
//         PurchaseHistory = new List<Purchase> {
//             new Purchase { Date = new DateTime(2022, 1, 1), Amount = 75.00M },
//             new Purchase { Date = new DateTime(2022, 2, 1), Amount = 125.00M },
//             new Purchase { Date = new DateTime(2022, 3, 1), Amount = 150.00M }
//         }
//     }
// };
//
// var queryCustomer = (from c in customers
//     select new 
//     {
//         Name = c.Name,
//         Email = c.Email,
//         Age = c.Age,
//         PurchaseHistory = c.PurchaseHistory.Sum(x=>x.Amount)
//     }).OrderByDescending(x=>x.PurchaseHistory).Take(5); 
//
// Console.WriteLine("Task 3");
// foreach (var q in queryCustomer)
// {
//     Console.WriteLine($"  {q.Name}  {q.Email}  {q.Age}  {q.PurchaseHistory}" ); 
// }


List<Product> products = new List<Product>
{
    new Product { Id = 1, Name = "Product A", Price = 10.00M, CategoryId = 1 },
    new Product { Id = 2, Name = "Product B", Price = 20.00M, CategoryId = 1 },
    new Product { Id = 3, Name = "Product C", Price = 30.00M, CategoryId = 2 },
    new Product { Id = 4, Name = "Product D", Price = 40.00M, CategoryId = 2 },
};

List<Category> categories = new List<Category>
{
    new Category { Id = 1, Name = "Category A" },
    new Category { Id = 2, Name = "Category B" },
};

List<Sale> sales = new List<Sale>
{
    new Sale { ProductId = 1, Date = new DateTime(2022, 1, 1), Quantity = 2 },
    new Sale { ProductId = 2, Date = new DateTime(2022, 1, 1), Quantity = 1 },
    new Sale { ProductId = 2, Date = new DateTime(2022, 2, 1), Quantity = 3 },
    new Sale { ProductId = 3, Date = new DateTime(2022, 2, 15), Quantity = 1 },
    new Sale { ProductId = 3, Date = new DateTime(2022, 3, 1), Quantity = 2 },
    new Sale { ProductId = 4, Date = new DateTime(2022, 3, 1), Quantity = 3 },
};

var query = from c in categories
    join p in products on c.Id equals p.CategoryId 
    join s in sales on p.Id equals s.ProductId 
    group s by c.Name  into gr 
    select new  
    {
        Category = gr.Key,  
        Quantity = gr.Sum(x => x.Quantity)
    };
Console.WriteLine("Task 4");
foreach (var q in query)
{
    Console.WriteLine($"{q.Category} {q.Quantity} "); 
}
