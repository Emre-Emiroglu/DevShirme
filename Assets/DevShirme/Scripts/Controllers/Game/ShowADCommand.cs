using DevShirme.Interfaces;
using DevShirme.Utils;
using strange.extensions.command.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.Controllers
{
    public class ShowADCommand : Command
    {
        #region Injects
        [Inject] public Enums.ADType ADType { get; set; }
        [Inject] public IADModel ADModel { get; set; }
        #endregion

        #region Executes
        public override void Execute()
        {
            switch (ADType)
            {
                case Enums.ADType.Banner:
                    bannerADRequest();
                    break;
                case Enums.ADType.Interstital:
                    interstitialADRequest();
                    interstitalADShow();
                    break;
                case Enums.ADType.Rewarded:
                    rewardedADRequest();
                    rewardedADShow();
                    break;
            }
        }
        #endregion

        #region Shows
        private void interstitalADShow()
        {
            //if (interstitialAd != null && interstitialAd.CanShowAd())
            //{
            //    Debug.Log("Showing interstitial ad.");
            //    interstitialAd.Show();
            //}
            //else
            //{
            //    Debug.LogError("Interstitial ad is not ready yet.");
            //}
        }
        private void rewardedADShow()
        {
            //if (rewardedAd != null && rewardedAd.CanShowAd())
            //{
            //    rewardedAd.Show(rewardedADCallBack);
            //    registerEventHandlers(rewardedAd);
            //}
        }
        private void rewardedADCallBack()
        {
        }
        //private void registerEventHandlers(RewardedAd ad)
        //{
        //    // Raised when the ad is estimated to have earned money.
        //    ad.OnAdPaid += (AdValue adValue) =>
        //    {
        //    };
        //    // Raised when an impression is recorded for an ad.
        //    ad.OnAdImpressionRecorded += () =>
        //    {
        //        Debug.Log("Rewarded ad recorded an impression.");
        //    };
        //    // Raised when a click is recorded for an ad.
        //    ad.OnAdClicked += () =>
        //    {
        //        Debug.Log("Rewarded ad was clicked.");
        //    };
        //    // Raised when an ad opened full screen content.
        //    ad.OnAdFullScreenContentOpened += () =>
        //    {
        //        OnRewardedADBegan?.Invoke();
        //        Debug.Log("Rewarded ad full screen content opened.");
        //    };
        //    // Raised when the ad closed full screen content.
        //    ad.OnAdFullScreenContentClosed += () =>
        //    {
        //        Debug.Log("Rewarded ad full screen content closed.");
        //        OnRewardedADEnded?.Invoke();
        //        rewardedADRequest();
        //    };
        //    // Raised when the ad failed to open full screen content.
        //    ad.OnAdFullScreenContentFailed += (AdError error) =>
        //    {
        //        Debug.LogError("Rewarded ad failed to open full screen content " +
        //                       "with error : " + error);

        //        OnRewardedADEnded?.Invoke();
        //        rewardedADRequest();
        //    };
        //}
        #endregion

        #region Requests
        private void bannerADRequest()
        {
#if UNITY_ANDROID
            string id = adSettings.GetID(Enums.ADType.Banner, true);
#elif UNITY_IPHONE
  string id = "ca-app-pub-3940256099942544/2934735716";
#else
            //string id = "unused";
#endif
            //if (bannerView != null)
            //{
            //    bannerView.Destroy();
            //    bannerView = null;
            //}

            //AdRequest adRequest = new AdRequest.Builder().Build();

            //bannerView = new BannerView(id, data.BannerSize, data.BannerPosition);
            //bannerView.LoadAd(adRequest);
        }
        private void interstitialADRequest()
        {
#if UNITY_ANDROID
            string id = adSettings.GetID(Enums.ADType.Interstital, true);
#elif UNITY_IPHONE
  string id = "ca-app-pub-3940256099942544/4411468910";
#else
            //string id = "unused";
#endif
            //if (interstitialAd != null)
            //{
            //    interstitialAd.Destroy();
            //    interstitialAd = null;
            //}

            //AdRequest adRequest = new AdRequest.Builder().Build();

            //InterstitialAd.Load(id, adRequest, (InterstitialAd ad, LoadAdError error) =>
            //{
            //    if (error != null || ad == null)
            //    {
            //        Debug.LogError("interstitial ad failed to load an ad " +
            //                       "with error : " + error);
            //        return;
            //    }

            //    Debug.Log("Interstitial ad loaded with response : "
            //              + ad.GetResponseInfo());

            //    interstitialAd = ad;
            //});
        }
        private void rewardedADRequest()
        {
#if UNITY_ANDROID
            string id = adSettings.GetID(Enums.ADType.Rewarded, true);
#elif UNITY_IPHONE
  string id = "ca-app-pub-3940256099942544/1712485313";
#else
            //string id = "unused";
#endif
            //if (rewardedAd != null)
            //{
            //    rewardedAd.Destroy();
            //    rewardedAd = null;
            //}

            //AdRequest adRequest = new AdRequest.Builder().Build();

            //RewardedAd.Load(id, adRequest, (RewardedAd ad, LoadAdError error) =>
            //{
            //    if (error != null || ad == null)
            //    {
            //        Debug.LogError("Rewarded ad failed to load an ad " +
            //                       "with error : " + error);
            //        return;
            //    }

            //    Debug.Log("Rewarded ad loaded with response : "
            //              + ad.GetResponseInfo());

            //    rewardedAd = ad;
            //});
        }
        #endregion
    }
}
