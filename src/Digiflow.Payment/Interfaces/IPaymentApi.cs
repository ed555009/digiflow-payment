using Digiflow.Payment.Models.Requests.Params;
using Digiflow.Payment.Models.Responses;
using Refit;

namespace Digiflow.Payment.Interfaces;

[Headers("User-Agent: Digiflow.PaymentApi",
	"Accept: application/json",
	"Content-Type: application/x-www-form-urlencoded;charset=utf-8")]
internal interface IPaymentApi
{
	[Post("/order")]
	Task<ApiResponse<CreateOrderModel>> CreateOrderAsync([Query] CreateOrderParams data);

	[Post("query")]
	Task<ApiResponse<QueryOrderModel>> QueryOrderAsync([Query] QueryOrderParams data);
}
