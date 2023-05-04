using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.PlayerModule
{
    public class PlayerModule : Module
    {
        #region Fields
        [Header("Player Module Components")]
        [SerializeField] private PlayerAgent playerAgent;
        #endregion

        #region Core
        public override void Initialize()
        {
            playerAgent.Initialize(settings as PlayerSettings);
        }
        #endregion
    }
}
