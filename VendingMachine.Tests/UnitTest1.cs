namespace VendingMachine.Tests;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        var display = new TestableDisplay();
        var sut = new VendingMachine(display); 
        sut.InsertCoin(Coins.Nickel);
        Assert.Equal("Balance: $0,05", display.Output);
    }
    
    [Fact]
    public void Test2()
    {
        var display = new TestableDisplay();
        var sut = new VendingMachine(display); 
        sut.InsertCoin(Coins.Dime);
        Assert.Equal("Balance: $0,10", display.Output);
    }
}