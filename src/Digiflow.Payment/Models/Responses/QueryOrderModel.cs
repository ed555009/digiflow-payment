using Digiflow.Payment.Enums;
using Newtonsoft.Json;

namespace Digiflow.Payment.Models.Responses;

public class QueryOrderModel : BaseResponseModel
{
	/// <summary>
	/// 數位鎏系統訂單編號
	/// </summary>
	[JsonProperty("sys_order_id")]
	public string? SysOrderId { get; set; }

	/// <summary>
	/// 商店編號
	/// </summary>
	[JsonProperty("merchant_id")]
	public string? MerchantId { get; set; }

	/// <summary>
	/// 終端編號
	/// </summary>
	[JsonProperty("terminal_id")]
	public string? TerminalId { get; set; }

	/// <summary>
	/// 商店訂單編號
	/// </summary>
	[JsonProperty("order_no")]
	public string? OrderNo { get; set; }

	/// <summary>
	/// 交易幣別
	/// </summary>
	[JsonProperty("currency")]
	public Currency? Currency { get; set; }

	/// <summary>
	/// 訂單金額，單位為 0.01 元<br/>
	/// 例:100 元將回傳 10000
	/// </summary>
	[JsonProperty("order_amount")]
	public decimal? OrderAmount { get; set; }

	/// <summary>
	/// 訂單狀態
	/// </summary>
	[JsonProperty("order_status")]
	public OrderStatus? OrderStatus { get; set; }

	/// <summary>
	/// 付款方式
	/// </summary>
	[JsonProperty("payment_type")]
	public PaymentType? PaymentType { get; set; }

	/// <summary>
	/// 商店自定附加資訊，原樣返回
	/// </summary>
	[JsonProperty("ext_data")]
	public string? ExtraData { get; set; }

	/// <summary>
	/// 付款資訊<br/>
	/// 訂單狀態爲已付款時才出現
	/// </summary>
	[JsonProperty("payment_info")]
	public PaymentInfoModel? PaymentInfo { get; set; }
}
