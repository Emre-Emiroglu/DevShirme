using DevShirme.Interfaces;
using strange.extensions.command.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.Controllers
{
    public class InitializeAudioCommand : Command
    {
        #region Injects
        [Inject] public IAudioModel AudioModel { get; set; }
        #endregion

        #region Executes
        public override void Execute()
        {
        }
        #endregion
    }
}
