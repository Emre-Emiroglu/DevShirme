using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using DevShirme.Utils;

namespace DevShirme
{
    public class PlayerDataSet : DataSet<Structs.PlayerData>
    {
        #region Fields
        public Structs.PlayerData MyData;
        #endregion

        #region Constructor
        public PlayerDataSet(string fileName) : base(fileName)
        {
            Load();
        }
        #endregion

        #region Executes
        public override void Save()
        {
            string content = JsonUtility.ToJson(MyData);
            File.WriteAllText(getPath(fileName), content);
        }
        public override void Load()
        {
            if (File.Exists(getPath(fileName)))
            {
                string read = File.ReadAllText(getPath(fileName));
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
        public override void Clear()
        {
            base.Clear();
        }
        #endregion
    }
}
