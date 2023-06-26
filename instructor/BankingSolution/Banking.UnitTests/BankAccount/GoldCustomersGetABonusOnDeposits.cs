


namespace Banking.UnitTests.BankAccount;
public class GoldCustomersGetABonusOnDeposits
{
    [Fact]
    public void BonusIsApplied()
    {
        // Given - the "Context" for this test.
        var account = new Account();
        account.AccountType = LoyaltyLevel.Gold;
        var openingBalance = account.GetBalance();
        var amountToDeposit = 100M;
        var expectedNewBalance = openingBalance + amountToDeposit + 10M;


        // When - what we are testing
        account.Deposit(amountToDeposit);

        // Then - how do we know it worked?
        Assert.Equal(expectedNewBalance, account.GetBalance());

    }
}
