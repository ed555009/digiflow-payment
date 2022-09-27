namespace Digiflow.Payment.Configs;

/// <summary>
/// Payment API configuration
/// </summary>
public class PaymentApiConfig
{
	/// <summary>
	/// API base url<br/>
	/// 預設為測試環境
	/// </summary>
	public string BaseUrl { get; set; } = "https://ta.digiflowtech.com";

	/// <summary>
	/// API版本
	/// </summary>
	public string? Version { get; set; } = "1.0";

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
