using UnityEngine;


namespace DeviceStatus.Devices
{
	
	public class AndroidDeviceStatus
	{
		
		public AndroidDeviceStatus()
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

		/// http://answers.unity3d.com/questions/369110/how-to-get-current-battery-life-on-mobile-device.html
		public float GetBatteryLevel()
		{
			var lv = -1f;

			if (Application.platform != RuntimePlatform.Android) return lv;

			try
			{
				using (var unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
				{
					if (unityPlayer == null) return lv;

					using (var currActivity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity"))
					{
						if (currActivity == null) return lv;

						using (var intentFilter = new AndroidJavaObject("android.content.IntentFilter", new object[] { "android.intent.action.BATTERY_CHANGED" }))
						{
							using (var batteryIntent = currActivity.Call<AndroidJavaObject>("registerReceiver", new object[] { null, intentFilter }))
							{
								int level = batteryIntent.Call<int>("getIntExtra", new object[] { "level", -1 });
								int scale = batteryIntent.Call<int>("getIntExtra", new object[] { "scale", -1 });

								// Error checking that probably isn't needed but I added just in case.
								if (level < 0 || scale < 0)
								{
									return lv;
								}
								lv = (float)level / (float)scale;
							}

						}
					}
				}
			}
			catch (System.Exception e)
			{

			}

			return lv;
		}

		public bool IsBatteryStateCharging()
		{
			return false;
		}
	}
}
