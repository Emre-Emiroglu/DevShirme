using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace DevShirme.DataModule
{
    [Serializable]
    public class PlayerData : Data
    {
        #region Fields
        public int Coin;
        #endregion

        #region Constructor
        public PlayerData()
        {
        }
        #endregion

        #region Executes
        public override void LoadData()
        {
        }
        public override void SaveData()
        {
            Coin += 5;
        }
        #endregion
    }

}
