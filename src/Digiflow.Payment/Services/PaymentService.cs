using Digiflow.Payment.Configs;
using Digiflow.Payment.Interfaces;
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

	// public Task<ApiResponse<CreateOrderModel>> CreateOrderAsync(Models.Requests.CreateOrderModel data)
	// {
	// 	return _paymentApi.CreateOrderAsync(data);
	// }

	void ValidateConfig()
	{
		ArgumentNullException.ThrowIfNull(_paymentApiConfig.MerchantId, nameof(_paymentApiConfig.MerchantId));
		ArgumentNullException.ThrowIfNull(_paymentApiConfig.TerminalId, nameof(_paymentApiConfig.TerminalId));
		ArgumentNullException.ThrowIfNull(_paymentApiConfig.SignKey, nameof(_paymentApiConfig.SignKey));
	}
}
