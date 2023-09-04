using DevShirme.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace DevShirme.Modules.PlayerModule.Controllers
{
    public class CharacterController: Controller
    {
        #region Fields
        private readonly PlayerSettings playerSettings;
        private readonly IPlayerAgent agent;
        #endregion

        #region Core
        public CharacterController(ScriptableObject _settings) : base(_settings)
        {
            playerSettings = _settings as PlayerSettings;

            agent = Object.FindObjectOfType<PlayerAgent>();
            agent.Initialize(playerSettings);
        }
        #endregion

        #region Updates
        public override void ExternalUpdate()
        {
            base.ExternalUpdate();
        }
        public override void ExternalFixedUpdate()
        {
            base.ExternalFixedUpdate();
        }
        #endregion
    }
}
