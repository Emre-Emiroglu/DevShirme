using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.LevelModule
{
    public class LevelModule : Module
    {
        #region Fields
        private Level currentLevel;
        private readonly LevelSettings ls;
        #endregion

        #region Core
        public override void Initialize()
        {
        }
        public void LoadLevel()
        {
            currentLevel = Instantiate(ls.GetLevel());
            currentLevel.LoadLevel();
        }
        public void UnLoadLevel()
        {
            currentLevel.UnLoadLevel();
            Destroy(currentLevel.gameObject);
            currentLevel = null;
        }
        #endregion
    }
}
