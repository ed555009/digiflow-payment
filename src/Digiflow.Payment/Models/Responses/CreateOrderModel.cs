using System.Text.Json.Serialization;

namespace Digiflow.Payment.Models.Responses;

public class CreateOrderModel : BaseResponseModel
{
	/// <summary>
	/// 數位鎏系統付款頁面網址
	/// </summary>
	[JsonPropertyName("payment_url")]
	public string? PaymentUrl { get; set; }
}
