using com.github.TheCSUser.Shared.Common;

namespace com.github.TheCSUser.HideItBobby.VersionMigrations
{
    internal abstract class Migration : WithContext
    {
        protected readonly Mod Mod;

        public Migration(IModContext context) : base(context)
        {
            Mod = context.Resolve<Mod>();
        }

        public abstract void Migrate();
    }
}
