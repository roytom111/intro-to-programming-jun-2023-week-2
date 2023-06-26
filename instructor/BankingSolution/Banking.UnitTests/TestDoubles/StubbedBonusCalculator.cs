
namespace Banking.UnitTests.TestDoubles;
public class StubbedBonusCalculator : ICanCalculateBonuses
{
    public decimal CalculateBonusForDepositOn(decimal balance, decimal amountToDeposit)
    {
      return (balance == 5000M && amountToDeposit == 112M) ? 42 : 0;
    }
}
