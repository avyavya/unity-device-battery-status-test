using UnityEngine;
using System;
using System.Runtime.InteropServices;


public class DeviceStatusComponent : MonoBehaviour
{

    private void Start()
    {
#if UNITY_IOS
        enableBatteryMonitoring();
#endif
    }

    private void OnDisable()
    {
#if UNITY_IOS
        disableBatteryMonitoring();
#endif
    }


    /// Native Plugins
#if UNITY_IOS
    [DllImport("__Internal")]
    private static extern uint getUsedMemorySize();

    [DllImport("__Internal")]
    private static extern float enableBatteryMonitoring();
    [DllImport("__Internal")]
    private static extern float disableBatteryMonitoring();
    [DllImport("__Internal")]
    private static extern float getBatteryLevel();
#endif


    /// <summary>
    /// Gets the memory usage.
    /// </summary>
    /// <returns>The memory usage.</returns>
#if UNITY_EDITOR
    public float GetMemoryUsage()
    {
        var m = GC.GetTotalMemory(false);

        return m;
    }

#elif UNITY_IOS
    public float GetMemoryUsage()
    {
        var m = getUsedMemorySize();

        return m;
    }

#elif UNITY_ANDROID
    public float GetMemoryUsage()
    {
        return 1024f;
    }

#else
    public float GetMemoryUsage()
    {
        return -1f;
    }
#endif


    /// <summary>
    /// Gets the battery level.
    /// </summary>
    /// <returns>The battery level.</returns>
#if UNITY_EDITOR
    public float GetBatteryLevel()
    {
        return -1f;
    }

#elif UNITY_IOS
    public float GetBatteryLevel()
    {
        return getBatteryLevel();
    }

#elif UNITY_ANDROID
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
                            lv = (float) level / (float) scale;
                        }

                    }
                }
            }
        }
        catch (System.Exception ex)
        {
            
        }

        return lv;
    }
#else

    private float GetBatteryLevel()
    {
        return -1f;
    }
#endif


}
