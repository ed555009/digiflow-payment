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

	/// <summary>
	/// 信用卡取消<br/>
	/// 商店在確認無法履行服務或交付商品時，應即時使用此交易取消訂單<br/>
	/// 注意：<br/>
	/// 1. 僅支持以信用卡付款的訂單執行取消交易<br/>
	/// 2. 數位鎏收到取消訂單的指示後，會立即將支付款項退回消費者支付所使用的信用卡
	/// </summary>
	Task<ApiResponse<CancelOrderModel>> CancelOrderAsync(Models.Requests.QueryOrderModel data);
}
