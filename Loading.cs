﻿using ICities;
using System;
using UnityEngine;

namespace HideItBobby
{
    public class Loading : LoadingExtensionBase
    {
        private GameObject _hideManagerGameObject;

        public override void OnLevelLoaded(LoadMode mode)
        {
            try
            {
                _hideManagerGameObject = new GameObject("HideItModManager");
                _hideManagerGameObject.AddComponent<ModManager>();
            }
            catch (Exception e)
            {
                Debug.Log("[Hide it, BOBby!] Loading:OnLevelLoaded -> Exception: " + e.Message);
            }
        }

        public override void OnLevelUnloading()
        {
            try
            {
                if (_hideManagerGameObject != null)
                {
                    UnityEngine.Object.Destroy(_hideManagerGameObject);
                }

            }
            catch (Exception e)
            {
                Debug.Log("[Hide it, BOBby!] Loading:OnLevelUnloading -> Exception: " + e.Message);
            }
        }
    }
}