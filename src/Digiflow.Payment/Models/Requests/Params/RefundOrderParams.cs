namespace Digiflow.Payment.Models.Requests.Params;

internal class RefundOrderParams : QueryOrderParams
{
	public string? currency { get; set; }
	public string? refund_amount { get; set; }
}
