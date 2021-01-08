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

            CreateCustomerAndGiveLoan("John Doe", "65th Street, New York", new DateTime(1980, 1, 12), 100m, 3, loanService);
            CreateCustomerAndGiveLoan("", "65th Street, New York", new DateTime(1980, 1, 12), 100m, 3, loanService);

            Console.WriteLine("Press to exit...");
            Console.ReadLine();
        }

        private static void CreateCustomerAndGiveLoan(string name, string address, DateTime birthday, decimal loanAmount, int loanRequests, ILoanService loanService)
        {
            Console.WriteLine("================================================================");
            Console.WriteLine("================================================================");
            var customerResult = Customer.CreateNewCustomer(name, address, birthday)
                .IfSuccess((result) =>
                {
                    var customer = result.Value;
                    Console.WriteLine("CUSTOMER CREATED:");
                    Console.WriteLine(customer);
                    Console.WriteLine("================================================================");
                    Console.WriteLine("");                    
                    for (int i = 0; i < loanRequests; i++)
                    {
                        customer.UpgradeLevel()
                        .IfSuccess((result) =>
                        {
                            Console.WriteLine("LEVEL UPGRADED:");
                            Console.WriteLine(customer);
                            Console.WriteLine(result.Value);
                            Console.WriteLine("================================================================");
                            Console.WriteLine("");                            
                        })
                        .IfFailed((result) =>
                        {
                            Console.WriteLine("LEVEL UPGRADE FAILED:");
                            result.Errors.ToList().ForEach(err => Console.WriteLine(err));
                            Console.WriteLine(customer);
                            Console.WriteLine("================================================================");
                            Console.WriteLine("");
                        });
                        loanService.GiveLoanToCustomer(customer, loanAmount)
                            .IfSuccess((result) =>
                            {
                                Console.WriteLine($"SUCCESS : LOAN OF {loanAmount:N2}");
                                Console.WriteLine("================================================================");
                                Console.WriteLine("");
                            })
                            .IfFailed((result) =>
                            {
                                Console.WriteLine($"FAILED : LOAN OF {loanAmount:N2}");
                                result.Errors.ToList().ForEach(err => Console.WriteLine(err));
                                Console.WriteLine("================================================================");
                                Console.WriteLine("");
                            });
                    }
                })
                .IfFailed((result) =>
                {
                    Console.WriteLine("CUSTOMER CREATION FAILED");
                    result.Errors.ToList().ForEach(err => Console.WriteLine(err));
                    Console.WriteLine("================================================================");
                    Console.WriteLine("");
                });
            Console.WriteLine("");
        }

    }    
    
}
