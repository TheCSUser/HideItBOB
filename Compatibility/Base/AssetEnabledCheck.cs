using ColossalFramework.Packaging;
using com.github.TheCSUser.Shared.Common;
using System;

namespace com.github.TheCSUser.HideItBobby.Compatibility.Base
{
    internal abstract class AssetEnabledCheck : AssetSubscribedCheck
    {
        public AssetEnabledCheck(IModContext context, string name) : base(context, name) { }
        public AssetEnabledCheck(IModContext context, Func<string, bool> namePredicate) : base(context, namePredicate) { }
        public AssetEnabledCheck(IModContext context, Func<Package, bool> predicate) : base(context, predicate) { }

        protected sealed override bool Check() => base.Check() && MainAsset.isEnabled;
    }
}