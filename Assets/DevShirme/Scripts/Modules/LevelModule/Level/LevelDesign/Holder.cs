using DevShirme.Helpers;
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
        [SerializeField] private bool drawGizmo;
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
            if (drawGizmo)
            {
                switch (itemType)
                {
                    case Enums.GameItemType.Collectable:
                        switch (collectableType)
                        {
                            case Enums.CollectableType.Coin:
                                Gizmos.color = Color.yellow;
                                Gizmos.DrawWireSphere(transform.position + Vector3.up * 1f, 1f);
                                break;
                        }
                        break;
                    case Enums.GameItemType.Obstacle:
                        switch (obstacleType)
                        {
                            case Enums.ObstacleType.Block:
                                Gizmos.color = Color.red;
                                Gizmos.DrawWireCube(transform.position + Vector3.up * .5f, new Vector3(1f, 1f, 1f));
                                break;
                        }
                        break;
                }
            }
        }
        #endregion
#endif
    }
}
