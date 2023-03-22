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
        #region Core
        public abstract void Setup();
        public abstract void OnPressed();
        #endregion
    }
}
