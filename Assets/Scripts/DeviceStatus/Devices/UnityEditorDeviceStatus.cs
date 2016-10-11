
#if UNITY_EDITOR
namespace DeviceStatus.Devices
{

    public class UnityEditorDeviceStatus : IDeviceStatus
    {

        public UnityEditorDeviceStatus()
        {
        }

        public void OnEnable()
        {
        }

        public void OnDisable()
        {
        }


        public float GetMemoryUsage()
        {
            var m = System.GC.GetTotalMemory(false);

            return m;
        }

        public float GetBatteryLevel()
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
#endif
