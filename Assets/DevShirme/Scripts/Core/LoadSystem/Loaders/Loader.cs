using DevShirme.Interfaces;
using DevShirme.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme
{
    public abstract class Loader: ILoader
    {
        #region Fields
        protected readonly ScriptableObject[] _scriptableObjects;
        protected readonly Dictionary<int, ILoadable> _loadables;
        protected readonly List<ILoadable> _loadeds;
        #endregion

        #region Getters
        public Dictionary<int, ILoadable> Loadables => _loadables;
        public List<ILoadable> Loadeds => _loadeds;
        protected bool isContain(int indexValue) => _loadables.ContainsKey(indexValue);
        #endregion

        #region Core
        public Loader(ScriptableObject[] scriptableObjects)
        {
            this._scriptableObjects = scriptableObjects;
            _loadables = new Dictionary<int, ILoadable>();
            _loadeds = new List<ILoadable>();
        }
        public abstract void Load();
        #endregion
    }
}
