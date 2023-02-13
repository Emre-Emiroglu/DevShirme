using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DevShirme.Helpers;
using DevShirme.DataModule;

namespace DevShirme.UIModule
{
    public class ViewContainer : MonoBehaviour
    {
        #region Fields
        [Header("Score Views")]
        [SerializeField] private List<ScoreTextView> dynamicScoreTextViews;
        [SerializeField] private List<ScoreTextView> staticScoreTextViews;
        [Header("Level Views")]
        [SerializeField] private List<LevelTextView> levelTextViews;
        #endregion

        #region Getters
        private int getDataCoin()
        {
            DataManager dm = Core.Instance.GetAManager(Utils.Enums.ManagerType.DataManager) as DataManager;
            return dm.PlayerData.Coin;
        }
        private int getDataLevel()
        {
            DataManager dm = Core.Instance.GetAManager(Utils.Enums.ManagerType.DataManager) as DataManager;
            return dm.PlayerData.Level;
        }
        #endregion

        #region Core
        public void Initialize()
        {
            subDynamicHandlersToScoreSystem();
            setStaticScoreTextViews();
            setLevelTextViews();
        }
        public void Reload()
        {
            setStaticScoreTextViews();
            setLevelTextViews();
        }
        private void setStaticScoreTextViews()
        {
            for (int i = 0; i < staticScoreTextViews.Count; i++)
            {
                staticScoreTextViews[i].SetText(getDataCoin());
            }
        }
        private void subDynamicHandlersToScoreSystem()
        {
            for (int i = 0; i < dynamicScoreTextViews.Count; i++)
            {
                ScoreHandler.OnPlayerScoreChanged += dynamicScoreTextViews[i].SetText;
            }
        }
        private void setLevelTextViews()
        {
            int level = getDataLevel();
            for (int i = 0; i < levelTextViews.Count; i++)
            {
                levelTextViews[i].SetText(level);
            }
        }
        #endregion
    }
}

