using System.ComponentModel.DataAnnotations;
using Digiflow.Payment.Enums;

namespace Digiflow.Payment.Models.Requests;

public class CreateOrderModel
{
	/// <summary>
	/// API版本<br/>
	/// 固定 1.0
	/// </summary>
	[MaxLength(3)]
	public static string Version => "1.0";

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
	/// 商店訂單編號
	/// </summary>
	[MaxLength(32)]
	public string? OrderId { get; set; }

	/// <summary>
	/// 交易幣別<br/>
	/// 台幣：TWD
	/// </summary>
	public Currency Currency { get; set; } = Currency.TWD;

	/// <summary>
	/// 訂單金額
	/// </summary>
	public int? Amount { get; set; }

	/// <summary>
	/// 商品名稱（訂單描述）
	/// </summary>
	[MaxLength(64)]
	public string? Description { get; set; }

	/// <summary>
	/// 付款期限
	/// </summary>
	public string ExpiryTime { get; set; } = $"{DateTime.UtcNow.AddHours(8).AddDays(1):yyyyMMddHHmmss}";

	/// <summary>
	/// 付款方式
	/// </summary>
	public string? PaymentType { get; set; } = null;

	/// <summary>
	/// 消費者在電商平臺的會員ID<br/>
	/// 用於支援消費者保存常用信用卡，不傳時不支持卡號保存
	/// </summary>
	[MaxLength(48)]
	public string? MemberId { get; set; } = null;

	/// <summary>
	/// 消費者電子郵件信箱
	/// </summary>
	[EmailAddress, MaxLength(48)]
	public string? BuyerEmail { get; set; } = null;

	/// <summary>
	/// 商店自定附加資訊，訂單查詢時原樣返回
	/// </summary>
	[MaxLength(256)]
	public string? ExtraData { get; set; } = null;

	/// <summary>
	/// 時間戳，自 1970/01/01 至當前時間的毫秒數，同 Java 的 System.currentTimeMillis()<br/>
	/// 與數位鎏系統時鐘差異超過 180 秒的交易將會被拒絕
	/// </summary>
	public static string Timestamp =>
		((long)(DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds).ToString();
}
