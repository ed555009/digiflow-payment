namespace Digiflow.Payment.Tests;

public class PaymentServiceTests : BaseServiceTests
{
	private readonly Mock<IPaymentApi> _paymentApiMock;
	private readonly IPaymentService _paymentService;
	private readonly SignService _signService;

	public PaymentServiceTests(ITestOutputHelper testOutputHelper) : base(testOutputHelper)
	{
		_signService = new SignService(Mock.Of<ILogger<SignService>>(), PaymentApiConfig);
		_paymentApiMock = new Mock<IPaymentApi>();
		_paymentService = new PaymentService(_paymentApiMock.Object, _signService);
	}

	[Fact]
	public async Task CancelOrderAsync_ShouldSucceed()
	{
		// Given
		_ = _paymentApiMock
			.Setup(x => x.CancelOrderAsync(It.IsAny<QueryOrderParams>()))
			.Returns(CreateResponse<CancelOrderModel>(HttpStatusCode.OK));

		// When
		var result = await _paymentService.CancelOrderAsync(new Models.Requests.QueryOrderModel());

		// Then
		Assert.Equal(HttpStatusCode.OK, result.StatusCode);
	}

	[Fact]
	public async Task CaptureOrderAsync_ShouldSucceed()
	{
		// Given
		_ = _paymentApiMock
			.Setup(x => x.CaptureOrderAsync(It.IsAny<CaptureOrderParams>()))
			.Returns(CreateResponse<CaptureOrderModel>(HttpStatusCode.OK));

		// When
		var result = await _paymentService.CaptureOrderAsync(new Models.Requests.CaptureOrderModel());

		// Then
		Assert.Equal(HttpStatusCode.OK, result.StatusCode);
	}

	[Fact]
	public async Task CreateOrderAsync_ShouldSucceed()
	{
		// Given
		_ = _paymentApiMock
			.Setup(x => x.CreateOrderAsync(It.IsAny<CreateOrderParams>()))
			.Returns(CreateResponse<CreateOrderModel>(HttpStatusCode.OK));

		// When
		var result = await _paymentService.CreateOrderAsync(new Models.Requests.CreateOrderModel());

		// Then
		Assert.Equal(HttpStatusCode.OK, result.StatusCode);
	}

	[Fact]
	public async Task QueryOrderAsync_ShouldSucceed()
	{
		// Given
		_ = _paymentApiMock
			.Setup(x => x.QueryOrderAsync(It.IsAny<QueryOrderParams>()))
			.Returns(CreateResponse<QueryOrderModel>(HttpStatusCode.OK));

		// When
		var result = await _paymentService.QueryOrderAsync(new Models.Requests.QueryOrderModel());

		// Then
		Assert.Equal(HttpStatusCode.OK, result.StatusCode);
	}

	[Fact]
	public async Task RefundOrderAsync_ShouldSucceed()
	{
		// Given
		_ = _paymentApiMock
			.Setup(x => x.RefundOrderAsync(It.IsAny<RefundOrderParams>()))
			.Returns(CreateResponse<RefundOrderModel>(HttpStatusCode.OK));

		// When
		var result = await _paymentService.RefundOrderAsync(new Models.Requests.RefundOrderModel());

		// Then
		Assert.Equal(HttpStatusCode.OK, result.StatusCode);
	}
}
