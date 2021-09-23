using com.github.TheCSUser.Shared.Common;
using System;
using System.Collections;

namespace com.github.TheCSUser.HideItBobby.Features.Effects.Shared
{
    internal sealed class TexturesUpdater : WithContext
    {
        private Counter _counter = int.MaxValue;

        public TexturesUpdater(IModContext context) : base(context) { }

        public void ResetCounter() => _counter = int.MaxValue;

        public void Update(Counter counter)
        {
            if (counter <= _counter) return;
            _counter = counter.Clone();
            try
            {
                if (SimulationManager.exists)
                    SimulationManager.instance.AddAction(SetAreaModified(Context));
            }
            catch (Exception e)
            {
                Log.Error($"{nameof(TexturesUpdater)}.{nameof(Update)} failed", e);
            }
        }

        private static IEnumerator SetAreaModified(IModContext context)
        {
            try
            {
                if (NaturalResourceManager.exists)
                    NaturalResourceManager.instance.AreaModified(0, 0, 511, 511);
            }
            catch (Exception e)
            {
                context.Log.Error($"{nameof(TexturesUpdater)}.{nameof(SetAreaModified)} failed", e);
            }
            yield return null;
        }
    }
}