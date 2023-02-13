using System.Collections;
using System.Collections.Generic;
using UnityEditor;
#if UNITY_EDITOR
using UnityEngine;
#endif

namespace DevShirme.DataModule
{
    public class DataManager : Manager
    {
        #region Fields
        private PlayerData playerData;
        #endregion

        #region Getters
        public PlayerData PlayerData => playerData;
        #endregion

        #region Core
        public override void Initialize()
        {
            playerData = new PlayerData();
            playerData.LoadData();
        }
        #endregion

        #region Executes
#if UNITY_EDITOR
        [MenuItem("DevShirme/ClearDatas")]
        public static void ClearDatas()
        {
            PlayerPrefs.DeleteAll();
            PlayerPrefs.Save();
        }
#endif
        #endregion
    }
}

