using System;
using System.Runtime.InteropServices;


namespace DeviceStatus.Devices
{

    public class IOSDeviceStatus : IDeviceStatus
    {

        /// Native Plugins
        [DllImport("__Internal")]
        private static extern uint getUsedMemorySize();

        [DllImport("__Internal")]
        private static extern float enableBatteryMonitoring();
        [DllImport("__Internal")]
        private static extern float disableBatteryMonitoring();
        [DllImport("__Internal")]
        private static extern float getBatteryLevel();
        [DllImport("__Internal")]
        private static extern int getBatteryState();


        public void OnEnable()
        {
            enableBatteryMonitoring();
        }

        public void OnDisable()
        {
            disableBatteryMonitoring();
        }


        public float GetMemoryUsage()
        {
            var m = getUsedMemorySize();

            return m;
        }

        public BatteryStatus GetBatteryStatus()
        {
            var state = getBatteryState();

            return new BatteryStatus
            {
                Level = getBatteryLevel(),
                IsCharging = state == 1, // 充電中:1, see: BatteryMonitorPlugin.m
            };
        }

    }

}
