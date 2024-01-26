using System.Security.Cryptography;
using System.Text;
using Digiflow.Payment.Configs;
using Digiflow.Payment.Extensions;
using Digiflow.Payment.Interfaces;
using Microsoft.Extensions.Logging;

namespace Digiflow.Payment.Services;

public sealed class SignService : ISignService
{
	private readonly ILogger<SignService> _logger;
	private readonly PaymentApiConfig _paymentApiConfig;

	public SignService(ILogger<SignService> logger, PaymentApiConfig paymentApiConfig)
	{
		_logger = logger;
		_paymentApiConfig = paymentApiConfig;

		ValidateConfig();
	}

	public string Sign(IBaseQueryParam param)
	{
		var signString = GetSignString(param);
		using var sha256 = SHA256.Create();

		return Convert.ToBase64String(sha256.ComputeHash(new UTF8Encoding().GetBytes(signString)));
	}

	string GetSignString(IBaseQueryParam param)
	{
		param.version = _paymentApiConfig.Version;
		param.merchant_id = _paymentApiConfig.MerchantId;
		param.terminal_id = _paymentApiConfig.TerminalId;

		var signString = $"{param.ToOrderedValuesString()}&key={_paymentApiConfig.SignKey}";

		_logger.LogDebug("Param: {@Param}", param);
		_logger.LogDebug("SignString: {SignString}", signString);

		return signString;
	}

	void ValidateConfig()
	{
		ArgumentNullException.ThrowIfNull(_paymentApiConfig.MerchantId, nameof(_paymentApiConfig.MerchantId));
		ArgumentNullException.ThrowIfNull(_paymentApiConfig.TerminalId, nameof(_paymentApiConfig.TerminalId));
		ArgumentNullException.ThrowIfNull(_paymentApiConfig.SignKey, nameof(_paymentApiConfig.SignKey));
	}
}
