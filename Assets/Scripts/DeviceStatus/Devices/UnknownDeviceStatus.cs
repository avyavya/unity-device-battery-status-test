
namespace DeviceStatus.Devices
{

    public class UnknownDeviceStatus : IDeviceStatus
    {

        public void OnEnable()
        {
        }

        public void OnDisable()
        {
        }


        public float GetMemoryUsage()
        {
            return -1f;
        }

        public BatteryStatus GetBatteryStatus()
        {
            return new BatteryStatus
            {
                Level = -1f
            };
        }

    }

}
