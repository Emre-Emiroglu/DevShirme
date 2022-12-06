using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DevShirme.Utils;

namespace DevShirme.UIModule
{
    public class UIController : DevShirmeController
    {
        #region Fields
        [Header("UI Controller Fields")]
        [SerializeField] private ViewContainer viewContainer;
        [SerializeField] private List<UIPanel> panels;
        #endregion

        #region Core
        public override void Initialize()
        {
            viewContainer.Initialize();
            transation(Enums.UIPanelType.MainMenuPanel);
        }
        public override void GameStart()
        {
            transation(Enums.UIPanelType.InGamePanel);
        }
        public override void Reload()
        {
            viewContainer.Reload();
            transation(Enums.UIPanelType.MainMenuPanel);
        }
        public override void GameOver()
        {
            transation(Enums.UIPanelType.EndGamePanel);
        }
        public override void GameSuccess()
        {
        }
        public override void GameFail()
        {
        }
        #endregion

        #region PanelProcess
        private void transation(Enums.UIPanelType newPanel)
        {
            panels.ForEach(x => x.Hide());
            panels[((int)newPanel)].Show();
        }
        #endregion
    }
}
[System.Serializable]
public struct PanelDatas
{
    [SerializeField] private bool smoothPanels;
    [SerializeField] private float showDuration;
    [SerializeField] private float hideDuration;

    #region Getters
    public bool SmoothPanels => smoothPanels;
    public float ShowDuration => showDuration;
    public float HideDuration => hideDuration;
    #endregion
}