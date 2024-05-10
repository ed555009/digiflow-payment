using System.ComponentModel.DataAnnotations;
using Digiflow.Payment.Enums;

namespace Digiflow.Payment.Models.Requests;

public class CreateOrderModel : BaseRequestModel
{
	/// <summary>
	/// 商店訂單編號
	/// </summary>
	[MaxLength(32)]
	public string? OrderNo { get; set; }

	/// <summary>
	/// 交易幣別<br/>
	/// 台幣：TWD
	/// </summary>
	public Currency Currency { get; set; } = Currency.TWD;

	/// <summary>
	/// 訂單金額
	/// </summary>
	public decimal? Amount { get; set; }

	/// <summary>
	/// 商品名稱（訂單描述）
	/// </summary>
	[MaxLength(64)]
	public string? Description { get; set; }

	/// <summary>
	/// 付款期限
	/// </summary>
	public string ExpiryTime { get; set; } = $"{DateTimeOffset.UtcNow.AddDays(1).ToOffset(new TimeSpan(8, 0, 0)):yyyyMMddHHmmss}";

	/// <summary>
	/// 付款方式
	/// </summary>
	public PaymentType PaymentType { get; set; } = PaymentType.CreditCard;

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
}
