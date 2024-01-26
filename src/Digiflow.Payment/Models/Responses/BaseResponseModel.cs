using System.Text.Json.Serialization;
using Digiflow.Payment.Interfaces;

namespace Digiflow.Payment.Models.Responses;

public abstract class BaseResponseModel : IBaseResponseModel
{
	/// <summary>
	/// 交易結果<br/>
	/// 000000 表示交易成功，其它表示交易失敗
	/// </summary>
	[JsonPropertyName("return_code")]
	public string? ReturnCode { get; set; }

	/// <summary>
	/// 交易結果說明
	/// </summary>
	[JsonPropertyName("return_msg")]
	public string? ReturnMessage { get; set; }
}
