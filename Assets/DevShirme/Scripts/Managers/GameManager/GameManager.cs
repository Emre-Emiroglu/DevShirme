using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DevShirme.Helpers;

namespace DevShirme
{
    public class GameManager : DevShirmeManager, IGameCycle
    {
        #region Fields
        [Header("Gameplay Controllers")]
        [SerializeField] private List<DevShirmeController> controllers;
        #endregion

        #region Core
        public override void Initialize()
        {
            for (int i = 0; i < controllers.Count; i++)
            {
                controllers[i].Initialize();
            }
        }
        public void GameStart()
        {
            for (int i = 0; i < controllers.Count; i++)
            {
                controllers[i].GameStart();
            }
        }
        public void Reload()
        {
            ScoreHandler.Reload();

            for (int i = 0; i < controllers.Count; i++)
            {
                controllers[i].Reload();
            }
        }
        public void GameOver()
        {
            for (int i = 0; i < controllers.Count; i++)
            {
                controllers[i].GameOver();
            }
        }
        public void GameFail()
        {
            for (int i = 0; i < controllers.Count; i++)
            {
                controllers[i].GameFail();
            }
        }
        public void GameSuccess()
        {
            for (int i = 0; i < controllers.Count; i++)
            {
                controllers[i].GameSuccess();
            }
        }
        #endregion
    }
}
