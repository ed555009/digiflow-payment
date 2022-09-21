using Digiflow.Payment.Enums;

namespace Digiflow.Payment.Models.Requests;

public class CaptureOrderModel : QueryOrderModel
{
	/// <summary>
	/// 交易幣別<br/>
	/// 台幣：TWD
	/// </summary>
	public Currency Currency { get; set; } = Currency.TWD;

	/// <summary>
	/// 請款金額
	/// </summary>
	public decimal? CaptureAmount { get; set; }
}
