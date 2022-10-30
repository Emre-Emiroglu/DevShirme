using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.DataModule
{
    public abstract class Data
    {
        #region Executes
        public Data()
        {

        }
        public abstract void SaveData();
        public abstract void LoadData();
        #endregion
    }

}
