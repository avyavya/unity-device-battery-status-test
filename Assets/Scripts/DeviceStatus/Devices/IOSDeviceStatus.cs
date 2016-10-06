using System;
using System.Runtime.InteropServices;


namespace DeviceStatus.Devices
{
	
	public class IOSDeviceStatus : IDeviceStatus
	{

		public IOSDeviceStatus()
		{
		}

		/// Native Plugins
	    [DllImport("__Internal")]
	    private static extern uint getUsedMemorySize();

	    [DllImport("__Internal")]
	    private static extern float enableBatteryMonitoring();
	    [DllImport("__Internal")]
	    private static extern float disableBatteryMonitoring();
	    [DllImport("__Internal")]
	    private static extern float getBatteryLevel();


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

		public float GetBatteryLevel()
		{
			return getBatteryLevel();
		}

		public bool IsBatteryStateCharging()
		{
			return false;
		}

	}

}
