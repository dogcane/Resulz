using Resulz.Samples.Domain;
using System;
using System.Linq;

namespace Resulz.Samples
{
    class Program
    {
        static void Main(string[] args)
        {
            var loanService = new LoanService();
            var customerResult = Customer.CreateNewCustomer("John Doe", "65th Street, New York", new DateTime(1980, 1, 12));
            if (customerResult.Success)
            {
                Console.WriteLine("CUSTOMER CREATED:");
                Console.WriteLine(customerResult.Value);
                Console.WriteLine("");
                for (int i = 0; i < 3; i++)
                {
                    customerResult.Value.UpgradeLevel()
                    .IfSuccess((result) =>
                    {
                        Console.WriteLine("LEVEL UPGRADED:");
                        Console.WriteLine(customerResult.Value);
                        Console.WriteLine(result.Value);
                        Console.WriteLine("");
                    })
                    .IfFailed((result) =>
                    {
                        Console.WriteLine("LEVEL UPGRADE FAILED:");
                        result.Errors.ToList().ForEach(err => Console.WriteLine($"Error : {err.Context} - Message : {err.Description}"));
                        Console.WriteLine(customerResult.Value);
                        Console.WriteLine("");
                    });
                    loanService.GiveLoanToCustomer(customerResult.Value, 100m)
                        .IfSuccess((result) =>
                        {
                            Console.WriteLine("SUCCESS : LOAN OF 100$");
                            Console.WriteLine("");
                        })
                        .IfFailed((result) =>
                        {
                            Console.WriteLine("FAILED : LOAN OF 100$");
                            result.Errors.ToList().ForEach(err => Console.WriteLine($"Error : {err.Context} - Message : {err.Description}"));
                            Console.WriteLine("");
                        });
                }                
            }           


            Console.WriteLine("Press to exit...");
            Console.ReadLine();
        }
    }
}
