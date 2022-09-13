using System.ComponentModel.DataAnnotations;
using Digiflow.Payment.Enums;
using Refit;

namespace Digiflow.Payment.Models.Requests.Params;

public class CreateOrderParams
{
	[AliasAs("version")]
	[MaxLength(3)]
	public string? Version { get; set; } = "1.0";

	[AliasAs("merchant_id")]
	[MaxLength(15)]
	public string? MerchantId { get; set; }

	[AliasAs("terminal_id")]
	[MaxLength(8)]
	public string? TerminalId { get; set; }

	[AliasAs("order_id")]
	[MaxLength(32)]
	public string? OrderId { get; set; }

	[AliasAs("currency")]
	public Currency Currency { get; set; } = Currency.TWD;

	[AliasAs("order_amount")]
	public int Amount { get; set; }

	[AliasAs("order_desc")]
	[MaxLength(64)]
	public string? Description { get; set; }

	[AliasAs("expiry_time")]
	public string ExpiryTime { get; set; } = $"{DateTime.UtcNow.AddHours(8).AddDays(1):yyyyMMddHHmmss}";

	[AliasAs("payment_type")]
	public string? PaymentType { get; set; } = null;

	[AliasAs("member_id")]
	[MaxLength(48)]
	public string? MemberId { get; set; } = null;

	[AliasAs("buyer_mail")]
	[EmailAddress, MaxLength(48)]
	public string? BuyerEmail { get; set; } = null;

	[AliasAs("ext_data")]
	[MaxLength(256)]
	public string? ExtraData { get; set; } = null;

	[AliasAs("timestamp")]
	public static string Timestamp =>
		((long)(DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds).ToString();

	[AliasAs("sign")]
	[MaxLength(64)]
	public string? Sign { get; set; }
}
