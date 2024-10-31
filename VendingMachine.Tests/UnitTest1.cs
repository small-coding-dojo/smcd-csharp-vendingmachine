using System.Runtime.InteropServices;

namespace VendingMachine.Tests;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        var display = new TestableDisplay();
        var sut = new VendingMachine(display); 
        sut.InsertCoin(NewCoins.Nickel);
        Assert.Equal("Balance: $0,05", display.Output);
    }
    
    [Fact]
    public void Test2()
    {
        var display = new TestableDisplay();
        var sut = new VendingMachine(display); 
        sut.InsertCoin(NewCoins.Dime);
        Assert.Equal("Balance: $0,10", display.Output);
    }
}

public interface ICanDisplay
{
    void Update(string message);
}

public class TestableDisplay : ICanDisplay
{
    public string Output { get; set; }
    
    public void Update(string message)
    {
        Output = message;
    }
}

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

public record struct Coin(string Weight);

public class NewCoins
{
    public static Coin Nickel = new Coin("5 g");
    public static Coin Dime = new Coin("10 g");
}
