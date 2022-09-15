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
	private readonly ISignService _signService;
	private readonly IPaymentApi _paymentApi;

	public PaymentService(ILogger<PaymentService> logger, PaymentApiConfig paymentApiConfig, ISignService signService)
	{
		_logger = logger;
		_signService = signService;
		_paymentApi = RestService.For<IPaymentApi>($"{paymentApiConfig.BaseUrl}/universal");
	}

	public async Task<ApiResponse<CreateOrderModel>> CreateOrderAsync(Models.Requests.CreateOrderModel data)
	{
		var param = new CreateOrderParams
		{
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

		param.sign = _signService.Sign(param);

		return await _paymentApi.CreateOrderAsync(param);
	}
}
