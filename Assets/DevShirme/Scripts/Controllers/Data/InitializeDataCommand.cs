using DevShirme.Interfaces;
using strange.extensions.command.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.Controllers
{
    public class InitializeDataCommand : Command
    {
        #region Injects
        [Inject] public IDataModel DataModel { get; set; }
        #endregion

        #region Executes
        public override void Execute()
        {
            DataModel.Initialize();
        }
        #endregion
    }
}
