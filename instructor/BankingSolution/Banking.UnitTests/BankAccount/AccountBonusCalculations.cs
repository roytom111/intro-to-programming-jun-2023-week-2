

using Banking.UnitTests.TestDoubles;

namespace Banking.UnitTests.BankAccount;
public class AccountBonusCalculations
{
    [Fact]
    public void DepositUsesTheBonusCalculator()
    {
        // Given
        var stubbedBonusCalculator = new Mock<ICanCalculateBonuses>();
        var account = new Account(stubbedBonusCalculator.Object);
        var openingBalance = account.GetBalance();

        stubbedBonusCalculator.Setup(c => c.CalculateBonusForDepositOn(openingBalance, 112))
            .Returns(42);
        

        // When
        account.Deposit(112);
        // Then 
        Assert.Equal(openingBalance + 112M + 42M, account.GetBalance());

    }
}
