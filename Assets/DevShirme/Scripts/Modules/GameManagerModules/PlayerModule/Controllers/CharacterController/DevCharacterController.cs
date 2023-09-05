using DevShirme.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.Modules.PlayerModule.Controllers
{
    public class DevCharacterController: Controller
    {
        #region Fields
        private readonly PlayerSettings playerSettings;
        private readonly IPlayerAgent agent;
        #endregion

        #region Core
        public DevCharacterController(ScriptableObject _settings) : base(_settings)
        {
            playerSettings = _settings as PlayerSettings;

            agent = Object.FindObjectOfType<PlayerAgent>();
            agent.Initialize(playerSettings);
        }
        #endregion

        #region Updates
        public override void ExternalUpdate()
        {
        }
        public override void ExternalFixedUpdate()
        {
        }
        #endregion
    }
}
