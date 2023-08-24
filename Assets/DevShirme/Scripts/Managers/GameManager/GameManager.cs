using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme
{
    public class GameManager : Manager
    {
        #region Fields
        [Header("Game Manager Components")]
        [SerializeField] private List<Module> modules;
        #endregion

        #region Core
        public override void Initialize()
        {
            for (int i = 0; i < modules.Count; i++)
                modules[i].Initialize();
        }
        #endregion
    }
}
