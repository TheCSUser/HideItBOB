using com.github.TheCSUser.HideItBobby.Settings.SettingsFiles;
using com.github.TheCSUser.Shared.Common;
using com.github.TheCSUser.Shared.UserInterface.Components;
using com.github.TheCSUser.Shared.UserInterface.Components.Base;
using com.github.TheCSUser.Shared.UserInterface.Localization;
using com.github.TheCSUser.Shared.UserInterface.Localization.Components;
using System;

namespace com.github.TheCSUser.HideItBobby.UserInterface
{
    using CurrentSettingsFile = File_1_21;
    using static Palette;

    internal static class Styles
    {
        public static readonly Func<TextComponent, IDisposable> HideEmptyLabel = (TextComponent textComponent) =>
        {
            void handler(ITextComponent c, string text)
            {
                if (c is null) return;
                c.Component.isVisible = !string.IsNullOrEmpty(text);
            }
            textComponent.OnTextChanged += handler;
            handler(textComponent, textComponent.Text);
            return ((Action)(() => textComponent.OnTextChanged -= handler)).AsDisposable();
        };

        public static readonly Func<LCheckBoxComponent, IDisposable> GrayTextOnUnchecked = (LCheckBoxComponent checkBox) =>
        {
            void handler(ICheckbox c, bool value)
            {
                if (c is null) return;
                c.TextColor = value ? White : DarkGray;
            }
            checkBox.OnCheckChanged += handler;
            handler(checkBox, checkBox.IsChecked);
            return ((Action)(() => checkBox.OnCheckChanged -= handler)).AsDisposable();
        };

        public static readonly Func<LSliderComponent, IDisposable> DisableWhenNotModifyingPosition = (LSliderComponent slider) =>
        {
            void handler(object s, string p)
            {
                if (!string.IsNullOrEmpty(p) && p != nameof(CurrentSettingsFile.ModifyToolbarPosition)) return;
                if (!(s is CurrentSettingsFile settings)) return;
                slider.TextColor = settings.ModifyToolbarPosition ? White : DarkGray;
                slider.Color = settings.ModifyToolbarPosition ? White : DarkGray;
                slider.IsEnabled = settings.ModifyToolbarPosition;
            }
            slider.Context.Mod.SettingsChanged += handler;
            handler(((Mod)slider.Context.Mod).Settings, string.Empty);
            return ((Action)(() => slider.Context.Mod.SettingsChanged -= handler)).AsDisposable();
        };

        public static readonly Func<LDropDownComponent, IDisposable> DisableWhenUsingGameLanguage = (LDropDownComponent dropDown) =>
        {
            void handler(object s, string p)
            {
                if (!string.IsNullOrEmpty(p) && p != nameof(CurrentSettingsFile.UseGameLanguage)) return;
                if (!(s is CurrentSettingsFile settings)) return;
                dropDown.SelectedIndex = Array.IndexOf(dropDown.Items, dropDown.Context.LocaleLibrary.KeyToName(settings.UseGameLanguage ? dropDown.Context.LocaleManager.GameLanguage : settings.SelectedLanguage) ?? LocaleConstants.DEFAULT_LANGUAGE_NAME);
                dropDown.TextColor = !settings.UseGameLanguage ? White : DarkGray;
                dropDown.Color = !settings.UseGameLanguage ? White : DarkGray;
                dropDown.IsEnabled = !settings.UseGameLanguage;
            }
            dropDown.Context.Mod.SettingsChanged += handler;
            handler(((Mod)dropDown.Context.Mod).Settings, string.Empty);
            return ((Action)(() => dropDown.Context.Mod.SettingsChanged -= handler)).AsDisposable();
        };
    }
}