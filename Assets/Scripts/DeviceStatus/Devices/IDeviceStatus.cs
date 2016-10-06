
namespace DeviceStatus.Devices
{

	public struct BatteryStatus
	{
		/// 充電中
		public bool IsCharging;
		/// バッテリーレベル (0 - 1)
		public float Level;

		public int Status;
	}

	public interface IDeviceStatus
	{
		
		/// 使用するコンポーネント側から呼ぶ
		void OnEnable();
		/// 使用するコンポーネント側から呼ぶ
		void OnDisable();

		/// バッテリーレベルと充電状態
		BatteryStatus GetBatteryStatus();
		/// アプリの使用メモリ量 (bytes)
		float GetMemoryUsage();

	}

}
