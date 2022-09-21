using Digiflow.Payment.Configs;
using Digiflow.Payment.Extensions;
using Digiflow.Payment.Interfaces;
using Digiflow.Payment.Models.Requests.Params;
using Digiflow.Payment.Models.Responses;
using Microsoft.Extensions.Logging;
using Refit;

namespace Digiflow.Payment.Services;

public sealed class PaymentService : IPaymentService
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

	public async Task<ApiResponse<CancelOrderModel>> CancelOrderAsync(Models.Requests.QueryOrderModel data)
	{
		var param = new QueryOrderParams
		{
			order_no = data.OrderNo,
			timestamp = data.Timestamp
		};

		param.sign = _signService.Sign(param);

		return await _paymentApi.CancelOrderAsync(param);
	}

	public async Task<ApiResponse<CreateOrderModel>> CreateOrderAsync(Models.Requests.CreateOrderModel data)
	{
		var param = new CreateOrderParams
		{
			order_no = data.OrderNo,
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

	public async Task<ApiResponse<QueryOrderModel>> QueryOrderAsync(Models.Requests.QueryOrderModel data)
	{
		var param = new QueryOrderParams
		{
			order_no = data.OrderNo,
			timestamp = data.Timestamp
		};

		param.sign = _signService.Sign(param);

		return await _paymentApi.QueryOrderAsync(param);
	}

	public async Task<ApiResponse<RefundOrderModel>> RefundOrderAsync(Models.Requests.RefundOrderModel data)
	{
		var param = new RefundOrderParams
		{
			order_no = data.OrderNo,
			refund_amount = ((int)((data.Amount ?? 0) * 100m)).ToString(),
			timestamp = data.Timestamp
		};

		param.sign = _signService.Sign(param);

		return await _paymentApi.RefundOrderAsync(param);
	}
}
