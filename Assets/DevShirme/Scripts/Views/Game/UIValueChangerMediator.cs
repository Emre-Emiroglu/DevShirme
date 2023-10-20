using DevShirme.Views;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.Mediators
{
    public class UIValueChangerMediator : MonoBehaviour
    {
        #region Fields
        private UIValueChangerView view;
        #endregion

        #region Core

        public void Construct(UIValueChangerView view)
        {
            this.view = view;
        }
        #endregion
    }
}
