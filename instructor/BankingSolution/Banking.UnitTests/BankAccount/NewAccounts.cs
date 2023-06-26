



namespace Banking.UnitTests.BankAccount;

public class NewAccounts
{
    [Fact]
    public void NewAccountsHaveCorrectBalance()
    {
        // Given
        Account account = new Account();

        // When
        decimal balance = account.GetBalance();

        // Then
        Assert.Equal(5000, balance);
    }
}
