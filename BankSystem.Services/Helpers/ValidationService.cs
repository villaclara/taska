using System.Globalization;
using System.Text.RegularExpressions;

namespace BankSystem.Services.Helpers;

public static class ValidatorService
{
    public static bool IsCurrencyValid(string currency)
    {
        if (string.IsNullOrWhiteSpace(currency))
        {
            return false;
        }

        currency = currency.ToUpperInvariant();

        // Get all distinct ISO currency symbols from all cultures
        var currencies = CultureInfo
            .GetCultures(CultureTypes.SpecificCultures)
            .Select(culture => new RegionInfo(culture.Name).ISOCurrencySymbol)
            .Where(symbol => !string.IsNullOrEmpty(symbol))
            .Distinct();

        return currencies.Contains(currency);
    }

    public static bool IsEmailValid(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
        {
            return false;
        }

        // Simple RFC 5322 compliant regex pattern
        const string pattern =
            @"^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+" +
            @"@[a-zA-Z0-9-]+(\.[a-zA-Z0-9-]+)*$";

        return Regex.IsMatch(email, pattern, RegexOptions.IgnoreCase);
    }
}
