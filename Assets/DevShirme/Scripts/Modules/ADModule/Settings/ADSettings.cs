using DevShirme.Utils;
//using GoogleMobileAds.Api;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.ADModule
{
    [CreateAssetMenu(fileName = "ADSettings", menuName = "DevShirme/Settings/AD Settings")]
    public class ADSettings : ScriptableObject
    {
        #region Fields
        [Header("AD Settings")]
        [SerializeField] private string[] adIds;
        [SerializeField] private string[] testAdIds;
        //[Header("Banner Settings")]
        //[SerializeField] private AdSize bannerSize = AdSize.Banner;
        //[SerializeField] private AdPosition bannerPosition = AdPosition.Top;
        #endregion

        #region Getters
        public string GetID(Enums.ADType adType, bool test)
        {
            string id = test ? testAdIds[((int)adType)] : adIds[((int)adType)];
            return id;
        }
        //public AdSize BannerSize => bannerSize;
        //public AdPosition BannerPosition => bannerPosition;
        #endregion
    }
}
