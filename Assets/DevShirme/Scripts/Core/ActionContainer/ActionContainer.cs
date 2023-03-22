using DevShirme.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme
{
    public class ActionContainer : MonoSingleton<ActionContainer>
    {
        #region Actions
        public Action<Enums.UIPanelType> OnMainButtonPressed;
        #endregion

        #region Core
        public override void Initialize()
        {
            base.Initialize();
        }
        protected override void OnDestroy()
        {
            base.OnDestroy();
        }
        #endregion
    }
}
