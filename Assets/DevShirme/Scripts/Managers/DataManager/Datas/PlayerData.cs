using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using DevShirme.Utils;

namespace DevShirme.DataModule
{
    [Serializable]
    public class PlayerData : Data
    {
        #region Fields
        public int Coin;
        public int Level;
        #endregion

        #region Constructor
        public PlayerData()
        {
        }
        #endregion

        #region Executes
        public override void LoadData()
        {
            Coin = PlayerPrefs.GetInt(Constants.PlayerDataCoin);
            Level = PlayerPrefs.GetInt(Constants.PlayerDataLevel);
            PlayerPrefs.Save();
        }
        public override void SaveData()
        {
            PlayerPrefs.SetInt(Constants.PlayerDataCoin, Coin);
            PlayerPrefs.SetInt(Constants.PlayerDataLevel, Level);
            PlayerPrefs.Save();
        }
        #endregion
    }

}
