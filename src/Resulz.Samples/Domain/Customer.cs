using Resulz.Validation;
using System;

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
                .Result
                .IfSuccessThenReturn<Customer>(() => new Customer(name, address, birthday));
        }

        public OperationResult UpdateInformation(string name, string address, DateTime birthday)
        {
            return OperationResult
                .MakeSuccess()
                .With(name, nameof(Name)).Required().StringLength(250)
                .With(address, nameof(Address)).Required().StringLength(500)
                .With(birthday, nameof(Birthday))
                .Result
                .IfSuccess((result) =>
                {
                    Name = name;
                    Address = address;
                    Birthday = birthday;
                });
        }

        public OperationResult<LevelUpgradeInfo> UpgradeLevel()
        {
            return OperationResult
                .MakeSuccess()
                .With(Level, nameof(Level)).Condition(level => level < CustomerLevel.Gold, "MAXIMUM_LEVEL_REACHED")
                .Result
                .IfSuccessThenReturn<LevelUpgradeInfo>(() =>
                {
                    Level++;
                    return new LevelUpgradeInfo { PreviusLevel = Level - 1, CurrentLevel = Level };
                });
        }

        public override string ToString()
        {
            return $"Name : {Name}\r\nAddress : {Address}\r\nBirthday : {Birthday:D}\r\nLevel : {Level}";
        }
    }

    public enum CustomerLevel
    {
        Standard,
        Silver,
        Gold
    }

    public struct LevelUpgradeInfo
    {
        public CustomerLevel PreviusLevel { get; set; }
        public CustomerLevel CurrentLevel { get; set; }

        public override string ToString()
        {
            return $"Old Level : {PreviusLevel}\r\nNew Level : {CurrentLevel}";
        }
    }
}
