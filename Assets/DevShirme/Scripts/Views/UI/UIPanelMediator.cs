using DevShirme.Signals;
using DevShirme.Utils;
using DevShirme.Views;
using strange.extensions.mediation.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.Mediators
{
    public class UIPanelMediator : Mediator
    {
        #region Injects
        [Inject] public UIPanelView UIPanelView { get; set; }
        [Inject] public UISignal UISignal { get; set; }
        #endregion

        #region Core
        public override void PreRegister()
        {
        }
        public override void OnRegister()
        {
            UIPanelView.Initialize();

            UISignal.OnTransationToNewPanel.AddListener(onTransationToNewPanel);
        }
        public override void OnRemove()
        {
            UISignal.OnTransationToNewPanel.RemoveListener(onTransationToNewPanel);
        }
        #endregion

        #region Receivers
        private void onTransationToNewPanel(Enums.UIPanelType panelType)
        {
            bool isShow = UIPanelView.PanelType == panelType;
            if (isShow)
                UIPanelView.Show();
            else
                UIPanelView.Hide();
        }
        #endregion
    }
}
