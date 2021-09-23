using com.github.TheCSUser.Shared.UserInterface.Localization;
using com.github.TheCSUser.HideItBobby.Translation;
using System;
using com.github.TheCSUser.Shared.UserInterface.Localization.Components;

namespace com.github.TheCSUser.HideItBobby.UserInterface
{
    using static Palette;
    using static Styles;

    internal static class UIHelpers
    {
        public static LLabelComponent AddGroupHeader(this LocalizedUIBuilder builder, LocaleText text)
        {
            builder.AddSpace(12);
            var label = builder.AddLabel(text, textColor: White);
            builder.AddSpace(3);
            return label;
        }
        public static LCheckBoxComponent AddFeatureCheckbox(this LocalizedUIBuilder builder, LocaleText text, bool value, Action<bool> valueSetter)
        {
            return builder
                .AddCheckbox(text, value, (component, newValue) =>
                {
                    try
                    {
                        valueSetter(newValue);
                    }
                    catch (Exception e)
                    {
                        builder.Context.Log.Error($"{nameof(LCheckBoxComponent)}.{nameof(LCheckBoxComponent.OnCheckChanged)} {nameof(valueSetter)} failed", e);
                    }
                })
                .ApplyStyle(GrayTextOnUnchecked);
        }
        public static LCheckBoxComponent AddUnavailableFeatureCheckbox(this LocalizedUIBuilder builder, LocaleText text, bool value, Action<bool> valueSetter)
        {
            return builder
                .AddCheckbox(text, value, (component, newValue) =>
                {
                    try
                    {
                        valueSetter(newValue);
                    }
                    catch (Exception e)
                    {
                        builder.Context.Log.Error($"{nameof(LCheckBoxComponent)}.{nameof(LCheckBoxComponent.OnCheckChanged)} {nameof(valueSetter)} failed", e);
                    }
                }, textColor: DarkGray);
        }
    }

    internal static class LanguageHelpers
    {
        public static string NameToKey(this ILocaleLibrary library, string name)
        {
            if (string.IsNullOrEmpty(name)) return null;
            foreach (var item in library.AvailableLanguages)
            {
                if (item.Value.TryGetValue(Phrase.LanguageName, out var langName) && langName == name)
                    return item.Key;
            }
            return null;
        }
        public static string KeyToName(this ILocaleLibrary library, string key)
        {
            if (string.IsNullOrEmpty(key)) return null;
            if (library.AvailableLanguages.TryGetValue(key, out var dictionary)
                && dictionary.TryGetValue(Phrase.LanguageName, out var langName))
                return langName;
            return null;
        }
    }
}