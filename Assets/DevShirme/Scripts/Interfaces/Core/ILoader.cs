using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.Interfaces
{
    public interface ILoader
    {
        public Dictionary<int, ILoadable> Loadables { get; }
        public List<ILoadable> Loadeds { get; }
        public bool IsContain(int indexValue);
        public void AddLoadable(int indexValue, ILoadable loadable);
    }
}
