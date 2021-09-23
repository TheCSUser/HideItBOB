using com.github.TheCSUser.Shared.Common;
using System;
using System.Threading;

namespace com.github.TheCSUser.HideItBobby.Compatibility.Base
{
    internal abstract class CompatibilityCheck : WithContext, ICheck, IManagedLifecycle
    {
        public static readonly ICheck Compatible = new ConstantResultCheck(true);
        public static readonly ICheck NotCompatible = new ConstantResultCheck(false);

        public CompatibilityCheck(IModContext context) : base(context) { }

        protected abstract bool Check();

        #region Check
        private const int CheckCountTreshold = 10;

        private int _checkCount;
        public int CheckCount => _checkCount;

        private bool _result = true;
        public bool Result
        {
            get
            {
                if (_checkCount > CheckCountTreshold)
                {
//#if DEV
//                    Log.Info($"{GetType().Name}.{nameof(Result)} check count treshold reached. Returning '{_result}'.");
//#endif
                    return _result;
                }
                Interlocked.Increment(ref _checkCount);
                try
                {
                    _result = Check();
//#if DEV
//                    Log.Info($"{GetType().Name}.{nameof(Result)} check result is '{_result}'.");
//#endif
                }
#if DEV
                catch (Exception e)
#else
                catch
#endif
                {
                    _result = false;
#if DEV
                    Log.Error($"{GetType().Name}.{nameof(Check)} failed", e);
#endif
                }
                return _result;
            }
        }

        public virtual void Reset()
        {
//#if DEV
//            Log.Info($"{GetType().Name}.{nameof(Reset)} called");
//#endif
            Interlocked.Exchange(ref _checkCount, 0);
        }
        #endregion

        #region ManagedLifecycle
        private IInitializable _lifecycleManager;
        public IInitializable GetLifecycleManager() => _lifecycleManager ?? (_lifecycleManager = new CompatibilityCheckLifecycleManager(this));

        private sealed class CompatibilityCheckLifecycleManager : LifecycleManager
        {
            private readonly CompatibilityCheck _check;

            public CompatibilityCheckLifecycleManager(CompatibilityCheck check) : base(check.Context)
            {
                _check = check;
            }

            protected override bool OnInitialize() => true;

            protected override bool OnTerminate()
            {
                _check.Reset();
                return true;
            }
        }
        #endregion

        private sealed class ConstantResultCheck : ICheck
        {
            private readonly bool _isCompatible;
            public bool Result => _isCompatible;

            public ConstantResultCheck(bool value)
            {
                _isCompatible = value;
            }

            public void Reset() { }
        }
    }
}