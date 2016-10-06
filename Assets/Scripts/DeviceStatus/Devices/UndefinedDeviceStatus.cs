
namespace DeviceStatus.Devices
{

	public class UndefinedDeviceStatus : IDeviceStatus
	{

		public UndefinedDeviceStatus()
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
			return -1f;
		}

		public float GetBatteryLevel()
		{
			return -1f;
		}

		public bool IsBatteryStateCharging()
		{
			return false;
		}

	}

}
