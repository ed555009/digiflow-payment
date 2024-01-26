using Digiflow.Payment.Extensions;
using Digiflow.Payment.Interfaces;
using Digiflow.Payment.Models.Requests.Params;
using Digiflow.Payment.Models.Responses;
using Refit;

namespace Digiflow.Payment.Services;

public sealed class PaymentService : IPaymentService
{
	private readonly ISignService _signService;
	private readonly IPaymentApi _paymentApi;

	public PaymentService(IPaymentApi paymentApi, ISignService signService)
	{
		_paymentApi = paymentApi;
		_signService = signService;
	}

	public async Task<ApiResponse<CancelOrderModel>> CancelOrderAsync(Models.Requests.QueryOrderModel data) =>
		await _paymentApi.CancelOrderAsync(SignParam<QueryOrderParams>(new QueryOrderParams
		{
			order_no = data.OrderNo,
			timestamp = data.Timestamp
		}));

	public async Task<ApiResponse<CaptureOrderModel>> CaptureOrderAsync(Models.Requests.CaptureOrderModel data) =>
		await _paymentApi.CaptureOrderAsync(SignParam<CaptureOrderParams>(new CaptureOrderParams
		{
			order_no = data.OrderNo,
			currency = data.Currency.ToDescription(),
			capture_amount = ((int)((data.CaptureAmount ?? 0) * 100m)).ToString(),
			timestamp = data.Timestamp
		}));

	public async Task<ApiResponse<CreateOrderModel>> CreateOrderAsync(Models.Requests.CreateOrderModel data) =>
		await _paymentApi.CreateOrderAsync(SignParam<CreateOrderParams>(new CreateOrderParams
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
		}));

	public async Task<ApiResponse<QueryOrderModel>> QueryOrderAsync(Models.Requests.QueryOrderModel data) =>
		await _paymentApi.QueryOrderAsync(SignParam<QueryOrderParams>(new QueryOrderParams
		{
			order_no = data.OrderNo,
			timestamp = data.Timestamp
		}));

	public async Task<ApiResponse<RefundOrderModel>> RefundOrderAsync(Models.Requests.RefundOrderModel data) =>
		await _paymentApi.RefundOrderAsync(SignParam<RefundOrderParams>(new RefundOrderParams
		{
			order_no = data.OrderNo,
			currency = data.Currency.ToDescription(),
			refund_amount = ((int)((data.RefundAmount ?? 0) * 100m)).ToString(),
			timestamp = data.Timestamp
		}));

	T SignParam<T>(IBaseQueryParam param) where T : IBaseQueryParam
	{
		param.sign = _signService.Sign(param);

		return (T)param;
	}
}
