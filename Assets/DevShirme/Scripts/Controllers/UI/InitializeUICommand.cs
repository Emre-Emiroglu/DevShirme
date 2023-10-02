using DevShirme.Models;
using strange.extensions.command.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.Controllers
{
    public class InitializeUICommand : Command
    {
        #region Injects
        [Inject] public IUIModel UIModel { get; set; }
        #endregion

        #region Executes
        public override void Execute()
        {
        }
        #endregion
    }
}
