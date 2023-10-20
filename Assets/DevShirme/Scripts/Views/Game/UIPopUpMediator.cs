using DevShirme.Views;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace DevShirme.Mediators
{
    public class UIPopUpMediator : MonoBehaviour
    {
        #region Fields
        private UIPopUpView view;
        #endregion

        #region Core
        [Inject]
        public void Construct(UIPopUpView view)
        {
            this.view = view;
        }
        #endregion
    }
}
