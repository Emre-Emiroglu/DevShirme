using DevShirme.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DevShirme.UIModule
{
    [RequireComponent(typeof(Button))]
    public abstract class UIButton : MonoBehaviour
    {
        #region Fields
        protected Button _button;
        #endregion
        
        #region Core
        public virtual void Setup()
        {
            _button = GetComponent<Button>();
            _button.onClick.AddListener(OnPressed);
        }
        public abstract void OnPressed();
        #endregion
    }
}
