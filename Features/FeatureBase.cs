using com.github.TheCSUser.Shared.Common;
using System;
using System.Threading;

namespace com.github.TheCSUser.HideItBobby.Features
{
    internal abstract class FeatureBase : WithContext, IFeature
    {
        protected readonly Mod Mod;

        public abstract FeatureKey Key { get; }
        public virtual bool IsAvailable => true;

        protected FeatureBase(IModContext context) : base(context) {
            Mod = context.Resolve<Mod>();
        }

        protected virtual bool OnInitialize() => true;
        protected virtual bool OnTerminate() => true;
        protected virtual bool OnEnable() => true;
        protected virtual bool OnDisable() => true;

        #region Error
#if DEV || PREVIEW
        private const int ErrorTreshold = 3;
#else
        private const int ErrorTreshold = 10;
#endif
        private int _errorCount;
        public int ErrorCount => _errorCount;
        public bool IsError
        {
            get
            {
                return _errorCount >= ErrorTreshold;
            }
            set
            {
                if (value) Interlocked.Add(ref _errorCount, ErrorTreshold);
                else _errorCount = 0;
            }
        }
        protected void IncreaseErrorCount() => Interlocked.Increment(ref _errorCount);
        #endregion

        #region Disposable
        private bool _isDisposed;
        public bool IsDisposed => _isDisposed;

        protected virtual void Dispose(bool disposing)
        {
            if (_isDisposed) return;

            if (disposing)
            {
                // dispose managed state (managed objects)
                if (IsEnabled) try { _isEnabled = !OnDisable(); } catch { IsError = true; }
                if (IsInitialized) try { _isInitialized = !OnTerminate(); } catch { IsError = true; }
            }
            // free unmanaged resources (unmanaged objects) and override finalizer
            // set large fields to null
            _isDisposed = true;
        }

        // // override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~FeatureBase()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
        #endregion

        #region Initializable
        private bool _isInitialized;
        public virtual bool IsInitialized => _isInitialized;

        public FeatureFlags Initialize()
        {
            if (IsDisposed || IsError) return Result(false);
            if (!IsAvailable)
            {
#if DEV
                Log.Info($"{GetType().Name} is not available");
#endif
                return Result(false);
            }
            if (IsInitialized) return Result(true);
            try
            {
#if DEV
                Log.Info($"{GetType().Name} initializing");
#endif
                _isInitialized = OnInitialize();
                return Result(IsInitialized, true);
            }
            catch (Exception e)
            {
                _isInitialized = false;
                IncreaseErrorCount();
                Log.Error($"{GetType().Name}.{nameof(OnInitialize)} failed", e);
                return Result(false);
            }
        }
        public FeatureFlags Terminate()
        {
            if (IsDisposed || IsError) return Result(false);
            if (!IsAvailable)
            {
#if DEV
                Log.Info($"{GetType().Name} is not available");
#endif
                return Result(false);
            }
            if (!IsInitialized) return Result(true);
            if (IsEnabled)
            {
                try
                {
#if DEV
                    Log.Info($"{GetType().Name} disabling");
#endif
                    _isEnabled = !OnDisable();
                }
                catch (Exception e)
                {
                    IncreaseErrorCount();
                    Log.Error($"{GetType().Name}.{nameof(OnDisable)} failed", e);
                    return Result(false);
                }
            }
            try
            {
#if DEV
                Log.Info($"{GetType().Name} terminating");
#endif
                _isInitialized = !OnTerminate();
                return Result(!IsInitialized, true);
            }
            catch (Exception e)
            {
                IncreaseErrorCount();
                Log.Error($"{GetType().Name}.{nameof(OnTerminate)} failed", e);
                return Result(false);
            }
        }

        void IInitializable.Initialize() => Initialize();
        void IInitializable.Terminate() => Terminate();
        #endregion

        #region Toggleable
        private bool _isEnabled;

        public virtual bool IsEnabled => _isEnabled;

        public FeatureFlags Enable() => Enable(false);
        public FeatureFlags Enable(bool force)
        {
            if (IsDisposed || IsError || !IsAvailable) return Result(false);
            if (IsEnabled && !force) return Result(true);
            if (!IsInitialized)
            {
                try
                {
#if DEV
                    Log.Info($"{GetType().Name} initializing");
#endif
                    _isInitialized = OnInitialize();
                    if (!IsInitialized) return Result(false, true);
                }
                catch (Exception e)
                {
                    _isInitialized = false;
                    IncreaseErrorCount();
                    Log.Error($"{GetType().Name}.{nameof(OnInitialize)} failed", e);
                    return Result(false);
                }
            }
            try
            {
#if DEV
                Log.Info($"{GetType().Name} enabling");
#endif
                _isEnabled = OnEnable();
                return Result(IsEnabled, true);
            }
            catch (Exception e)
            {
                _isEnabled = false;
                IncreaseErrorCount();
                Log.Error($"{GetType().Name}.{nameof(OnEnable)} failed", e);
                return Result(false);
            }
        }
        public FeatureFlags Disable() => Disable(false);
        public FeatureFlags Disable(bool force)
        {
            if (IsDisposed || IsError || !IsAvailable || !IsInitialized) return Result(true);
            if (!IsEnabled && !force) return Result(true);
            try
            {
#if DEV
                Log.Info($"{GetType().Name} disabling");
#endif
                _isEnabled = !OnDisable();
                return Result(!IsEnabled, true);
            }
            catch (Exception e)
            {
                _isEnabled = true;
                IncreaseErrorCount();
                Log.Error($"{GetType().Name}.{nameof(OnDisable)} failed", e);
                return Result(false);
            }
        }

        void IToggleable.Enable() => Enable();
        void IToggleable.Disable() => Disable();
        void IForceToggleable.Enable(bool force) => Enable(force);
        void IForceToggleable.Disable(bool force) => Disable(force);
        #endregion

        #region Result helpers
        protected FeatureFlags Result(bool result) => new FeatureFlags(this, false, result);
        protected FeatureFlags Result(bool result, bool executed) => new FeatureFlags(this, executed, result);
        #endregion
    }

    internal abstract class UpdatableFeatureBase : FeatureBase, IUpdatableFeature
    {
        protected abstract bool OnUpdate();

        protected UpdatableFeatureBase(IModContext context) : base(context) { }

        #region Updatable
        public virtual FeatureFlags Update()
        {
            if (IsDisposed || IsError || !IsAvailable || !IsInitialized) return Result(false);
            if (!IsEnabled) return Result(true);
            try
            {
                var result = OnUpdate();
                return Result(result, true);
            }
            catch (Exception e)
            {
                IncreaseErrorCount();
                Log.Error($"{GetType().Name}.{nameof(OnUpdate)} failed", e);
                return Result(false);
            }
        }

        void IUpdatable.Update() => Update();
        #endregion
    }
}