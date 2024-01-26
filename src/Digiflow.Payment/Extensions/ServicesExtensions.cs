using System.Text.Json;
using System.Text.Json.Serialization;
using Digiflow.Payment.Configs;
using Digiflow.Payment.Interfaces;
using Digiflow.Payment.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Refit;

namespace Digiflow.Payment.Extensions;

public static class ServicesExtensions
{
	public static IServiceCollection AddDigiflowPaymentServices(
		this IServiceCollection services,
		IConfiguration configuration,
		ServiceLifetime serviceLifetime = ServiceLifetime.Singleton)
	{
		var config = GetPaymentApiConfig(configuration);
		var refitSettings = GetRefitSettings();

		_ = services
			.AddSingleton(config)
			.AddRefitClient<IPaymentApi>(refitSettings)
			.ConfigureHttpClient(c => c.BaseAddress = new Uri($"{config.BaseUrl}/universal"));

		switch (serviceLifetime)
		{
			case ServiceLifetime.Scoped:
				services.AddScoped<IPaymentService, PaymentService>();
				services.AddScoped<ISignService, SignService>();
				break;
			case ServiceLifetime.Transient:
				services.AddTransient<IPaymentService, PaymentService>();
				services.AddTransient<ISignService, SignService>();
				break;
			default:
				services.AddSingleton<IPaymentService, PaymentService>();
				services.AddSingleton<ISignService, SignService>();
				break;
		}

		return services;
	}

	static PaymentApiConfig GetPaymentApiConfig(IConfiguration configuration) =>
		configuration
			.GetSection("Digiflow")
			.GetSection("PaymentApi")
			.Get<PaymentApiConfig>()
				?? throw new ArgumentNullException(nameof(configuration), "Could not find Digiflow Payment Api config");

	static RefitSettings GetRefitSettings() =>
		new()
		{
			ContentSerializer = new SystemTextJsonContentSerializer(new JsonSerializerOptions
			{
				Converters =
				{
					new JsonStringEnumConverter()
				},
				PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
				DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
				ReferenceHandler = ReferenceHandler.IgnoreCycles,
				NumberHandling = JsonNumberHandling.AllowReadingFromString,
				PropertyNameCaseInsensitive = true
			})
		};
}
