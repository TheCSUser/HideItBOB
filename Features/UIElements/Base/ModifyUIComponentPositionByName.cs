using com.github.TheCSUser.Shared.Common;
using UnityEngine;

namespace com.github.TheCSUser.HideItBobby.Features.UIElements.Base
{
    internal abstract class ModifyUIComponentPositionByName : ModifyUIComponentPosition
    {
        protected virtual string ComponentName { get; private set; }

        public ModifyUIComponentPositionByName(IModContext context, string componentName) : base(context)
        {
            ComponentName = componentName;
        }

        protected override GameObject GetGameObject()
        {
            var component = GameObject.Find(ComponentName);
            if (component is null)
            {
                IncreaseErrorCount();
#if DEV || PREVIEW
                Log.Warning($"{GetType().Name}.{nameof(GetGameObject)} could not find {ComponentName}, current error count is {ErrorCount}.");
#endif
            }
            return component;
        }
    }
}