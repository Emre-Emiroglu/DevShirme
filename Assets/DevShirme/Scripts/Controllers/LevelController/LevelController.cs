using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.LevelModule
{
    public class LevelController : Controller, ILevelCycle
    {
        #region Fields
        private LevelSettings ls;
        public static LevelDesign currentLD;
        #endregion

        #region Core
        public override void Initialize()
        {
            ls = settings as LevelSettings;

            LoadLevel();
        }
        public override void GameStart()
        {

        }
        public override void Reload()
        {
            UnLoadLevel();
            LoadLevel();
        }
        public override void GameOver()
        {

        }
        public override void GameFail()
        {
        }
        public override void GameSuccess()
        {
        }
        #endregion

        #region ILevelCycle
        public void LoadLevel()
        {
            Level currentLevel = ls.GetLevel();
            currentLD = Instantiate(currentLevel.LevelDesign);
            currentLD.LoadLevel();
        }
        public void UnLoadLevel()
        {
            currentLD.UnLoadLevel();
            Destroy(currentLD.gameObject);
            currentLD = null;
        }
        #endregion
    }
}
