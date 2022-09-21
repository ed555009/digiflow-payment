using Digiflow.Payment.Enums;

namespace Digiflow.Payment.Models.Requests;

public class RefundOrderModel : QueryOrderModel
{
	/// <summary>
	/// 交易幣別<br/>
	/// 台幣：TWD
	/// </summary>
	public Currency Currency { get; set; } = Currency.TWD;

	/// <summary>
	/// 退款金額
	/// </summary>
	public decimal? RefundAmount { get; set; }
}
