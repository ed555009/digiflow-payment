namespace Digiflow.Payment.Models.Requests.Params;

public class CreateOrderParams : BaseQueryParam
{
	public string? order_id { get; set; }
	public string? currency { get; set; }
	public string? order_amount { get; set; }
	public string? order_desc { get; set; }
	public string? expiry_time { get; set; }
	public string? payment_type { get; set; }
	public string? member_id { get; set; }
	public string? buyer_mail { get; set; }
	public string? ext_data { get; set; }
}
