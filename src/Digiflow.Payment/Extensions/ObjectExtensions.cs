using System.Text;

namespace Digiflow.Payment.Extensions;

public static class ObjectExtensions
{
	public static string ToOrderedValuesString(this object obj)
	{
		var dictionary = obj.GetType()
			.GetProperties()
			.ToDictionary(x => x.Name, x => x.GetValue(obj, null))
			.OrderBy(x => x.Key)
			.ToDictionary(x => x.Key, x => x.Value);

		var sb = new StringBuilder();

		foreach (var property in dictionary)
		{
			// Ignore sign & null value
			if (property.Key == "sign" || property.Value == null)
				continue;

			sb.Append($"{property.Key}={property.Value}&");
		}

		return sb.ToString().TrimEnd('&');
	}
}
