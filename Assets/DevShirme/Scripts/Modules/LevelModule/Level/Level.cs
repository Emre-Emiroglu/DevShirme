using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.LevelModule
{
    public class Level : MonoBehaviour
    {
        #region Fields
        [Header("Level Design Elements")]
        [SerializeField] private Holder[] holders;
        #endregion

        #region Core
        public void LoadLevel()
        {
            for (int i = 0; i < holders.Length; i++)
            {
                holders[i].LoadLevel();
            }
        }
        public void UnLoadLevel()
        {
            for (int i = 0; i < holders.Length; i++)
            {
                holders[i].UnLoadLevel();
            }
        }
        #endregion
    }
}
