using Newtonsoft.Json;

namespace Digiflow.Payment.Models.Responses;

public class PaymentInfoModel
{
	/// <summary>
	/// 信用卡別<br/>
	/// V:Visa<br/>
	/// M:MasterCard<br/>
	/// J:JCB<br/>
	/// C:銀聯卡<br/>
	/// 付款方式爲信用卡一般、信用卡分期時才出現
	/// </summary>
	[JsonProperty("card_brand")]
	public string? CardBrand { get; set; }

	/// <summary>
	/// 信用卡號末四碼<br/>
	/// 付款方式爲信用卡一般、信用卡分期時才出現
	/// </summary>
	[JsonProperty("card_no")]
	public string? CardNo { get; set; }

	/// <summary>
	/// 付款銀行代碼<br/>
	/// 付款方式爲虛擬帳號、金融帳戶扣款時才出現
	/// </summary>
	[JsonProperty("bank")]
	public string? Bank { get; set; }

	/// <summary>
	/// 付款銀行帳號<br/>
	/// 付款方式爲虛擬帳號、金融帳戶扣款時才出現
	/// </summary>
	[JsonProperty("account_no")]
	public string? AccountNo { get; set; }

	/// <summary>
	/// 超商別<br/>
	/// 7:統一<br/>
	/// F:全家<br/>
	/// H:萊爾富<br/>
	/// O:OK<br/>
	/// 付款方式爲超商繳款時才出現
	/// </summary>
	[JsonProperty("store")]
	public string? Store { get; set; }

	/// <summary>
	/// 分期期數<br/>
	/// 付款方式爲信用卡分期時才出現
	/// </summary>
	[JsonProperty("installment")]
	public string? Installment { get; set; }

	/// <summary>
	/// 首期金額，單位為 0.01 元<br/>
	/// 例:100 元將回傳 10000<br/>
	/// 付款方式爲信用卡分期時才出現
	/// </summary>
	[JsonProperty("first_amount")]
	public string? FirstAmount { get; set; }

	/// <summary>
	/// 每期金額，單位為 0.01 元<br/>
	/// 例:100 元將回傳 10000<br/>
	/// 付款方式爲信用卡分期時才出現
	/// </summary>
	[JsonProperty("each_amount")]
	public string? EachAmount { get; set; }

	/// <summary>
	/// 分期手續費，單位為 0.01 元<br/>
	/// 例:100 元將回傳 10000<br/>
	/// 付款方式爲信用卡分期時才出現
	/// </summary>
	[JsonProperty("installment_fee")]
	public string? InstallmentFee { get; set; }
}
