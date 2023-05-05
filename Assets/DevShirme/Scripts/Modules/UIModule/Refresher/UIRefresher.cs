using DevShirme.Utils;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace DevShirme.UIModule
{
    public class UIRefresher : MonoBehaviour
    {
        #region Fields
        [Header("UI Elements")]
        [SerializeField] private TMP_Text[] inGameCoinTexts;
        [SerializeField] private TMP_Text[] dataCoinTexts;
        [SerializeField] private TMP_Text[] levelTexts;
        #endregion

        #region Core
        public void Initialize()
        {
            setSubs(true);
        }
        private void OnDestroy()
        {
            setSubs(false);
        }
        #endregion

        #region Receivers
        private void onCoinChanged(int dataScore)
        {
            setTexts(inGameCoinTexts, TextFormatter.FormatNumber(0));
            setTexts(dataCoinTexts, TextFormatter.FormatNumber(dataScore));
        }
        private void onLevelCreated(int currentLevel)
        {
            setTexts(levelTexts, "Level " + currentLevel.ToString());
        }
        #endregion

        #region Executes
        private void setTexts(TMP_Text[] texts, string value)
        {
            for (int i = 0; i < texts.Length; i++)
            {
                texts[i].SetText(value);
            }
        }
        private void setSubs(bool isSub)
        {
            if (isSub)
            {
                GameManager.OnCoinChanged += onCoinChanged;
                GameManager.OnLevelCreated += onLevelCreated;
            }
            else
            {
                GameManager.OnCoinChanged -= onCoinChanged;
                GameManager.OnLevelCreated -= onLevelCreated;
            }
        }
        #endregion
    }
}
