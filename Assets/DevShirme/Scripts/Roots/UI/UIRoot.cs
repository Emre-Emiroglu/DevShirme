using DevShirme.Contexts;
using strange.extensions.context.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.Roots
{
    public class UIRoot : ContextView
    {
        #region Core
        private void Awake()
        {
            context = new UIContext(this);
        }
        protected override void OnDestroy()
        {
            base.OnDestroy();
        }
        #endregion
    }
}
