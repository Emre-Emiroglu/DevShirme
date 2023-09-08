using DevShirme.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.Modules.PlayerModule
{
    public class CharacterController : Controller
    {
        #region Fields
        private readonly CharacterControllerSettings ccSettings;
        private readonly IPlayerAgent playerAgent;
        #endregion

        #region Props
        public Vector2 Input { get; set; }
        #endregion

        #region Core
        public CharacterController(ScriptableObject _settings) : base(_settings)
        {
            ccSettings = _settings as CharacterControllerSettings;

            playerAgent = Object.FindObjectOfType<PlayerAgent>();
            playerAgent?.Initialize(ccSettings);
        }
        #endregion

        #region Updates
        public override void ExternalUpdate()
        {
            playerAgent?.ExternalUpdate(Input);
        }
        public override void ExternalFixedUpdate()
        {
            playerAgent?.ExternalFixedUpdate(Input);
        }
        #endregion
    }
}
