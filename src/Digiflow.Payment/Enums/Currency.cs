using System.ComponentModel;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Digiflow.Payment.Enums;

/// <summary>
/// 交易幣別
/// </summary>
[JsonConverter(typeof(StringEnumConverter))]
public enum Currency
{
	/// <summary>
	/// 新台幣
	/// </summary>
	[Description("TWD")] TWD = 1
}
