using DevShirme.Interfaces;
using DevShirme.Settings;
using DevShirme.Utils;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace DevShirme.Models
{
    public class DataModel : IDataModel
    {
        #region Fields
        private DataSettings dataSettings;
        private string path = Application.persistentDataPath + "/" + "ply.dat";
        #endregion

        #region Props
        public DataSettings DataSettings => dataSettings;
        public Structs.PlayerData PlayerData { get; set; }
        #endregion

        #region Core
        public void Initialize()
        {
            dataSettings = Resources.Load<DataSettings>("Settings/DataSettings");

            Load();
        }
        public void Save()
        {
            string content = JsonUtility.ToJson(PlayerData);
            File.WriteAllText(path, content);
        }
        public void Load()
        {
            if (File.Exists(path))
            {
                string read = File.ReadAllText(path);
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
    }
}
