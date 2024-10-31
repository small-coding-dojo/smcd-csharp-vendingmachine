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

    public static List<TheoryDataRow> CoinData =>
    [
        new(Coins.Nickel, "Balance: $0,05") {TestDisplayName = "Insert a Nickel - "},
        new(Coins.Dime, "Balance: $0,10") {TestDisplayName = "Insert a Dime - "}
    ];
    
    [Theory]
    [MemberData(nameof(CoinData), TestDisplayName = "Blubb")]
    public void Test3(Coin coin, string expectedOutput)
    {
        var display = new TestableDisplay();
        var sut = new VendingMachine(display); 
        sut.InsertCoin(coin);
        Assert.Equal(expectedOutput, display.Output);
    }

}