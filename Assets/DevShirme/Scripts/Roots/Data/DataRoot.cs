using DevShirme.Contexts;
using strange.extensions.context.impl;
using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using System.IO;

namespace DevShirme.Roots
{
    public class DataRoot : ContextView
    {
        #region Core
        private void Awake()
        {
            context = new DataContext(this);
        }
        protected override void OnDestroy()
        {
            base.OnDestroy();
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
    }
}
