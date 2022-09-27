using Digiflow.Payment.Enums;
using Newtonsoft.Json;

namespace Digiflow.Payment.Models.Responses;

public class RefundOrderModel : CancelOrderModel
{
	/// <summary>
	/// 交易幣別
	/// </summary>
	[JsonProperty("currency")]
	public Currency? Currency { get; set; }

	/// <summary>
	/// 訂單金額，單位為 0.01 元<br/>
	/// 例:100 元將回傳 10000
	/// </summary>
	[JsonProperty("refund_amount")]
	public decimal? RefundAmount { get; set; }
}
