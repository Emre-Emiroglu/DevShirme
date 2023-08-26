using DevShirme.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.Utils
{
    public static class Structs
    {
        [Serializable]
        public struct PanelDatas
        {
            [SerializeField] private bool smoothPanels;
            [SerializeField] private float showDuration;
            [SerializeField] private float hideDuration;

            #region Getters
            public bool SmoothPanels => smoothPanels;
            public float ShowDuration => showDuration;
            public float HideDuration => hideDuration;
            #endregion
        }

        public struct PlayerData
        {
            public int Level;
            public int Coin;
            public bool IsSettingsOpen;
            public bool SoundOn;
            public bool VibrateOn;
            public PlayerData(int level, int coin, bool isSettingsOpen, bool soundOn, bool vibrateOn)
            {
                Level = level;
                Coin = coin;
                IsSettingsOpen = isSettingsOpen;
                SoundOn = soundOn;
                VibrateOn = vibrateOn;
            }
        }
    }
}
