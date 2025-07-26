using Resulz;
using Resulz.Samples.Domain;
using System;
using System.Linq;


var loanService = new LoanService();

CreateCustomerAndGiveLoan("John Doe", "65th Street, New York", new DateTime(1980, 1, 12), 100m, 3, loanService);
CreateCustomerAndGiveLoan("", "65th Street, New York", new DateTime(1980, 1, 12), 100m, 3, loanService);
DemonstrateFluentChaining("Jane Smith", "42nd Street, New York", new DateTime(1985, 5, 15), 250m, loanService);

Console.WriteLine("Press to exit...");
Console.ReadLine();

static void DemonstrateFluentChaining(string name, string address, DateTime birthday, decimal loanAmount, ILoanService loanService)
{
    // Demonstrate fluent chaining with Then methods
    Console.WriteLine("================================================================");
    Console.WriteLine("FLUENT CHAINING EXAMPLE WITH Then METHODS:");
    Console.WriteLine("================================================================");
    // Example 1: Simple operation chaining
    Console.WriteLine("Example 1: Simple operation chaining");
    var simpleChain = OperationResult.MakeSuccess()
        .Then(() => 
        {
            Console.WriteLine("✓ Step 1: Initial operation successful");
            return OperationResult.MakeSuccess();
        })
        .Then(() => 
        {
            Console.WriteLine("✓ Step 2: Second operation successful");
            return OperationResult.MakeSuccess();
        })
        .Then(() => 
        {
            Console.WriteLine("✓ Step 3: Final operation successful");
            return OperationResult.MakeSuccess();
        });

    if (simpleChain.Success)
    {
        Console.WriteLine("✓ Simple chain completed successfully!");
    }
    else
    {
        Console.WriteLine("✗ Simple chain failed.");
    }
    Console.WriteLine("================================================================");

    // Example 2: Chain that returns different result types
    Console.WriteLine("Example 2: Chain with type transitions");
    var typeChain = OperationResult.MakeSuccess()
        .Then(() => 
        {
            Console.WriteLine("✓ Creating customer...");
            return Customer.CreateNewCustomer(name, address, birthday);
        })
        .Then(() => 
        {
            Console.WriteLine("✓ Processing additional validation...");
            return OperationResult<string>.MakeSuccess("Validation completed");
        });

    if (typeChain.Success)
    {
        Console.WriteLine($"✓ Type chain result: {typeChain.Value}");
    }
    else
    {
        Console.WriteLine("✗ Type chain failed.");
        foreach (var error in typeChain.Errors)
        {
            Console.WriteLine($"  - {error}");
        }
    }
    Console.WriteLine("================================================================");

    // Example 3: Chain with potential failure (empty name)
    Console.WriteLine("Example 3: Chain with potential failure (empty name)");
    var customer = Customer.CreateNewCustomer(name, address, birthday).Value;
    var riskierChain = customer.UpdateInformation("", address, birthday)
        .Then(() =>
        {
            Console.WriteLine("✓ Risky chain unexpectedly succeeded!");
            return OperationResult.MakeSuccess();
        })
        .IfFailed((result) =>
        {
            Console.WriteLine("✗ Risky chain failed as expected. Errors:");
            foreach (var error in result.Errors)
            {
                Console.WriteLine($"  - {error}");
            }
        });

    Console.WriteLine("================================================================");
    Console.WriteLine("");
}

static void CreateCustomerAndGiveLoan(string name, string address, DateTime birthday, decimal loanAmount, int loanRequests, ILoanService loanService)
{
    Console.WriteLine("================================================================");
    Console.WriteLine("================================================================");
    Console.WriteLine("ACTION : CUSTOMER CREATION:");
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
                Console.WriteLine("ACTION : CUSTOMER LEVEL UPGRADE:");
                Console.WriteLine("================================================================");
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
                Console.WriteLine("ACTION : LOAN REQUEST:");
                Console.WriteLine("================================================================");
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
