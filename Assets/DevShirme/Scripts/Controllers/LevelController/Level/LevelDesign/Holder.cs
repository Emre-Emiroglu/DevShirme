using DevShirme.PoolModule;
using DevShirme.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.LevelModule
{
    public class Holder : MonoBehaviour, ILevelCycle
    {
        #region Fields
        [Header("Holder Settings")]
        [SerializeField] private Enums.GameItemType itemType;
        [SerializeField] private Enums.CollectableType collectableType;
        [SerializeField] private Enums.ObstacleType obstacleType;
        private PoolObject myItem;
        #endregion

        #region Core
        public void LoadLevel()
        {
            PoolManager pm = Core.Instance.GetAManager(Enums.ManagerType.PoolManager) as PoolManager;
            string name = itemType == Enums.GameItemType.Collectable ? collectableType.ToString() : obstacleType.ToString();
            myItem = pm.GetObj(name, transform.position, transform.rotation) as PoolObject;
        }
        public void UnLoadLevel()
        {
            myItem?.DespawnObj();
        }
        #endregion

#if UNITY_EDITOR
        #region Gizmo
        private void OnDrawGizmos()
        {
            switch (itemType)
            {
                case Enums.GameItemType.Collectable:
                    break;
                case Enums.GameItemType.Obstacle:
                    break;
            }
        }
        #endregion
#endif
    }
}
