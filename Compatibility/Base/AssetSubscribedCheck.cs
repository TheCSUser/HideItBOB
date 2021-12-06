using ColossalFramework.Packaging;
using com.github.TheCSUser.Shared.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace com.github.TheCSUser.HideItBobby.Compatibility.Base
{
    internal abstract class AssetSubscribedCheck : CompatibilityCheckBase
    {
        private ICollection<Package> Packages => typeof(PackageManager).GetStaticField<HashSet<Package>>("m_PackagesIndexTable");
        private int _packagesCount;
        private Package _package = null;
        private Package.Asset _mainAsset = null;

        private readonly Func<Package, bool> _predicate;

        public Package.Asset MainAsset => _mainAsset;

        public AssetSubscribedCheck(IModContext context, string name) : this(context, (p) => p.packageName == name) { }
        public AssetSubscribedCheck(IModContext context, Func<string, bool> namePredicate) : this(context, (p) => namePredicate(p.packageName)) { }
        public AssetSubscribedCheck(IModContext context, Func<Package, bool> predicate) : base(context) { _predicate = predicate; }

        protected override bool Check()
        {
            if (Packages.Count == _packagesCount) return !(_mainAsset is null) && _mainAsset.isEnabled;
            _packagesCount = Packages.Count;

            _package = Packages.FirstOrDefault(_predicate);
            if (_package is null) return false;
            _mainAsset = ((Dictionary<string, Package.Asset>)_package.GetField("m_IndexTable")).Values.FirstOrDefault(a => a.isMainAsset);
            return !(_mainAsset is null);
        }

        public override void Reset()
        {
            _packagesCount = 0;
            _package = null;
            _mainAsset = null;
            base.Reset();
        }
    }
}