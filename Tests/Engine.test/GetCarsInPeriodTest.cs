using Engine.Vehicles;

/// <summary>
/// This class tests the CarsInPeriod class and methods.
/// </summary>
public class GetCarsInPeriodTest
{
    private const uint _testPeriod = 900; // 900 seconds = 30 minutes

    [Fact]
    public void ZeroFraction_ReturnsZero()
    {
        var result = CarsInPeriod.GetCarsInPeriod(DayOfWeek.Monday, 8, 0.0, _testPeriod);
        
        Assert.Equal(0, result.Amount);
    }

    [Fact]
    public void DoubleFraction_DoublesResult()
    {
        var half = CarsInPeriod.GetCarsInPeriod(DayOfWeek.Monday, 8, 0.5, _testPeriod);
        var full = CarsInPeriod.GetCarsInPeriod(DayOfWeek.Monday, 8, 1.0, _testPeriod);
        
        // Putting ±1 here accounts for truncating.
        Assert.InRange(full.Amount, (half.Amount * 2) - 1, (half.Amount * 2) + 1);
    }

    [Fact]
    public void PeakHour_ReturnsMoreThanOffPeakHour()
    {
        var peak = CarsInPeriod.GetCarsInPeriod(DayOfWeek.Monday, 8, 0.5, _testPeriod);
        var offPeak = CarsInPeriod.GetCarsInPeriod(DayOfWeek.Sunday, 2, 0.5, _testPeriod);
        
        Assert.True(peak.Amount > offPeak.Amount);
    }

    [Fact]
    public void GetCarsInPeriod_NeverReturnsNegative()
    {
        var result = CarsInPeriod.GetCarsInPeriod(DayOfWeek.Sunday, 2, 0.5, _testPeriod);
        
        Assert.True(result.Amount >= 0);
    }
}