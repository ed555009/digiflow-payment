namespace Digiflow.Payment.Configs;

/// <summary>
/// Payment API configuration
/// </summary>
public class PaymentApiConfig
{
	/// <summary>
	/// 商店編號
	/// </summary>
	public string? MerchantId { get; set; }

	/// <summary>
	/// 終端編號
	/// </summary>
	public string? TerminalId { get; set; }

	/// <summary>
	/// 交易密鑰
	/// </summary>
	public string? SignKey { get; set; }
}
