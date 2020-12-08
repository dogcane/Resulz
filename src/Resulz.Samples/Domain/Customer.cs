using System;
using System.Collections.Generic;
using System.Text;
using Resulz;
using Resulz.Validation;

namespace Resulz.Samples.Domain
{
    public class Customer
    {
        public string Name { get; protected set; }

        public string Address { get; protected set; }

        public DateTime Birthday { get; protected set; }

        public CustomerLevel Level { get; protected set; }

        protected Customer(string name, string address, DateTime birthday)
        {
            Name = name;
            Address = address;
            Birthday = birthday;
        }

        public static OperationResult<Customer> CreateNewCustomer(string name, string address, DateTime birthday)
        {
            return OperationResult
                .MakeSuccess()
                .With(name, nameof(Name)).Required().StringLength(250)
                .With(address, nameof(Address)).Required().StringLength(500)
                .With(birthday, nameof(Birthday))
                .Result;                
        }

        public OperationResult UpdateInformation(string name, string address, DateTime birthday)
        {
            return OperationResult
                .MakeSuccess()
                .With(name, nameof(Name)).Required().StringLength(250)
                .With(address, nameof(Address)).Required().StringLength(500)
                .With(birthday, nameof(Birthday))
                .Result;
        }

        public OperationResult UpgradeLevel()
        {
            var currentLevel = Level;
            Level++;
            return (currentLevel == Level) ? OperationResult.MakeFailure(ErrorMessage.Create(nameof(Level), "MAXIMUM_LEVEL_REACHED")) : OperationResult.MakeSuccess();
        }
    }

    public enum CustomerLevel
    {
        Standard,
        Silver,
        Gold
    }
}
