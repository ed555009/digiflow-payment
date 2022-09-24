using Digiflow.Payment.Configs;
using Digiflow.Payment.Interfaces;
using Digiflow.Payment.Services;
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
		services
			.AddSingleton<IPaymentService, PaymentService>()
			.AddSingleton<ISignService, SignService>();

	public static IServiceCollection AddScopedDigiflowPaymentServices(this IServiceCollection services) =>
		services
			.AddScoped<IPaymentService, PaymentService>()
			.AddScoped<ISignService, SignService>();
}
