using System.Text.Json.Serialization;

namespace Digiflow.Payment.Models.Responses;

public class CancelOrderModel : BaseResponseModel
{
	/// <summary>
	/// 數位鎏系統交易編號
	/// </summary>
	[JsonPropertyName("sys_trx_id")]
	public string? SysTrxId { get; set; }

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
}
