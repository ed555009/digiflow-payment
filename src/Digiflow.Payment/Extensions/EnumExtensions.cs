using System.Reflection;

namespace Digiflow.Payment.Extensions;

public static class EnumExtensions
{
	public static string ToDescription(this Enum value) =>
		value.GetType()?
			.GetRuntimeField(value.ToString())?
			.GetCustomAttributes<System.ComponentModel.DescriptionAttribute>()
			.FirstOrDefault()?.Description ?? string.Empty;

	public static void ValidateType(this Enum value, Type valueType, bool allowNull = false)
	{
		if (!allowNull && value == null)
			throw new ArgumentNullException($"{value} cannot be null");

		if (!Enum.IsDefined(valueType, value))
			throw new KeyNotFoundException($"{value} not avaliable");
	}
}
