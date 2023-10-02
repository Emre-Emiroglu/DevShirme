using DevShirme.Interfaces;
using strange.extensions.command.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.Controllers
{
    public class InitializePoolCommand : Command
    {
        #region Injects
        [Inject] public IPoolModel PoolModel { get; set; }
        #endregion

        #region Executes
        public override void Execute()
        {
            PoolModel.Initialize();
        }
        #endregion
    }
}
