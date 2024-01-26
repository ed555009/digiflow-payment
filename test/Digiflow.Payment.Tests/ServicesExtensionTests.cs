
using System.Text.Json;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using System.Text;
using Digiflow.Payment.Extensions;

namespace Digiflow.Payment.Tests;

public class ServicesExtensionTests : BaseServiceTests
{
	private readonly string _settings;
	private readonly string _nullSettings;

	public ServicesExtensionTests(ITestOutputHelper testOutputHelper) : base(testOutputHelper)
	{
		_settings = JsonSerializer.Serialize(new
		{
			Digiflow = new
			{
				PaymentApi = new
				{
					PaymentApiConfig.BaseUrl,
					PaymentApiConfig.Version,
					PaymentApiConfig.MerchantId,
					PaymentApiConfig.TerminalId,
					PaymentApiConfig.SignKey
				}
			}
		});

		_nullSettings = JsonSerializer.Serialize(new
		{
			Digiflow = new
			{
				PaymentApi = new
				{
				}
			}
		});
	}

	[Fact]
	public void AddDigiflowPaymentServices_ShouldSucceed()
	{
		// Given
		var services = new ServiceCollection();
		var builder = new ConfigurationBuilder();
		var configuration = builder.AddJsonStream(new MemoryStream(Encoding.UTF8.GetBytes(_settings))).Build();

		// When
		ServicesExtensions.AddDigiflowPaymentServices(services, configuration);

		// Then
		Assert.Contains(services, x => x.ServiceType == typeof(PaymentApiConfig));

		Assert.Contains(services, x => x.ServiceType == typeof(IPaymentApi));

		Assert.Contains(services, x => x.ServiceType == typeof(IPaymentService)
								 && x.ImplementationType == typeof(PaymentService));

		Assert.Contains(services, x => x.ServiceType == typeof(ISignService)
								 && x.ImplementationType == typeof(SignService));
	}

	[Fact]
	public void AddDigiflowPaymentServices_WithNullConfig_ShouldThrow()
	{
		// Given
		var services = new ServiceCollection();
		var builder = new ConfigurationBuilder();
		var configuration = builder.AddJsonStream(new MemoryStream(Encoding.UTF8.GetBytes(_nullSettings))).Build();

		// When
		var ex = Assert.Throws<NullReferenceException>(() =>
			ServicesExtensions.AddDigiflowPaymentServices(services, configuration));

		// Then
		Assert.NotNull(ex);
	}
}
