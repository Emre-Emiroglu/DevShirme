using DevShirme.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.Interfaces
{
    public interface IADModel
    {
        public string GetID(Enums.ADType adType, bool test);
        //public AdSize BannerSize { get; };
        //public AdPosition BannerPosition { get; };
    }
}

