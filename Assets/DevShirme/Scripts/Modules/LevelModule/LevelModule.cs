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
            base.Initialize();
        }
        public override void OnGameStart()
        {
        }
        public override void OnGameReload()
        {
        }
        public override void OnGameOver()
        {
        }
        public override void OnGameSuccess()
        {
        }
        public override void OnGameFailed()
        {
        }
        protected override void setSubs(bool isSub)
        {
            base.setSubs(isSub);
        }
        #endregion

        #region Executes
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
