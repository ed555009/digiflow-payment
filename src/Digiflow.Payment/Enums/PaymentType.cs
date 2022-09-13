using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Digiflow.Payment.Enums;

/// <summary>
/// 付款方式
/// </summary>
[JsonConverter(typeof(StringEnumConverter))]
public enum PaymentType
{
	/// <summary>
	/// 信用卡一般
	/// </summary>
	[EnumMember(Value = "111")]
	CreditCard = 111,

	/// <summary>
	/// 信用卡分期
	/// </summary>
	[EnumMember(Value = "112")]
	CreditCardInstallment = 112,

	/// <summary>
	/// 銀聯卡
	/// </summary>
	[EnumMember(Value = "113")]
	UnionPay = 113,

	/// <summary>
	/// ApplePay
	/// </summary>
	[EnumMember(Value = "120")]
	ApplePay = 120,

	/// <summary>
	/// GooglePay
	/// </summary>
	[EnumMember(Value = "130")]
	AndroidPay = 130,

	/// <summary>
	/// SamsungPay
	/// </summary>
	[EnumMember(Value = "140")]
	SamsungPay = 140,

	/// <summary>
	/// 虛擬帳號
	/// </summary>
	[EnumMember(Value = "150")]
	VirtualAccount = 150,

	/// <summary>
	/// 金融帳戶扣款
	/// </summary>
	[EnumMember(Value = "160")]
	BankAccountDebit = 160,

	/// <summary>
	/// 超商繳款
	/// </summary>
	[EnumMember(Value = "170")]
	ConvenientStorePay = 170
}
