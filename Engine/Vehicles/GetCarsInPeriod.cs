namespace Engine.Vehicles;

using Engine.DayCycles;
using System;

/// <summary>
/// This class provides the amount of cars on the road and the period in seconds for which 
/// the amount of cars is calculated.
/// </summary>
public class GetCarsInPeriod
{
    /// <summary>
    /// The period in seconds for which the amount of cars is calculated. 
    /// </summary>
    public const uint PeriodInSeconds = 60 * 30;
    private const double _periodsPerHour = 60 * 60 / PeriodInSeconds;

    /// <summary>
    /// Gets the estimated number of cars to spawn in the current period based on the 
    /// day of the week and hour of the day.
    /// </summary>
    /// <param name="day"> The day of the week. </param>
    /// <param name="hourOfDay"> The hour of the day. </param>
    /// <param name="SpawnFraction"> A fraction of the total EVs that are supposed to be 
    ///                              on the road, to avoid overpopulating the system. </param>
    /// <returns> The number of cars to spawn. </returns>
    public static int GetAmount(DayOfWeek day, int hourOfDay, double SpawnFraction)
    {
        var fractionPerPeriod = SpawnFraction / _periodsPerHour;
        return (int)(CarsOnRoad.GetEVsOnRoad(day, hourOfDay) * fractionPerPeriod);
    }
}