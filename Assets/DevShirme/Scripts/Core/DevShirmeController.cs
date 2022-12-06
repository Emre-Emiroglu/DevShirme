using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme
{
    public abstract class DevShirmeController : MonoBehaviour, IGameCycle
    {
        #region Fields
        [Header("Dev Controller Fields")]
        [SerializeField] protected DevSettings settings;
        #endregion

        #region Core
        public abstract void Initialize();
        public abstract void GameStart();
        public abstract void Reload();
        public abstract void GameOver();
        public abstract void GameFail();
        public abstract void GameSuccess();
        #endregion
    }
}
