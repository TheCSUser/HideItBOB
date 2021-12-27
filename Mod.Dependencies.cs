using com.github.TheCSUser.HideItBobby.Enums;
using com.github.TheCSUser.HideItBobby.Features.Effects.Shared;
using com.github.TheCSUser.HideItBobby.Features.UIElements;
using com.github.TheCSUser.HideItBobby.Localization;
using com.github.TheCSUser.HideItBobby.Scripts;
using com.github.TheCSUser.Shared.Checks;

namespace com.github.TheCSUser.HideItBobby
{
    public sealed partial class Mod
    {
        private void RegisterDependencies()
        {
            Context
            //managers
            .Register(new LocaleFilesManager(Context))
            //dlcs checks
            .Register(new DLCCheck(Context, DLC.NaturalDisasters), DLC.NaturalDisasters)
            .Register(new DLCCheck(Context, DLC.Snowfall), DLC.Snowfall)
            //assets checks
            .Register(Use(new AssetCheck(Context, "1480409620")), Assets.TerraformNetwork)
            //mods checks
            .Register(Use(new ModCheck(Context, "2197863850")), Mods.BOB)
            .Register(Use(new ModCheck(Context, "694512541")), Mods.PropLineTool)
            .Register(Use(new ModCheck(Context, "768213484")), Mods.SubtleBulldozing)
            .Register(Use(new ModCheck(Context, "1899640536")), Mods.ThemeMixer2)
            .Register(Use(new ModCheck(Context, "2527486462", "2584051448")), Mods.TreeAnarchy)
            .Register(Use(new ModCheck(Context, "2487213155")), Mods.UIResolution)
            .Register(Use(new ModCheck(Context, "2255219025")), Mods.UnifiedUI)
            .Register(Use(new ModCheck(Context, "2448994345", "2691569925")), Mods.YetAnotherToolbar)
            //proxies
            .Register(Use(new DispatchPlacementEffectProxy(Context)))
            .Register(Use(new ToolBaseProxy(Context)))
            //scripts
            .Register(new MainMenuFeatures(this))
            .Register(new InGameFeatures(this))

            ;
        }
    }
}