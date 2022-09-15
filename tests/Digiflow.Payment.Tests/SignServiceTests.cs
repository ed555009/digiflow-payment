using Digiflow.Payment.Models.Requests.Params;

namespace Digiflow.Payment.Tests;

public class SignServiceTests : BaseServiceTests
{
	private readonly ISignService _signService;

	public SignServiceTests(ITestOutputHelper testOutputHelper) : base(testOutputHelper) =>
		_signService = new SignService(Mock.Of<ILogger<SignService>>(), PaymentApiConfig);

	[Fact]
	public void Sign_ShouldSucceed()
	{
		// Given
		var param = new CreateOrderParams
		{
			order_no = "ON2016110100001",
			currency = "TWD",
			order_amount = "10000",
			order_desc = "商品名稱",
			expiry_time = "20170407161609",
			buyer_mail = "cs@digiflowtech.com",
			ext_data = "AP01",
			timestamp = "1491549369718"
		};

		// When
		var sign = _signService.Sign(param);

		TestOutputHelper.WriteLine(sign);

		// Then
		Assert.Equal("Wve/GBwR/D0xSudNKj6jYIdXYRkijU4N8765/L9ZtIo=", sign);
	}
}
