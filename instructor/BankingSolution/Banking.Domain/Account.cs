namespace Banking.Domain;

public class Account
{
    private decimal _balance = 5000; // Fields class level variable
    public virtual void Deposit(decimal amountToDeposit)
    {
        _balance += amountToDeposit;
    }

    public decimal GetBalance()
    {
        return _balance; // "Sliming"
    }

    public void Withdraw(decimal amountToWithdraw)
    {
        if(amountToWithdraw > _balance)
        {
            throw new OverdraftException();
        }
       _balance -= amountToWithdraw;
    }
}