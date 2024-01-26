# Digiflow.Payment

[![GitHub](https://img.shields.io/github/license/ed555009/digiflow-payment)](LICENSE)
![Build Status](https://dev.azure.com/edwang/github/_apis/build/status/digiflow-payment?branchName=master)
[![Nuget](https://img.shields.io/nuget/v/Digiflow.Payment)](https://www.nuget.org/packages/Digiflow.Payment)

![Coverage](https://sonarcloud.io/api/project_badges/measure?project=digiflow-payment&metric=coverage)
![Quality Gate Status](https://sonarcloud.io/api/project_badges/measure?project=digiflow-payment&metric=alert_status)
![Reliability Rating](https://sonarcloud.io/api/project_badges/measure?project=digiflow-payment&metric=reliability_rating)
![Security Rating](https://sonarcloud.io/api/project_badges/measure?project=digiflow-payment&metric=security_rating)
![Vulnerabilities](https://sonarcloud.io/api/project_badges/measure?project=digiflow-payment&metric=vulnerabilities)


## Installation

```bash
dotnet add package Digiflow.Payment
```

## Configuration

### Appsettings.json

```json
{
	"Digiflow": {
		"PaymentApi": {
			"BaseUrl": "https://ta.digiflowtech.com",
			"Version": "1.0",
			"MerchantId": "YOUR_MERCHANT_ID",
			"TerminalId": "YOUR_TERMINAL_ID",
			"SignKey": "YOUR_SIGN_KEY"
		}
	}
}
```

### Add services

```csharp
using Digiflow.Payment.Extensions;

ConfigureServices(IServiceCollection services, IConfiguration configuration)
{
	// this injects as SINGLETON
	services.AddDigiflowPaymentServices(configuration);

	// you can also inject as SCOPED or TRANSIENT by specifying the ServiceLifetime
	services.AddDigiflowPaymentServices(configuration, ServiceLifetime.Scoped);
}
```

# Reference

- [數位鎏-電商通用收款API](docs/數位鎏-電商通用收款API-V1.0.9.pdf)
