using com.github.TheCSUser.Shared.UserInterface.Localization;
using System;
using com.github.TheCSUser.Shared.UserInterface.Localization.Components;
using com.github.TheCSUser.HideItBobby.Localization;
using ColossalFramework.UI;

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
        public static LCheckBoxComponent AddFeatureCheckbox(this LocalizedUIBuilder builder, LocaleText text, bool value, Action<bool> valueSetter, Func<LCheckBoxComponent, IDisposable> overrideStyle = null)
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
                .ApplyStyle(overrideStyle ?? GrayTextOnUnchecked);
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
        public static LocalizedUIBuilder AddSubGroup(this LocalizedUIBuilder builder, LocaleText text)
        {
            var cursorInfo = builder.AddGroup(text, textColor: White);
            var contentPanel = (UIPanel)cursorInfo.Panel.Find("Content");
            contentPanel.autoLayoutPadding = new UnityEngine.RectOffset(10, 0, 5, 0);
            contentPanel.backgroundSprite = null;
            cursorInfo.Panel.autoLayoutPadding = new UnityEngine.RectOffset(0, 0, 0, 0);
            cursorInfo.Panel.backgroundSprite = null;
            return cursorInfo.Builder;
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