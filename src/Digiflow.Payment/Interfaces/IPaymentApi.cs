using Digiflow.Payment.Models.Requests.Params;
using Digiflow.Payment.Models.Responses;
using Refit;

namespace Digiflow.Payment.Interfaces;

[Headers("User-Agent: Digiflow.PaymentApi", "Accept: application/json")]
internal interface IPaymentApi
{
	[Post("/order")]
	[Headers("Content-Type: application/x-www-form-urlencoded;charset=utf-8")]
	Task<ApiResponse<CreateOrderModel>> CreateOrderAsync([Query] CreateOrderParams data);
}
