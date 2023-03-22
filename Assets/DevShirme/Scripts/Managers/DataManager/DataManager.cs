using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace DevShirme.DataModule
{
    public class DataManager : Manager
    {
        #region Fields
        public static PlayerDataSet PlayerDataSet;
        #endregion

        #region Core
        public override void Initialize()
        {
            PlayerDataSet = new PlayerDataSet("ply.dat");
        }
        #endregion

        #region Executes
#if UNITY_EDITOR
        [MenuItem("DevShirme/ClearDataFolders")]
        public static void ClearDataFolders()
        {
            PlayerDataSet?.Clear();
        }
#endif
        #endregion
    }
}

