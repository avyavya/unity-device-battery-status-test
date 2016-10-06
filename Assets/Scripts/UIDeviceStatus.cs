using UnityEngine;
using UnityEngine.UI;
using DeviceStatus;


[RequireComponent(typeof(DeviceStatusComponent))]
public class UIDeviceStatus : MonoBehaviour
{
    
    [SerializeField] private Text batteryLevel;

    [SerializeField] private Text memoryUsage;

    private DeviceStatusComponent status;


    private void OnEnable()
    {
        if (status == null)
        {
            status = GetComponent<DeviceStatusComponent>();
        }
    }

    private void Update()
    {
        UpdateMemoryUsage();
        UpdateBatteryLevel();
    }

    private void UpdateMemoryUsage()
    {
        var b = status.GetMemoryUsage();
        var mb = b / 1048576f;

        memoryUsage.text = mb.ToString("F2") + " MB";
    }

    private void UpdateBatteryLevel()
    {
        var lv = status.GetBatteryLevel() * 100f;

        batteryLevel.text = lv.ToString("F0") + " %";
    }

}
