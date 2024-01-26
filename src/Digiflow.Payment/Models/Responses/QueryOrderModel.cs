using System.Text.Json.Serialization;
using Digiflow.Payment.Enums;

namespace Digiflow.Payment.Models.Responses;

public class QueryOrderModel : BaseResponseModel
{
	/// <summary>
	/// 數位鎏系統訂單編號
	/// </summary>
	[JsonPropertyName("sys_order_id")]
	public string? SysOrderId { get; set; }

	/// <summary>
	/// 商店編號
	/// </summary>
	[JsonPropertyName("merchant_id")]
	public string? MerchantId { get; set; }

	/// <summary>
	/// 終端編號
	/// </summary>
	[JsonPropertyName("terminal_id")]
	public string? TerminalId { get; set; }

	/// <summary>
	/// 商店訂單編號
	/// </summary>
	[JsonPropertyName("order_no")]
	public string? OrderNo { get; set; }

	/// <summary>
	/// 交易幣別
	/// </summary>
	[JsonPropertyName("currency")]
	public Currency? Currency { get; set; }

	/// <summary>
	/// 訂單金額，單位為 0.01 元<br/>
	/// 例:100 元將回傳 10000
	/// </summary>
	[JsonPropertyName("order_amount")]
	public decimal? OrderAmount { get; set; }

	/// <summary>
	/// 訂單狀態
	/// </summary>
	[JsonPropertyName("order_status")]
	public OrderStatus? OrderStatus { get; set; }

	/// <summary>
	/// 付款方式
	/// </summary>
	[JsonPropertyName("payment_type")]
	public PaymentType? PaymentType { get; set; }

	/// <summary>
	/// 商店自定附加資訊，原樣返回
	/// </summary>
	[JsonPropertyName("ext_data")]
	public string? ExtraData { get; set; }

	/// <summary>
	/// 付款資訊<br/>
	/// 訂單狀態爲已付款時才出現
	/// </summary>
	[JsonPropertyName("payment_info")]
	public PaymentInfoModel? PaymentInfo { get; set; }
}
