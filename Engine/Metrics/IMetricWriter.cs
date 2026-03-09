namespace Engine.Metrics;

/// <summary>
/// Defines a writer for a specific metric type.
/// Implementations own the channel, buffer, and parquet file for that type.
/// </summary>
/// <typeparam name="T">Metric type.<typeparam>
public interface IMetricWriter<T>
{
    /// <summary>
    /// Records a metric by writing it into the channel. This method is non-blocking and should never wait on I/O.
    /// </summary>
    /// <param name="metric">The metric type.</param>
    void Record(T metric);

    /// <summary>
    /// Signals the writer to stop accepting new metrics, drains the channel, and flushes any remaining buffered metrics to parquet.
    /// </summary>
    /// <returns>A task that completes once all metrics have been flushed and the writer has fully stopped. </returns>
    Task DrainAndFlushAsync();
}
