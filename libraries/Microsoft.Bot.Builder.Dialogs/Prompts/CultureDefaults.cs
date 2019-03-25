using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Bot.Builder.Dialogs.Choices;
using Microsoft.Recognizers.Text.Choice;
using static Microsoft.Recognizers.Text.Culture;

namespace Microsoft.Bot.Builder.Dialogs
{
    public class CultureDefaults
    {
        protected static readonly Dictionary<string, ChoiceFactoryOptions> ChoiceOptionsBase = new Dictionary<string, ChoiceFactoryOptions>()
        {
            { Spanish, new ChoiceFactoryOptions { InlineSeparator = ", ", InlineOr = " o ", InlineOrMore = ", o ", IncludeNumbers = true } },
            { Dutch, new ChoiceFactoryOptions { InlineSeparator = ", ", InlineOr = " of ", InlineOrMore = ", of ", IncludeNumbers = true } },
            { English, new ChoiceFactoryOptions { InlineSeparator = ", ", InlineOr = " or ", InlineOrMore = ", or ", IncludeNumbers = true } },
            { French, new ChoiceFactoryOptions { InlineSeparator = ", ", InlineOr = " ou ", InlineOrMore = ", ou ", IncludeNumbers = true } },
            { German, new ChoiceFactoryOptions { InlineSeparator = ", ", InlineOr = " oder ", InlineOrMore = ", oder ", IncludeNumbers = true } },
            { Japanese, new ChoiceFactoryOptions { InlineSeparator = "、 ", InlineOr = " または ", InlineOrMore = "、 または ", IncludeNumbers = true } },
            { Portuguese, new ChoiceFactoryOptions { InlineSeparator = ", ", InlineOr = " ou ", InlineOrMore = ", ou ", IncludeNumbers = true } },
            { Chinese, new ChoiceFactoryOptions { InlineSeparator = "， ", InlineOr = " 要么 ", InlineOrMore = "， 要么 ", IncludeNumbers = true } },
        };

        protected static readonly Dictionary<string, (Choice, Choice, ChoiceFactoryOptions)> ConfirmChoicesBase = new Dictionary<string, (Choice, Choice, ChoiceFactoryOptions)>()
        {
            { Spanish, (new Choice("Sí"), new Choice("No"), ChoiceOptionsBase[Spanish]) },
            { Dutch, (new Choice("Ja"), new Choice("Nee"), ChoiceOptionsBase[Dutch]) },
            { English, (new Choice("Yes"), new Choice("No"), ChoiceOptionsBase[English]) },
            { French, (new Choice("Oui"), new Choice("Non"), ChoiceOptionsBase[French]) },
            { German, (new Choice("Ja"), new Choice("Nein"), ChoiceOptionsBase[German]) },
            { Japanese, (new Choice("はい"), new Choice("いいえ"), ChoiceOptionsBase[Japanese]) },
            { Portuguese, (new Choice("Sim"), new Choice("Não"), ChoiceOptionsBase[Portuguese]) },
            { Chinese, (new Choice("是的"), new Choice("不"), ChoiceOptionsBase[Chinese]) },
        };

        protected internal Dictionary<string, ChoiceFactoryOptions> ChoiceOptions
        {
            get { return ChoiceOptionsBase; }
        }

        protected internal Dictionary<string, (Choice, Choice, ChoiceFactoryOptions)> ConfirmChoices
        {
            get { return ConfirmChoicesBase; }
        }

        public virtual bool? RecognizeBoolean(string text, string culture, string defaultCulture)
        {
            // By default use Microsoft.Recognizers.Text
            var results = ChoiceRecognizer.RecognizeBoolean(text, culture);
            if (results.Count > 0)
            {
                var first = results[0];
                if (bool.TryParse(first.Resolution["value"].ToString(), out var value))
                {
                    return value;
                }
            }

            return null;
        }
    }
}
