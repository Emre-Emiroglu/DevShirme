using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.Core
{
    public class GameManager : DevShirmeManager
    {
        #region Fields
        [Header("Gameplay Controllers")]
        [SerializeField] private List<DevShirmeController> controllers;
        #endregion

        #region Core
        public override void Initialize()
        {
            for (int i = 0; i < controllers.Count; i++)
            {
                controllers[i].Initialize();
            }
        }
        #endregion
    }
}
