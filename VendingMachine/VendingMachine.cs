namespace VendingMachine;

public class VendingMachine(ICanDisplay display)
{
    public void InsertCoin(Coin coin)
    {
        var amount = DetermineValue(coin);
        display.Update($"Balance: ${amount:F2}");
    }

    private static double DetermineValue(Coin coin)
    {
        switch (coin.Weight)
        {
            case "5 g":
                return 0.05;
            
            case "10 g":
                return 0.10;
            default:
                throw new ArgumentException($"Invalid weight of {coin.Weight}");
        }
    }
}