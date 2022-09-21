namespace Digiflow.Payment.Interfaces;

public interface IBaseResponseModel
{
	string? ReturnCode { get; set; }
	string? ReturnMessage { get; set; }
}
