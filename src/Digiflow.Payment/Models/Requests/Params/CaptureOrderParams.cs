namespace Digiflow.Payment.Models.Requests.Params;

internal class CaptureOrderParams : QueryOrderParams
{
	public string? currency { get; set; }
	public string? capture_amount { get; set; }
}
