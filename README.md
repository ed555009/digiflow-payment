[![GitHub](https://img.shields.io/github/license/ed555009/digiflow-payment)](LICENSE)
[![Nuget](https://img.shields.io/nuget/v/Digiflow.Payment)](https://www.nuget.org/packages/Digiflow.Payment)
![Build Status](https://dev.azure.com/edwang/github/_apis/build/status/digiflow-payment?branchName=master)
![Coverage](http://direct.link2me.com.tw:9000/api/project_badges/measure?project=digiflow-payment&metric=coverage&token=95805a959d9a4f677e86d05e661162260125d9f4)
![Quality Gate Status](http://direct.link2me.com.tw:9000/api/project_badges/measure?project=digiflow-payment&metric=alert_status&token=95805a959d9a4f677e86d05e661162260125d9f4)
![Reliability Rating](http://direct.link2me.com.tw:9000/api/project_badges/measure?project=digiflow-payment&metric=reliability_rating&token=95805a959d9a4f677e86d05e661162260125d9f4)
![Security Rating](http://direct.link2me.com.tw:9000/api/project_badges/measure?project=digiflow-payment&metric=security_rating&token=95805a959d9a4f677e86d05e661162260125d9f4)
![Vulnerabilities](http://direct.link2me.com.tw:9000/api/project_badges/measure?project=digiflow-payment&metric=vulnerabilities&token=95805a959d9a4f677e86d05e661162260125d9f4)

# Digiflow.Payment

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

### Add configs & services

```csharp
using Digiflow.Payment.Extensions;

ConfigureServices(IServiceCollection services, IConfiguration Configuration)
{
	services
		.AddDigiflowPaymentApiConfig(Configuration)
		.AddDigiflowPaymentServices();
}
```

`AddDigiflowPaymentServices()` injects as SINGLETON, for web application, you can inject as SCOPED use `AddScopedDigiflowPaymentServices()` instead.

# Reference

- [數位鎏-電商通用收款API](docs/數位鎏-電商通用收款API-V1.0.9.pdf)
