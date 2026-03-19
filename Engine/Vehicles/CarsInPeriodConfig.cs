namespace Engine.Vehicles;

public class GetCarsInPeriodConfig
{
    public double SpawnFraction { get; init; } = 0.5;
    public uint SpawningFrequency { get; init; } = 60 * 30; // 30 minutes
}