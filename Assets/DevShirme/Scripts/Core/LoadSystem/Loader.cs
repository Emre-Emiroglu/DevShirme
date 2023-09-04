using DevShirme.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme
{
    public class Loader: ILoader
    {
        #region Fields
        private Dictionary<int, ILoadable> loadables;
        private List<ILoadable> loadeds;
        #endregion

        #region Getters
        public Dictionary<int, ILoadable> Loadables => loadables;
        public List<ILoadable> Loadeds => loadeds;
        public bool IsContain(int indexValue) => loadables.ContainsKey(indexValue);
        #endregion

        #region Core
        public Loader()
        {
            loadables = new Dictionary<int, ILoadable>();
            loadeds = new List<ILoadable>();
        }
        public void AddLoadable(int indexValue, ILoadable loadable)
        {
            loadables.Add(indexValue, loadable);
            loadeds.Add(loadable);
        }
        #endregion
    }
}
