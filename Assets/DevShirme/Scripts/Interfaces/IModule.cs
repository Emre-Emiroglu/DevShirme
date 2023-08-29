using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.Interfaces
{
    public interface IModule: IUpdateable
    {
        public void SetSubscriptions(bool isSub);
    }
}
