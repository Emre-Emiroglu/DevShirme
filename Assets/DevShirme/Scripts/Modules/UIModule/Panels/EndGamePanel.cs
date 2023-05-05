using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.UIModule
{
    public class EndGamePanel : UIPanel
    {
        #region Fields
        [Header("End Game Panel Componenets")]
        [SerializeField] private GameObject[] panels;
        #endregion

        #region Core
        public override void Initialize()
        {
            base.Initialize();
        }
        public override void Show()
        {
            base.Show();
        }
        public override void Hide()
        {
            base.Hide();
        }
        #endregion

        #region Executes
        public void SetPanels(bool isGameSuccess)
        {
            panels[0].SetActive(isGameSuccess);
            panels[1].SetActive(!isGameSuccess);
        }
        #endregion
    }
}
