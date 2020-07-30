using TwitterPublicStream.Models;

namespace TwitterPublicStream.Services
{
    public interface ITwitterStreamService
    {
        void StartStream();
        StreamStatistics CalculateStreamStatistics();
    }
}
