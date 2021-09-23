using ColossalFramework.Packaging;
using com.github.TheCSUser.Shared.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace com.github.TheCSUser.HideItBobby.Compatibility.Base
{
    internal abstract class AssetEnabledCheck : CompatibilityCheck
    {
        private ICollection<Package> Packages => typeof(PackageManager).GetStaticField<HashSet<Package>>("m_PackagesIndexTable");
        private int _packagesCount;
        private Package _package = null;
        private Package.Asset _mainAsset = null;

        private readonly Func<Package, bool> _predicate;

        public AssetEnabledCheck(IModContext context, string name) : this(context, (p) => p.packageName == name) { }
        public AssetEnabledCheck(IModContext context, Func<string, bool> namePredicate) : this(context, (p) => namePredicate(p.packageName)) { }
        public AssetEnabledCheck(IModContext context, Func<Package, bool> predicate) : base(context) { _predicate = predicate; }

        protected sealed override bool Check()
        {
            if (Packages.Count == _packagesCount) return !(_mainAsset is null) && _mainAsset.isEnabled;
            _packagesCount = Packages.Count;

            _package = Packages.FirstOrDefault(_predicate);
            if (_package is null) return false;
            _mainAsset = ((Dictionary<string, Package.Asset>)_package.GetField("m_IndexTable")).Values.FirstOrDefault(a => a.isMainAsset);
            if (_mainAsset is null) return false;
            return _mainAsset.isEnabled;
        }

        public sealed override void Reset()
        {
            _packagesCount = 0;
            _package = null;
            _mainAsset = null;
            base.Reset();
        }
    }
}