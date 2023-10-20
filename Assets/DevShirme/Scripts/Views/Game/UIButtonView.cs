using DevShirme.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DevShirme.Views
{
    [RequireComponent(typeof(Button))]
    public class UIButtonView : MonoBehaviour
    {
        #region Events
        public event Action<Enums.UIButtonType> OnButtonPressed;
        #endregion

        #region Fields
        [Header("UI Button Settings")]
        [SerializeField] protected Enums.UIButtonType uiButtonType;
        protected Button _button;
        #endregion

        #region Core
        public virtual void Setup()
        {
            _button = GetComponent<Button>();
            _button.onClick.AddListener(OnPressed);
        }
        public virtual void OnPressed() { OnButtonPressed?.Invoke(uiButtonType); }
        #endregion
    }
}
