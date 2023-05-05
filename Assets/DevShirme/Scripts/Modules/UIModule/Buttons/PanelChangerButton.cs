using DevShirme.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.UIModule
{
    public class PanelChangerButton : UIButton
    {
        #region Fields
        [Header("Main UI Button Fields")]
        [SerializeField] private Enums.UIPanelType panelType;
        #endregion

        #region Core
        public override void Setup()
        {
        }
        public override void OnPressed()
        {
            GameManager.OnPanelChangerButtonPressed?.Invoke(panelType);
        }
        #endregion
    }
}
