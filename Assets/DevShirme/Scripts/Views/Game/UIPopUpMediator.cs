using DevShirme.Views;
using strange.extensions.mediation.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.Mediators
{
    public class UIPopUpMediator : Mediator
    {
        #region Injects
        [Inject] public UIPopUpView UIPopUpView { get; set; }
        #endregion

        #region Core
        public override void PreRegister()
        {
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
