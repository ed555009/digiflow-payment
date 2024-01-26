using System.Text.Json.Serialization;

namespace Digiflow.Payment.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum OrderStatus
{
	/// <summary>
	/// 未付款
	/// </summary>
	Unpaid = 0,

	/// <summary>
	/// 已付款
	/// </summary>
	Paid,

	/// <summary>
	/// 已撤銷（信用卡專用）
	/// </summary>
	Cancelled,

	/// <summary>
	/// 已退款（信用卡專用）
	/// </summary>
	Refunded,
}
