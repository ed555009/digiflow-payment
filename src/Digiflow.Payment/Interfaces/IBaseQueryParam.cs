namespace Digiflow.Payment.Interfaces;

public interface IBaseQueryParam
{
	string? version { get; set; }
	string? merchant_id { get; set; }
	string? terminal_id { get; set; }
	string? timestamp { get; set; }
	string? sign { get; set; }
}
