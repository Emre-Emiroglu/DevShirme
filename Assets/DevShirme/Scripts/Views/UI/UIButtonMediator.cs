using DevShirme.Utils;
using DevShirme.Views;
using strange.extensions.mediation.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.Mediators
{
    public class UIButtonMediator : Mediator
    {
        #region Injects
        [Inject] public UIButtonView UIButtonView { get; set; }
        #endregion

        #region Core
        public override void PreRegister()
        {
            UIButtonView.Setup();
        }
        public override void OnRegister()
        {
            UIButtonView.OnButtonPressed += onButtonPressed;
        }
        public override void OnRemove()
        {
            UIButtonView.OnButtonPressed -= onButtonPressed;
        }
        #endregion

        #region Receivers
        private void onButtonPressed(Enums.UIButtonType uiButtonType)
        {

        }
        #endregion
    }
}
