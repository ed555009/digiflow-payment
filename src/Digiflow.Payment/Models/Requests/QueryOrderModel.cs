using System.ComponentModel.DataAnnotations;

namespace Digiflow.Payment.Models.Requests;

public class QueryOrderModel : BaseRequestModel
{
	/// <summary>
	/// 商店訂單編號
	/// </summary>
	[MaxLength(32)]
	public string? OrderNo { get; set; }
}
