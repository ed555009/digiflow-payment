using Newtonsoft.Json;

namespace Digiflow.Payment.Models.Responses;

public class CancelOrderModel : BaseResponseModel
{
	/// <summary>
	/// 數位鎏系統交易編號
	/// </summary>
	[JsonProperty("sys_trx_id")]
	public string? SysTrxId { get; set; }

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
}
