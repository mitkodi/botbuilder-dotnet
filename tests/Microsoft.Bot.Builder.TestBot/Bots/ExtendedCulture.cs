using System;
using System.Linq;
using Microsoft.Bot.Builder.Dialogs;

namespace My.Bot.Builder.Localization
{
    /// <summary>
    /// Represents not included in <see cref="Microsoft.Recognizers.Text.Culture"/> cultures.
    /// </summary>
    /// <remarks>
    /// The code structure is identical to the corresponding code in <see cref="Microsoft.Recognizers.Text.Culture"/>.
    /// </remarks>
    public class ExtendedCulture {
        public const string Bulgarian = "bg-bg";

        public static readonly ExtendedCulture[] ExtendedCultures = {
            new ExtendedCulture("Bulgarian", Bulgarian ),
        };

        private static readonly string[] ExtendedCultureCodes = ExtendedCultures.Select(c => c.CultureCode).ToArray();

        private ExtendedCulture(string cultureName, string cultureCode) {
            CultureName = cultureName;
            CultureCode = cultureCode;
        }

        public string CultureName { get; }

        public string CultureCode { get; }

        public string[] GetExtendedCultureCodes() {
            return ExtendedCultureCodes;
        }

        public static string GetNearestLanguage(string cultureCode) {
            cultureCode = cultureCode.ToLowerInvariant();
            if (ExtendedCultureCodes.All(c => c != cultureCode)) {
                var fallbackCultureCodes = ExtendedCultureCodes
                    .Where(c => c.EndsWith("-*") && cultureCode.StartsWith(c.Split("-").First())).ToList();
                if (fallbackCultureCodes.Count == 1)
                    return fallbackCultureCodes.First();

                fallbackCultureCodes = ExtendedCultureCodes.Where(c => cultureCode.StartsWith(c.Split("-").First())).ToList();
                if (fallbackCultureCodes.Any())
                    return fallbackCultureCodes.First();

                return null;
            }

            return cultureCode;
        }

        public static ConfirmPrompt CreateConfirmPrompt(string dialogId, string locale, PromptValidator<bool> validator = null) {
            if (locale == null)
                throw new ArgumentNullException(nameof(locale));

            var extendedCulture = ExtendedCulture.GetNearestLanguage(locale);
            if (extendedCulture == null)
                throw new ArgumentException($"'{locale}' is not an ExtendedCulture.", nameof(locale));

            var defaults = ExtendedCultureDefaults.ConfirmChoices[extendedCulture];
            return new ConfirmPrompt(dialogId, validator, extendedCulture) {
                ChoiceOptions = defaults.Item3,
                ConfirmChoices = Tuple.Create(defaults.Item1, defaults.Item2)
            };
        }

    }
}
