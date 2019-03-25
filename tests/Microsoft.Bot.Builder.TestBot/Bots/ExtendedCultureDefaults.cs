using System.Collections.Generic;
using Microsoft.Bot.Builder.Dialogs.Choices;
using static My.Bot.Builder.Localization.ExtendedCulture;

namespace My.Bot.Builder.Localization
{
    public static class ExtendedCultureDefaults {
        public static readonly Dictionary<string, ChoiceFactoryOptions> ChoiceOptions = new Dictionary<string, ChoiceFactoryOptions> {
            { Bulgarian, new ChoiceFactoryOptions { InlineSeparator = ", ", InlineOr = " или ", InlineOrMore = ", или ", IncludeNumbers = true } },
        };

        public static readonly Dictionary<string, (Choice, Choice, ChoiceFactoryOptions)> ConfirmChoices = new Dictionary<string, (Choice, Choice, ChoiceFactoryOptions)> {
            { Bulgarian,
                (new Choice("Да") {
                    Synonyms = new List<string> {
                        "разбира се",
                        @"\b(да|йеп|д|определено|ок|ok|кей|съгласен)\b|(\uD83D\uDC4D|\uD83D\uDC4C)",
                    }
                },
                new Choice("Не") {
                    Synonyms = new List<string> { @"\b(не)\b|(\uD83D\uDC4E|\u270B|\uD83D\uDD90)" }
                },
                ChoiceOptions[Bulgarian]) },
        };
    }
}
