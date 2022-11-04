using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.DataModule
{
    public class DataManager : DevShirmeManager
    {
        #region Fields
        private PlayerData playerData;
        #endregion

        #region Core
        public override void Initialize()
        {
            playerData = new PlayerData();
        }
        #endregion

        #region Executes
        public void SaveAllData()
        {
            playerData.SaveData();
            string data = JsonUtility.ToJson(playerData);
            System.IO.File.WriteAllText(Application.persistentDataPath + "/ply.dat", data);

            Debug.Log(Application.persistentDataPath + "/ply.dat");
        }
        public void LoadAllData()
        {
            string oldData = System.IO.File.ReadAllText(Application.persistentDataPath + "/ply.dat");
            playerData = JsonUtility.FromJson<PlayerData>(oldData);
            playerData.LoadData();
            Debug.Log(playerData.Coin);
        }
        public void ClearAllData()
        {
        }
        #endregion
        private void Update()
        {
            if (Input.GetMouseButtonUp(0))
            {
                SaveAllData();
            }
            if (Input.GetMouseButtonUp(1))
            {
                LoadAllData();
            }
        }
    }
}

