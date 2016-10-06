
namespace DeviceStatus.Devices
{
	
	public interface IDeviceStatus
	{

		/// 使用するコンポーネント側から呼ぶ
		void OnEnable();
		/// 使用するコンポーネント側から呼ぶ
		void OnDisable();


		/// アプリの使用メモリ量 (bytes)
		float GetMemoryUsage();

		/// バッテリーレベル (0 - 1)
		float GetBatteryLevel();

		/// 充電中
		bool IsBatteryStateCharging();
	
	}

}
