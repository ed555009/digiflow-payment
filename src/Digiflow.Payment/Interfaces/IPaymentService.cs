using Digiflow.Payment.Models.Responses;
using Refit;

namespace Digiflow.Payment.Interfaces;

public interface IPaymentService
{
	/// <summary>
	/// 訂單登記<br/>
	/// 電商須使用此 API 預先在數位鎏系統登記訂單資訊<br/>
	/// 成功登記訂單後，數位鎏將會回傳訂單的付款網址，電商須將消費者瀏覽器頁面跳轉至該付款網 址進行付款的操作
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
