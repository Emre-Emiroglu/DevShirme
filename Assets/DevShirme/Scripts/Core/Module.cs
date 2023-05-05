using DevShirme.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme
{
    public abstract class Module: MonoBehaviour, IModule
    {
        #region Fields
        [Header("Module Components")]
        [SerializeField] protected ScriptableObject settings;
        #endregion

        #region Core
        public virtual void Initialize()
        {
            setSubs(true);
        }
        public abstract void OnGameStart();
        public abstract void OnGameReload();
        public abstract void OnGameOver();
        public abstract void OnGameSuccess();
        public abstract void OnGameFailed();
        protected virtual void setSubs(bool isSub)
        {
            if (isSub)
            {
                GameManager.OnGameStart += OnGameStart;
                GameManager.OnGameReload += OnGameReload;
                GameManager.OnGameOver += OnGameOver;
                GameManager.OnGameSuccess += OnGameSuccess;
                GameManager.OnGameFailed += OnGameFailed;
            }
            else
            {
                GameManager.OnGameStart -= OnGameStart;
                GameManager.OnGameReload -= OnGameReload;
                GameManager.OnGameOver -= OnGameOver;
                GameManager.OnGameSuccess -= OnGameSuccess;
                GameManager.OnGameFailed -= OnGameFailed;
            }
        }
        private void OnDestroy()
        {
            setSubs(false);
        }
        #endregion
    }
}
