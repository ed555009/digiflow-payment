using Newtonsoft.Json;

namespace Digiflow.Payment.Models.Responses;

public class BaseResponseModel
{
	/// <summary>
	/// 交易結果<br/>
	/// 000000 表示交易成功，其它表示交易失敗
	/// </summary>
	[JsonProperty("return_code")]
	public string? ReturnCode { get; set; }

	/// <summary>
	/// 交易結果說明
	/// </summary>
	[JsonProperty("return_msg")]
	public string? ReturnMessage { get; set; }
}
