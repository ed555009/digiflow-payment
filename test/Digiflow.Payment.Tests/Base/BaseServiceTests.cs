namespace Digiflow.Payment.Tests;

public abstract class BaseServiceTests
{
	protected readonly ITestOutputHelper TestOutputHelper;
	protected readonly PaymentApiConfig PaymentApiConfig;

	public BaseServiceTests(ITestOutputHelper testOutputHelper)
	{
		TestOutputHelper = testOutputHelper;
		PaymentApiConfig = new PaymentApiConfig
		{
			BaseUrl = "http://localhost:5000",
			Version = "1.0",
			MerchantId = "123456789012345",
			TerminalId = "12345678",
			SignKey = "32C10AF937295BB8A414D36A45AD9DF0856FE78B1966F782C3A1E2F5BCCA634E"
		};
	}

	protected static Task<ApiResponse<T>> CreateResponse<T>(HttpStatusCode statusCode) where T : IBaseResponseModel =>
		Task.FromResult(new ApiResponse<T>(
			new HttpResponseMessage(statusCode),
			default,
			new RefitSettings()));

	protected static Task<ApiResponse<object?>> CreateEmptyResponse(HttpStatusCode statusCode) =>
		Task.FromResult(new ApiResponse<object?>(
			new HttpResponseMessage(statusCode),
			default,
			new RefitSettings()));
}
