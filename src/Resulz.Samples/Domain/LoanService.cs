using System;
using System.Collections.Generic;
using System.Text;
using Resulz;
using Resulz.Validation;

namespace Resulz.Samples.Domain
{
    public class LoanService : ILoanService
    {
        public OperationResult GiveLoadToCustomer(Customer customer, decimal loanAmount)
        {
            var contractResult = OperationResult
                .MakeSuccess()
                .With(customer, nameof(Customer)).Required()
                .With(loanAmount, nameof(loanAmount)).GreaterThen(0)
                .Result;
            if (!contractResult.Success) return contractResult;
            var maxAdmittedLoadValue = Convert.ToDecimal(Math.Pow(10, (int)customer.Level));
            return OperationResult
                .MakeSuccess()
                .With(loanAmount, nameof(LoanService)).LessThen(maxAdmittedLoadValue, "LOAN_NOT_ALLOWED_FOR_CUSTOMER")
                .Result;
        }
    }
}
