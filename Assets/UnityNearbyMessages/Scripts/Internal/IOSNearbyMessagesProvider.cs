using System.Runtime.InteropServices;
using NearbyMessages.Internal;

public class IOSNearbyMessagesProvider : INearbyMessagesProvider
{
    [DllImport("__Internal")]
    private static extern void _unm_initialize(string apiKey);

    [DllImport("__Internal")]
    private static extern void _unm_startScan();

    [DllImport("__Internal")]
    private static extern void _unm_stopScan();

    public IOSNearbyMessagesProvider(string apiKey)
    {
        _unm_initialize(apiKey);
    }

    public void StartScan()
    {
        _unm_startScan();
    }

    public void StopScan()
    {
        _unm_stopScan();
    }
}
