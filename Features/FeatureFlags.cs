using com.github.TheCSUser.Shared.Common;

namespace com.github.TheCSUser.HideItBobby.Features
{
    public struct FeatureFlags
    {
        public static readonly FeatureFlags False = new FeatureFlags(0, false, false, false, false, false, false, false);
        public static readonly FeatureFlags True = new FeatureFlags(0, false, false, false, false, false, false, true);

        public int ErrorCount;
        public bool IsError;
        public bool IsDisposed;
        public bool IsAvailable;
        public bool IsInitialized;
        public bool IsEnabled;
        /// <summary>
        /// True if action has been executed in the current call.
        /// </summary>
        public bool Executed;
        /// <summary>
        /// Overall action result taking all flags into account.
        /// </summary>
        public bool EndResult;

        private FeatureFlags(int errorCount, bool isError, bool isDisposed, bool isAvailable, bool isInitialized, bool isEnabled, bool executed, bool endResult)
        {
            IsDisposed = isDisposed;
            ErrorCount = errorCount;
            IsError = isError;
            IsAvailable = isAvailable;
            IsInitialized = isInitialized;
            IsEnabled = isEnabled;
            Executed = executed;
            EndResult = endResult;
        }

        public FeatureFlags(object instance, bool executed, bool endResult)
        {
            if (instance is IDisposableEx disposable)
            {
                IsDisposed = disposable.IsDisposed;
            }
            else
            {
                IsDisposed = false;
            }

            if (instance is IErrorInfo errorInfo)
            {
                ErrorCount = errorInfo.ErrorCount;
                IsError = errorInfo.IsError;
            }
            else
            {
                ErrorCount = 0;
                IsError = false;
            }

            if (instance is IAvailabilityInfo availabilityInfo)
            {
                IsAvailable = availabilityInfo.IsAvailable;
            }
            else
            {
                IsAvailable = false;
            }

            if (instance is IInitializable initializable)
            {
                IsInitialized = initializable.IsInitialized;
            }
            else
            {
                IsInitialized = false;
            }

            if (instance is IToggleable togglable)
            {
                IsEnabled = togglable.IsEnabled;
            }
            else
            {
                IsEnabled = false;
            }

            Executed = executed;
            EndResult = endResult;
        }

        public static implicit operator bool(FeatureFlags flags) => flags.EndResult;
        public static implicit operator string(FeatureFlags flags) => flags.ToString();

        public override string ToString()
        {
            return $"[{(EndResult ? "TRUE" : "FALSE")}={(IsDisposed ? "D" : "")}{(IsAvailable ? "A" : "")}{(IsInitialized ? "I" : "")}{(IsEnabled ? "E" : "")}{(Executed ? "X" : "")}|{ErrorCount}|{(IsError ? "ERROR" : "OK")}]";
        }
    }
}