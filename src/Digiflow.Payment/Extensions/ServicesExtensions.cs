using Digiflow.Payment.Configs;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Digiflow.Payment.Extensions;

public static class ServicesExtensions
{
	public static IServiceCollection AddDigiflowPaymentApiConfig(
		this IServiceCollection services,
		IConfiguration configuration) =>
		services.AddSingleton(configuration.GetSection("Digiflow")
			.GetSection("PaymentApi")
			.Get<PaymentApiConfig>());

	public static IServiceCollection AddDigiflowPaymentServices(this IServiceCollection services) =>
		services;
}
