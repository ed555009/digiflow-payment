using Digiflow.Payment.Models.Responses;
using Refit;

namespace Digiflow.Payment.Interfaces;

public interface IPaymentService
{
	/// <summary>
	/// 訂單登記
	/// </summary>
	Task<ApiResponse<CreateOrderModel>> CreateOrderAsync(Models.Requests.CreateOrderModel data);

	/// <summary>
	/// 訂單查詢
	/// </summary>
	Task<ApiResponse<QueryOrderModel>> QueryOrderAsync(Models.Requests.QueryOrderModel data);
}
