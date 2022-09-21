using Digiflow.Payment.Enums;
using Newtonsoft.Json;

namespace Digiflow.Payment.Models.Responses;

public class CaptureOrderModel : CancelOrderModel
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
	[JsonProperty("capture_amount")]
	public decimal? CaptureAmount { get; set; }
}
