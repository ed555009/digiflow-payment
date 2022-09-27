using System.ComponentModel.DataAnnotations;
using Digiflow.Payment.Interfaces;

namespace Digiflow.Payment.Models.Requests;

public abstract class BaseRequestModel : IBaseRequestModel
{
	/// <summary>
	/// API版本<br/>
	/// 固定 1.0
	/// </summary>
	[MaxLength(3)]
	public string? Version { get; set; }

	/// <summary>
	/// 商店編號
	/// </summary>
	[MaxLength(15)]
	public string? MerchantId { get; set; }

	/// <summary>
	/// 終端編號
	/// </summary>
	[MaxLength(8)]
	public string? TerminalId { get; set; }

	/// <summary>
	/// 時間戳，自 1970/01/01 至當前時間的毫秒數，同 Java 的 System.currentTimeMillis()<br/>
	/// 與數位鎏系統時鐘差異超過 180 秒的交易將會被拒絕
	/// </summary>
	public string Timestamp { get; set; } =
		((long)(DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds).ToString();
}
