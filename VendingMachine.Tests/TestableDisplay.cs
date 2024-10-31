namespace VendingMachine.Tests;

internal class TestableDisplay : ICanDisplay
{
    public string Output { get; set; }
    
    public void Update(string message)
    {
        Output = message;
    }
}