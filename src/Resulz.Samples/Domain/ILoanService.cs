namespace Resulz.Samples.Domain
{
    public interface ILoanService
    {
        OperationResult GiveLoanToCustomer(Customer customer, decimal loanAmount);
    }
}
