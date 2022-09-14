using Digiflow.Payment.Interfaces;

namespace Digiflow.Payment.Models.Requests.Params;

public abstract class BaseQueryParam : IBaseQueryParam
{
	public string? version { get; set; }
	public string? merchant_id { get; set; }
	public string? terminal_id { get; set; }
	public string? timestamp { get; set; }
	public string? sign { get; set; }
}
