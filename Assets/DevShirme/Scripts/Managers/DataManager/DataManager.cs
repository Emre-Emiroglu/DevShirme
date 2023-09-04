using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace DevShirme.Managers.DataManager
{
    public class DataManager : Manager
    {
        #region Fields
        public static PlayerDataSet PlayerDataSet;
        private readonly DataManagerSettings dmSettings;
        #endregion

        #region Core
        public DataManager(ScriptableObject _settings) : base(_settings)
        {
            dmSettings = _settings as DataManagerSettings;

            _loader = new DataManagerModuleLoader(dmSettings.Modules, dmSettings.ModulesSettings);
            _loader.Load();

            PlayerDataSet = new PlayerDataSet();
        }
        #endregion

        #region Executes
#if UNITY_EDITOR
        [MenuItem("DevShirme/Data/ClearPlayerData")]
        public static void ClearPlayerData()
        {
            string path = Application.persistentDataPath + "/" + "ply.dat";

            if (File.Exists(path))
                File.Delete(path);
        }
        [MenuItem("DevShirme/Data/OpenDataFolder")]
        public static void OpenDataFolder()
        {
            string path = Application.persistentDataPath;

            EditorUtility.OpenFilePanel("", path, "");
        }
#endif
        #endregion

        #region Updates
        public override void ExternalUpdate()
        {
            base.ExternalUpdate();
        }
        public override void ExternalFixedUpdate()
        {
            base.ExternalFixedUpdate();
        }
        #endregion
    }
}

