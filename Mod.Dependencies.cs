using com.github.TheCSUser.HideItBobby.Compatibility;
using com.github.TheCSUser.HideItBobby.Features.Effects.Shared;
using com.github.TheCSUser.HideItBobby.Features.UIElements;
using com.github.TheCSUser.HideItBobby.Localization;
using com.github.TheCSUser.HideItBobby.Scripts;

namespace com.github.TheCSUser.HideItBobby
{
	public sealed partial class Mod
	{
		private void RegisterDependencies()
		{
			Context
			//managers
			.Register(new LocaleFilesManager(Context))
			//checks
			.Register(Use(new NaturalDisastersDLCEnabledCheck(Context)))
			.Register(Use(new SnowFallDLCEnabledCheck(Context)))
			.Register(Use(new BOBModDisabledCheck(Context)))
			.Register(Use(new TerraformNetworkSubscribedCheck(Context)))
			.Register(Use(new UIResolutionModEnabledCheck(Context)))
			.Register(Use(new TreeAnarchyModEnabledCheck(Context)))
			.Register(Use(new SubtleBulldozingModDisabledCheck(Context)))
			.Register(Use(new TreeAnarchyModSubscribedCheck(Context)))
			.Register(Use(new PropLineToolModSubscribedCheck(Context)))
			.Register(Use(new PropLineToolModEnabledCheck(Context)))
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