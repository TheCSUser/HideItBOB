using ColossalFramework.UI;
using com.github.TheCSUser.HideItBobby.Enums;
using com.github.TheCSUser.HideItBobby.Features.UIElements.Shared;
using com.github.TheCSUser.Shared.Checks;
using com.github.TheCSUser.Shared.Common;
using System;
using UnityEngine;

namespace com.github.TheCSUser.HideItBobby.Features.UIElements.Base
{
    internal abstract class ModifyUIComponentPosition : UpdatableFeatureBase
    {
        private readonly Cached<GameObject> _gameObject;
        private Vector3? _defaultComponentPosition = null;
        private bool _positionConfirmed = false;
        private bool _positionChecked = false;

        protected virtual Vector3? DefaultComponentPosition
        {
            get
            {
                if (_positionConfirmed) return _defaultComponentPosition;
                if (!_positionChecked)
                {
                    _positionChecked = true;

                    var currentPosition = ComponentPosition;
                    if (_defaultComponentPosition.HasValue && _defaultComponentPosition == currentPosition)
                    {
                        _positionConfirmed = true;
                        return _defaultComponentPosition;
                    }
                    _defaultComponentPosition = currentPosition;
                }
                return null;
            }
        }
        protected virtual Vector3? ComponentPosition
        {
            get
            {
                return _gameObject.Value?.transform?.position;
            }
            set
            {
                var obj = _gameObject.Value;
                if (!(obj is null) && value.HasValue) obj.transform.position = value.Value;
            }
        }

        public ModifyUIComponentPosition(IModContext context) : base(context)
        {
            _gameObject = new Cached<GameObject>(GetGameObjectPrivate, int.MaxValue);
            _check = context.Resolve<ModCheck>(Mods.UIResolution);
        }

        private GameObject GetGameObjectPrivate()
        {
            try
            {
                return GetGameObject();
            }
            catch (Exception e)
            {
                IncreaseErrorCount();
                Log.Error($"{GetType().Name}.{nameof(GetGameObject)} failed", e);
                return null;
            }
        }
        protected abstract GameObject GetGameObject();
        protected abstract Vector3? GetDesiredComponentPosition();

        #region Updatable
        protected override bool OnUpdate()
        {
            _positionChecked = false;
            if (!DefaultComponentPosition.HasValue) return false;

            var currentPosition = ComponentPosition;
            var desiredPosition = GetDesiredComponentPosition();
            if (!currentPosition.HasValue || !desiredPosition.HasValue) return false;
            if (currentPosition.Value != desiredPosition.Value) ComponentPosition = desiredPosition;
            return true;
        }
        #endregion

        #region Togglable
        protected override bool OnEnable() => true;
        protected override bool OnDisable()
        {
            ComponentPosition = DefaultComponentPosition;
            _gameObject.Value?.GetComponent<UIButton>()?.Invalidate();
            _gameObject.Invalidate();
            _positionConfirmed = false;
            _defaultComponentPosition = null;
            IsError = false;
            return true;
        }
        #endregion

        #region UIResolution mod compatibility
        private bool _wasEnabled;
        private readonly ModCheck _check;

        protected override bool OnInitialize()
        {
            if (_check.IsEnabled)
            {
                Patcher.Patch(UIViewProxy.Patches);
                UIViewProxy.BeforeResolutionChanged += BeforeResolutionChanged;
                UIViewProxy.AfterResolutionChanged += AfterResolutionChanged;
            }
            return true;
        }
        protected override bool OnTerminate()
        {
            if (_check.IsEnabled)
            {
                UIViewProxy.BeforeResolutionChanged -= BeforeResolutionChanged;
                UIViewProxy.AfterResolutionChanged -= AfterResolutionChanged;
                Patcher.Unpatch(UIViewProxy.Patches);
            }
            return true;
        }

        private void BeforeResolutionChanged(UIView sender, Vector2 oldResolution, Vector2 newResolution)
        {
            if (_wasEnabled = IsEnabled) Disable();
        }
        private void AfterResolutionChanged(UIView sender, Vector2 oldResolution, Vector2 newResolution)
        {
            if (_wasEnabled) Enable();
        }
        #endregion
    }
}