using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using DevShirme.Utils;

namespace DevShirme.Managers.DataManager
{
    public class PlayerDataSet : DataSet<Structs.PlayerData>
    {
        #region Fields
        public Structs.PlayerData MyData;
        #endregion

        #region Constructor
        public PlayerDataSet() : base("ply.dat")
        {
            Load();
        }
        #endregion

        #region Executes
        public override void Save()
        {
            string content = JsonUtility.ToJson(MyData);
            File.WriteAllText(path, content);
        }
        public override void Load()
        {
            if (File.Exists(path))
            {
                string read = File.ReadAllText(path);
                MyData = JsonUtility.FromJson<Structs.PlayerData>(read);

                Debug.Log("Data Loaded");
            }
            else
            {
                MyData = new Structs.PlayerData(1, 100, false, true, true);
                Save();
                Debug.Log("Data Not Found. Created New One");
            }
        }
        #endregion
    }
}
