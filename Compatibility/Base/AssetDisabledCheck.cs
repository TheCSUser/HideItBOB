using ColossalFramework.Packaging;
using com.github.TheCSUser.Shared.Common;
using System;

namespace com.github.TheCSUser.HideItBobby.Compatibility.Base
{
    internal abstract class AssetDisabledCheck : AssetSubscribedCheck
    {
        public AssetDisabledCheck(IModContext context, string name) : base(context, name) { }
        public AssetDisabledCheck(IModContext context, Func<string, bool> namePredicate) : base(context, namePredicate) { }
        public AssetDisabledCheck(IModContext context, Func<Package, bool> predicate) : base(context, predicate) { }

        protected sealed override bool Check() => !base.Check() || !MainAsset.isEnabled;
    }
}