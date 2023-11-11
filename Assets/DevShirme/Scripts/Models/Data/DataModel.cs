using DevShirme.Interfaces.Data;
using DevShirme.Utils.Structs;
using System;
using System.IO;
using UnityEditor;
using UnityEngine;
using Zenject;

namespace DevShirme.Models.Data
{
    [Serializable]
    public class DataModel : IDataModel, IInitializable
    {
        #region Fields
        [Header("Data Model Settings")]
        [SerializeField] private string path = "/" + "ply.dat";
        #endregion

        #region Props
        public Structs.PlayerData PlayerData { get; set; }
        #endregion

        #region Core
        public void Initialize()
        {
            Load();
        }
        public void Save()
        {
            string content = JsonUtility.ToJson(PlayerData);
            File.WriteAllText(Application.persistentDataPath + path, content);
        }
        public void Load()
        {
            if (File.Exists(Application.persistentDataPath + path))
            {
                string read = File.ReadAllText(Application.persistentDataPath + path);
                PlayerData = JsonUtility.FromJson<Structs.PlayerData>(read);

                Debug.Log("Data Loaded");
            }
            else
            {
                PlayerData = new Structs.PlayerData(1, 100, false, true, true);
                Save();
                Debug.Log("Data Not Found. Created New One");
            }
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
