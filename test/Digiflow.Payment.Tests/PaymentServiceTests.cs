namespace Digiflow.Payment.Tests;

public class PaymentServiceTests : BaseServiceTests
{
	private readonly Mock<IPaymentApi> _paymentApiMock;
	private readonly IPaymentService _paymentService;

	public PaymentServiceTests(ITestOutputHelper testOutputHelper) : base(testOutputHelper)
	{
		_paymentApiMock = new Mock<IPaymentApi>();
		_paymentService = new PaymentService(
			Mock.Of<ILogger<PaymentService>>(),
			PaymentApiConfig,
			Mock.Of<ISignService>());
	}

	[Fact]
	public async Task CancelOrderAsync_ShouldSucceed()
	{
		// Given
		var response = CreateResponse<CancelOrderModel>(HttpStatusCode.OK);
		_paymentApiMock.Setup(x => x.CancelOrderAsync(It.IsAny<QueryOrderParams>())).Returns(response);

		// When
		var result = await _paymentService.CancelOrderAsync(new Models.Requests.QueryOrderModel());

		// Then
		Assert.Equal(HttpStatusCode.OK, result.StatusCode);
	}

	[Fact]
	public async Task CaptureOrderAsync_ShouldSucceed()
	{
		// Given
		var response = CreateResponse<CaptureOrderModel>(HttpStatusCode.OK);
		_paymentApiMock.Setup(x => x.CaptureOrderAsync(It.IsAny<CaptureOrderParams>())).Returns(response);

		// When
		var result = await _paymentService.CaptureOrderAsync(new Models.Requests.CaptureOrderModel());

		// Then
		Assert.Equal(HttpStatusCode.OK, result.StatusCode);
	}

	[Fact]
	public async Task CreateOrderAsync_ShouldSucceed()
	{
		// Given
		var response = CreateResponse<CreateOrderModel>(HttpStatusCode.OK);
		_paymentApiMock.Setup(x => x.CreateOrderAsync(It.IsAny<CreateOrderParams>())).Returns(response);

		// When
		var result = await _paymentService.CreateOrderAsync(new Models.Requests.CreateOrderModel());

		// Then
		Assert.Equal(HttpStatusCode.OK, result.StatusCode);
	}

	[Fact]
	public async Task QueryOrderAsync_ShouldSucceed()
	{
		// Given
		var response = CreateResponse<QueryOrderModel>(HttpStatusCode.OK);
		_paymentApiMock.Setup(x => x.QueryOrderAsync(It.IsAny<QueryOrderParams>())).Returns(response);

		// When
		var result = await _paymentService.QueryOrderAsync(new Models.Requests.QueryOrderModel());

		// Then
		Assert.Equal(HttpStatusCode.OK, result.StatusCode);
	}

	[Fact]
	public async Task RefundOrderAsync_ShouldSucceedAsync()
	{
		// Given
		var response = CreateResponse<RefundOrderModel>(HttpStatusCode.Forbidden);
		_paymentApiMock.Setup(x => x.RefundOrderAsync(It.IsAny<RefundOrderParams>())).Returns(response);

		// When
		var result = await _paymentService.RefundOrderAsync(new Models.Requests.RefundOrderModel());

		// Then
		Assert.Equal(HttpStatusCode.OK, result.StatusCode);
	}

	static Task<ApiResponse<T>> CreateResponse<T>(HttpStatusCode statusCode) where T : IBaseResponseModel =>
		Task.FromResult(new ApiResponse<T>(
			new HttpResponseMessage(statusCode),
			default,
			new RefitSettings()));
}
