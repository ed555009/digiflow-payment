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

	/// <summary>
	/// 信用卡退款<br/>
	/// 商店可以使用此交易退款給信用卡付款的消費者<br/>
	/// 注意：<br/>
	/// 1. 已請款過的訂單才能執行退款作業<br/>
	/// 2. 超過消費者付款時間 60 天的訂單不能進行退款<br/>
	/// 3. 每筆訂單只能執行一次退款作業，退款金額必須等於或小於請款金額<br/>
	/// 4. 信用卡分期交易只能全額退款
	/// </summary>
	Task<ApiResponse<RefundOrderModel>> RefundOrderAsync(Models.Requests.RefundOrderModel data);
}
