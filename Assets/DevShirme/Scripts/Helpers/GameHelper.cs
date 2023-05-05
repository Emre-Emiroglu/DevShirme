using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.Helpers
{
    public static class GameHelper
    {
        public static void CoinChange(int value, bool save = true, bool sendSignal = true)
        {
            DataManager.PlayerDataSet.MyData.Coin += value;
            if (save)
            {
                DataManager.PlayerDataSet.Save();
            }
            if (sendSignal)
            {
                GameManager.OnCoinChanged?.Invoke(DataManager.PlayerDataSet.MyData.Coin);
            }
        }
        public static void PlayerProgress(bool positive = true)
        {
            if (positive)
                DataManager.PlayerDataSet.MyData.Level++;
            else
                DataManager.PlayerDataSet.MyData.Level--;

            DataManager.PlayerDataSet.Save();
        }
        public static PoolObject CallFromPool(string tag, Vector3 pos, Quaternion rot)
        {
            PoolManager pm = Core.Instance.GetManager(Utils.Enums.InitType.PreInit, Utils.Enums.ManagerType.PoolManager) as PoolManager;
            return pm.GetObj(tag, pos, rot);
        }
    }
}
