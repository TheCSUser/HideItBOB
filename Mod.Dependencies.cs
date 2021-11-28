using com.github.TheCSUser.HideItBobby.Compatibility;

namespace com.github.TheCSUser.HideItBobby
{
	public sealed partial class Mod
	{
		private void RegisterDependencies()
		{
			Context
			.Register(Use(new NaturalDisastersDLCEnabledCheck(Context)))
			.Register(Use(new SnowFallDLCEnabledCheck(Context)))
			.Register(Use(new BOBModDisabledCheck(Context)))
			.Register(Use(new TerraformNetworkSubscribedCheck(Context)))
			.Register(Use(new UIResolutionModEnabledCheck(Context)))
			.Register(Use(new TreeAnarchyModEnabledCheck(Context)))
			.Register(Use(new SubtleBulldozingModDisabledCheck(Context)))
			;
		}
	}
}