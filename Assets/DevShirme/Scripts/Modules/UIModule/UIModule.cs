using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DevShirme.Utils;
using DevShirme.Interfaces;

namespace DevShirme.UIModule
{
    public class UIModule : Module, IPanelChangeListeners
    {
        #region Fields
        [Header("UI Controller Fields")]
        [SerializeField] private UIRefresher uiRefresher;
        [SerializeField] private List<UIPanel> panels;
        #endregion

        #region Core
        public override void Initialize()
        {
            base.Initialize();

            GameManager.OnPanelChangerButtonPressed += OnPanelChangerButtonPressed;

            uiRefresher.Initialize();

            transation(Enums.UIPanelType.MainMenuPanel);
        }
        public override void OnGameStart()
        {
        }
        public override void OnGameReload()
        {
        }
        public override void OnGameOver()
        {
        }
        public override void OnGameSuccess()
        {
        }
        public override void OnGameFailed()
        {
        }
        protected override void setSubs(bool isSub)
        {
            base.setSubs(isSub);
        }
        private void OnDestroy()
        {
            GameManager.OnPanelChangerButtonPressed -= OnPanelChangerButtonPressed;
        }
        #endregion

        #region PanelProcess
        private void transation(Enums.UIPanelType newPanel)
        {
            panels.ForEach(x => x.Hide());
            panels[((int)newPanel)].Show();
        }
        #endregion

        #region IPanelChangeListeners
        public void OnPanelChangerButtonPressed(Enums.UIPanelType panelType)
        {
            transation(panelType);
        }
        #endregion
    }
}
