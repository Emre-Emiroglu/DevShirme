using DevShirme.Helpers;
using DevShirme.PoolModule;
using DevShirme.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.LevelModule
{
    public class Holder : MonoBehaviour
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
            string name = itemType == Enums.GameItemType.Collectable ? collectableType.ToString() : obstacleType.ToString();
            myItem = GameHelper.CallFromPool(name, transform.position, transform.rotation);
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
