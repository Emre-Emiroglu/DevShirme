using DevShirme.Views;
using strange.extensions.mediation.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.Mediators
{
    public class UIValueChangerMediator : Mediator
    {
        #region Injects
        [Inject] public UIValueChangerView UIValueChangerView { get; set; }
        #endregion

        #region Core
        public override void PreRegister()
        {
            UIValueChangerView.Initialize();
        }
        public override void OnRegister()
        {
        }
        public override void OnRemove()
        {
        }
        #endregion

        #region Receivers

        #endregion
    }
}
