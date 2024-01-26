using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Digiflow.Payment.Enums;

/// <summary>
/// 交易幣別
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum Currency
{
	/// <summary>
	/// 新台幣
	/// </summary>
	[Description("TWD")] TWD = 1
}
