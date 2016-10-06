using UnityEngine;
using DeviceStatus.Devices;


namespace DeviceStatus
{

	public class DeviceStatusComponent : MonoBehaviour
	{

		private IDeviceStatus device;


		private void OnEnable()
		{
			if (device == null)
			{
#if UNITY_EDITOR
				device = new UnityEditorDeviceStatus();
#elif UNITY_IOS
				device = new IOSDeviceStatus();
#elif UNITY_ANDROID
				device = new AndroidDeviceStatus();
#else
				device = new UndefinedDeviceStatus();
#endif
			}

			device.OnEnable();
		}

		private void OnDisable()
		{
			device.OnDisable();
		}


		public float GetMemoryUsage()
		{
			return device.GetMemoryUsage();
		}

		public BatteryStatus GetBatteryStatus()
		{
			return device.GetBatteryStatus();
		}

	}

}
