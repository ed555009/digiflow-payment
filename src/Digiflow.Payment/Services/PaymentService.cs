using System.Security.Cryptography;
using System.Text;
using Digiflow.Payment.Configs;
using Digiflow.Payment.Extensions;
using Digiflow.Payment.Interfaces;
using Digiflow.Payment.Models.Requests.Params;
using Digiflow.Payment.Models.Responses;
using Microsoft.Extensions.Logging;
using Refit;

namespace Digiflow.Payment.Services;

public class PaymentService : IPaymentService
{
	private readonly ILogger<PaymentService> _logger;
	private readonly PaymentApiConfig _paymentApiConfig;
	private readonly IPaymentApi _paymentApi;

	public PaymentService(ILogger<PaymentService> logger, PaymentApiConfig paymentApiConfig)
	{
		_logger = logger;
		_paymentApiConfig = paymentApiConfig;

		ValidateConfig();

		_paymentApi = RestService.For<IPaymentApi>($"{paymentApiConfig.BaseUrl}/universal");
	}

	public async Task<ApiResponse<CreateOrderModel>> CreateOrderAsync(Models.Requests.CreateOrderModel data)
	{
		var param = new CreateOrderParams
		{
			// version = _paymentApiConfig.Version,
			// merchant_id = _paymentApiConfig.MerchantId,
			// terminal_id = _paymentApiConfig.TerminalId,
			order_id = data.OrderId,
			currency = data.Currency.ToDescription(),
			order_amount = ((int)((data.Amount ?? 0) * 100m)).ToString(),
			order_desc = data.Description,
			expiry_time = data.ExpiryTime,
			payment_type = ((int)data.PaymentType).ToString(),
			member_id = data.MemberId,
			buyer_mail = data.BuyerEmail,
			ext_data = data.ExtraData,
			timestamp = data.Timestamp
		};

		var signString = GetSignString(param);
		using var sha256 = SHA256.Create();
		param.sign = Convert.ToBase64String(sha256.ComputeHash(new UTF8Encoding().GetBytes(signString)));

		return await _paymentApi.CreateOrderAsync(param);
	}

	void ValidateConfig()
	{
		ArgumentNullException.ThrowIfNull(_paymentApiConfig.MerchantId, nameof(_paymentApiConfig.MerchantId));
		ArgumentNullException.ThrowIfNull(_paymentApiConfig.TerminalId, nameof(_paymentApiConfig.TerminalId));
		ArgumentNullException.ThrowIfNull(_paymentApiConfig.SignKey, nameof(_paymentApiConfig.SignKey));
	}

	string GetSignString(IBaseQueryParam param)
	{
		param.version = _paymentApiConfig.Version;
		param.merchant_id = _paymentApiConfig.MerchantId;
		param.terminal_id = _paymentApiConfig.TerminalId;

		return $"{param.ToOrderedValuesString()}&key={_paymentApiConfig.SignKey}";
	}
}
