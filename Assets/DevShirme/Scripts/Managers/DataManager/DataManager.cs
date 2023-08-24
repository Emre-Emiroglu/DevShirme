using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace DevShirme
{
    public class DataManager : Manager
    {
        #region Fields
        public static PlayerDataSet PlayerDataSet;
        #endregion

        #region Core
        public override void Initialize()
        {
            PlayerDataSet = new PlayerDataSet();
        }
        #endregion

        #region Executes
#if UNITY_EDITOR
        [MenuItem("DevShirme/ClearPlayerData")]
        public static void ClearPlayerData()
        {
            string path = Application.persistentDataPath + "/" + "ply.dat";

            if (File.Exists(path))
                File.Delete(path);
        }
        [MenuItem("DevShirme/OpenDataFolder")]
        public static void OpenDataFolder()
        {
            string path = Application.persistentDataPath;

            EditorUtility.OpenFolderPanel("", path, "");
        }
#endif
        #endregion
    }
}

