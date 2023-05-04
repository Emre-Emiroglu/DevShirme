using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.Utils
{
    public static class Structs
    {
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
    }
}
