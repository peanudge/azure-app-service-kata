namespace Prime.Services;

public class IsPrimeShould {
    private readonly PrimeService _primeService;

    public IsPrimeShould()
    {
        _primeService = new PrimeService();
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(0)]
    [InlineData(1)]
    public void TestName(int value)
    {
        // Given
        
        // When
        bool result = _primeService.IsPrime(value);
        // Then
        Assert.False(result, "1 should not be prime");
    }
}
