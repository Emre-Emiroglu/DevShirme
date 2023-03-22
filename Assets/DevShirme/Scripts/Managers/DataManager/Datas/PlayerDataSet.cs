using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace DevShirme.DataModule
{
    public class PlayerDataSet : DataSet<PlayerData>
    {
        #region Fields
        public PlayerData MyData;
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
                MyData = JsonUtility.FromJson<PlayerData>(read);

                Debug.Log("Data Loaded");
            }
            else
            {
                MyData = new PlayerData(1, 100, false, true, true);
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
public struct PlayerData
{
    public int Level;
    public int Coin;
    public bool IsSettingsOpen;
    public bool SoundOn;
    public bool VibrateOn;
    public PlayerData(int level, int coin, bool isSettingsOpen, bool soundOn, bool vibrateOn)
    {
        Level = level;
        Coin = coin;
        IsSettingsOpen = isSettingsOpen;
        SoundOn = soundOn;
        VibrateOn = vibrateOn;
    }
}