using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.LevelModule
{
    public class LevelDesign : MonoBehaviour, ILevelCycle
    {
        #region Fields
        [Header("Level Design Elements")]
        [SerializeField] private Holder[] holders;
        private bool isGameStart;
        #endregion

        #region ILevelCycle
        public void LoadLevel()
        {
            isGameStart = false;

            for (int i = 0; i < holders.Length; i++)
            {
                //holders[i].LoadLevel();
            }
        }
        public void UnLoadLevel()
        {
            isGameStart = false;

            for (int i = 0; i < holders.Length; i++)
            {
                //holders[i].UnLoadLevel();
            }
        }
        #endregion
    }
}
