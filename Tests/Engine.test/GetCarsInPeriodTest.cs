using Engine.Vehicles;

/// <summary>
/// This class tests the GetCarsInPeriod class and methods.
/// </summary>
public class GetCarsInPeriodTests
{
    [Fact]
    public void PeriodInSeconds_Is1800() => Assert.Equal(1800u, GetCarsInPeriod.PeriodInSeconds);

    [Fact]
    public void ZeroFraction_ReturnsZero()
    {
        var result = GetCarsInPeriod.GetAmount(DayOfWeek.Monday, 8, 0.0);
        Assert.Equal(0, result);
    }

    [Fact]
    public void DoubleFraction_DoublesResult()
    {
        var half = GetCarsInPeriod.GetAmount(DayOfWeek.Monday, 8, 0.5);
        var full = GetCarsInPeriod.GetAmount(DayOfWeek.Monday, 8, 1.0);
        Assert.Equal(half * 2, full);
    }

    [Fact]
    public void PeakHour_ReturnsMoreThanOffPeakHour()
    {
        var peak = GetCarsInPeriod.GetAmount(DayOfWeek.Monday, 8, 0.5);    // Monday 8am
        var offPeak = GetCarsInPeriod.GetAmount(DayOfWeek.Sunday, 2, 0.5); // Sunday 2am
        Assert.True(peak > offPeak);
    }

    [Fact]
    public void GetAmount_NeverReturnsNegative()
    {
        var result = GetCarsInPeriod.GetAmount(DayOfWeek.Sunday, 2, 0.5);
        Assert.True(result >= 0);
    }
}