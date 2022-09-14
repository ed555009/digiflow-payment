using Digiflow.Payment.Models.Responses;
using Refit;

namespace Digiflow.Payment.Interfaces;

public interface IPaymentService
{
	Task<ApiResponse<CreateOrderModel>> CreateOrderAsync(Models.Requests.CreateOrderModel data);
}
