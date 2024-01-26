using System.Text.Json.Serialization;
using Digiflow.Payment.Enums;

namespace Digiflow.Payment.Models.Responses;

public class RefundOrderModel : CancelOrderModel
{
	/// <summary>
	/// 交易幣別
	/// </summary>
	[JsonPropertyName("currency")]
	public Currency? Currency { get; set; }

	/// <summary>
	/// 訂單金額，單位為 0.01 元<br/>
	/// 例:100 元將回傳 10000
	/// </summary>
	[JsonPropertyName("refund_amount")]
	public decimal? RefundAmount { get; set; }
}
