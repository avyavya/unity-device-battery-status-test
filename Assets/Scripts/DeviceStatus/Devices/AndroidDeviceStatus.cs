using UnityEngine;


namespace DeviceStatus.Devices
{

    public class AndroidDeviceStatus : IDeviceStatus
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

        /// http://answers.unity3d.com/questions/369110/how-to-get-current-battery-life-on-mobile-device.html
        public BatteryStatus GetBatteryStatus()
        {
            var s = new BatteryStatus
            {
                Level = -1f
            };

            if (Application.platform != RuntimePlatform.Android) return s;

            try
            {
                using (var unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
                {
                    if (unityPlayer == null) return s;

                    using (var currActivity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity"))
                    {
                        if (currActivity == null) return s;

                        using (var intentFilter = new AndroidJavaObject("android.content.IntentFilter", new object[] { "android.intent.action.BATTERY_CHANGED" }))
                        {
                            using (var batteryIntent = currActivity.Call<AndroidJavaObject>("registerReceiver", new object[] { null, intentFilter }))
                            {
                                var level = batteryIntent.Call<int>("getIntExtra", new object[] { "level", -1 });
                                var scale = batteryIntent.Call<int>("getIntExtra", new object[] { "scale", -1 });
                                var status = batteryIntent.Call<int>("getIntExtra", new object[] { "status", -1 });

                                s.IsCharging = status == 2; // 充電中:2, Unplug:3

                                s.Level = (float) level / (float) scale;
                            }
                        }
                    }
                }
            }
            catch (System.Exception e)
            {
            }

            return s;
        }

    }

}
