namespace Digiflow.Payment.Interfaces;

public interface IBaseRequestModel
{
	string? Version { get; set; }
	string? MerchantId { get; set; }
	string? TerminalId { get; set; }
	string Timestamp { get; set; }
}
