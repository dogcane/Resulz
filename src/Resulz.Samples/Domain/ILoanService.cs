using System;
using System.Collections.Generic;
using System.Text;

namespace Resulz.Samples.Domain
{
    public interface ILoanService
    {
        OperationResult GiveLoanToCustomer(Customer customer, decimal loanAmount);
    }
}
