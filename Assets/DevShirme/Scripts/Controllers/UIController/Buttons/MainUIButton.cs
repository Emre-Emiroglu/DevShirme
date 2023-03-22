using DevShirme.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DevShirme.UIModule
{
    public class MainUIButton : UIButton
    {
        #region Fields
        [Header("Main UI Button Fields")]
        [SerializeField] private Enums.UIPanelType panelType;
        [SerializeField] protected Image btnImage;
        [SerializeField] private Sprite[] sprites;
        #endregion

        #region Core
        public override void Setup()
        {
        }
        public override void OnPressed()
        {
            ActionContainer.Instance.OnMainButtonPressed?.Invoke(panelType);
        }
        public void SpriteChanger(bool isPressed)
        {
            btnImage.sprite = isPressed ? sprites[1] : sprites[0];
        }
        #endregion
    }
}
