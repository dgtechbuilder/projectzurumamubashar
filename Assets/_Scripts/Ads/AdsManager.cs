using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds;
using GoogleMobileAds.Api;
using System;


public enum RewardType
{
    FreeCoins,
    FreeSword
}


public class AdsManager : MonoBehaviour
{

    public static AdsManager Instance;

    // These ad units are configured to always serve test ads.
#if UNITY_ANDROID
    public string _BanneradUnitId = "ca-app-pub-3940256099942544/6300978111";
    public string _InteradUnitId = "ca-app-pub-3940256099942544/1033173712";
    public string _RewardadUnitId = "ca-app-pub-3940256099942544/5224354917";
#elif UNITY_IPHONE
    public string _BanneradUnitId = "ca-app-pub-3940256099942544/2934735716";
    public string _InteradUnitId = "ca-app-pub-3940256099942544/4411468910";
    public string _RewardadUnitId = "ca-app-pub-3940256099942544/1712485313";
#else
  public string _BanneradUnitId = "unused";
  public string _InteradUnitId = "unused";
  public string _RewardadUnitId = "unused";
#endif
    private bool _isMobileAdsInitialized;
    private bool _pendingBannerShow;

    public AdPosition BannerAdPosition = AdPosition.Top;

    // Start is called before the first frame update
    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
            // Initialize the Google Mobile Ads SDK.
            MobileAds.Initialize((InitializationStatus initStatus) =>
            {
                Debug.Log("Mobile Ads SDK initialized.");
                _isMobileAdsInitialized = true;
                InstantiateAds();

                if (_pendingBannerShow)
                {
                    _pendingBannerShow = false;
                    ShowBannerAd();
                }
            });
        }
        else
        {
            return;
        }
    }

    void InstantiateAds()
    {
        if (!_isMobileAdsInitialized)
        {
            Debug.LogWarning("InstantiateAds called before Mobile Ads initialization finished.");
            return;
        }

        CreateBannerView();
        CreateInterstitialAd();
        CreateRewardedAd();
    }

    BannerView _bannerView;

    /// <summary>
    /// Creates a 320x50 banner view at top of the screen.
    /// </summary>
    public void CreateBannerView()
    {
        Debug.Log("Creating banner view");

        // If we already have a banner, destroy the old one.
        if (_bannerView != null)
        {
            DestroyAd();
        }

        // Create a 320x50 banner at the configured position on the screen
        _bannerView = new BannerView(_BanneradUnitId, AdSize.Banner, BannerAdPosition);

        _bannerView.OnBannerAdLoaded += () =>
        {
            Debug.Log("Banner ad loaded.");
            _bannerView.Show();
        };

        _bannerView.OnBannerAdLoadFailed += (LoadAdError error) =>
        {
            Debug.LogError($"Banner ad failed to load with error: {error}");
        };
    }

    private void DestroyAd()
    {
        _bannerView.Destroy();
        _bannerView = null;
    }

    /// <summary>
    /// Creates the banner view and loads a banner ad.
    /// </summary>
    public void ShowBannerAd()
    {
        if (!_isMobileAdsInitialized)
        {
            Debug.LogWarning("ShowBannerAd called before Mobile Ads initialization finished. Queuing request.");
            _pendingBannerShow = true;
            return;
        }

        // create an instance of a banner view first.
        if (_bannerView == null)
        {
            CreateBannerView();
        }

        // create our request used to load the ad.
        var adRequest = new AdRequest();

        // send the request to load the ad.
        Debug.Log("Loading banner ad.");
        _bannerView.LoadAd(adRequest);
    }

    public void HideBannerAd()
    {
        if (_bannerView != null)
        {
            Debug.Log("Hiding banner ad.");
            _bannerView.Hide();
        }
    }

    private InterstitialAd _interstitialAd;

    /// <summary>
    /// Loads the interstitial ad.
    /// </summary>
    public void CreateInterstitialAd()
    {
        // Clean up the old ad before loading a new one.
        if (_interstitialAd != null)
        {
            _interstitialAd.Destroy();
            _interstitialAd = null;
        }

        Debug.Log("Loading the interstitial ad.");

        // create our request used to load the ad.
        var adRequest = new AdRequest();

        // send the request to load the ad.
        InterstitialAd.Load(_InteradUnitId, adRequest,
            (InterstitialAd ad, LoadAdError error) =>
            {
                // if error is not null, the load request failed.
                if (error != null || ad == null)
                {
                    Debug.LogError("interstitial ad failed to load an ad " +
                                   "with error : " + error);
                    return;
                }

                Debug.Log("Interstitial ad loaded with response : "
                          + ad.GetResponseInfo());

                _interstitialAd = ad;
                RegisterEventHandlersInter(_interstitialAd);
                //RegisterReloadHandler(_interstitialAd);
            });


    }

    /// <summary>
    /// Shows the interstitial ad.
    /// </summary>
    public void ShowInterstitialAd()
    {
        if (_interstitialAd != null && _interstitialAd.CanShowAd() /*&& PlayerPrefManager.CanShowAds() == false*/)
        {
            Debug.Log("Showing interstitial ad.");
            _interstitialAd.Show();
        }
        else
        {
            Debug.LogError("Interstitial ad is not ready yet.");
        }
    }

    private void RegisterEventHandlersInter(InterstitialAd interstitialAd)
    {
        // Raised when the ad is estimated to have earned money.
        interstitialAd.OnAdPaid += (AdValue adValue) =>
        {
            Debug.Log(String.Format("Interstitial ad paid {0} {1}.",
                adValue.Value,
                adValue.CurrencyCode));
        };
        // Raised when an impression is recorded for an ad.
        interstitialAd.OnAdImpressionRecorded += () =>
        {
            Debug.Log("Interstitial ad recorded an impression.");
        };
        // Raised when a click is recorded for an ad.
        interstitialAd.OnAdClicked += () =>
        {
            Debug.Log("Interstitial ad was clicked.");
        };
        // Raised when an ad opened full screen content.
        interstitialAd.OnAdFullScreenContentOpened += () =>
        {
            Debug.Log("Interstitial ad full screen content opened.");
        };
        // Raised when the ad closed full screen content.
        interstitialAd.OnAdFullScreenContentClosed += () =>
        {
            Debug.Log("Interstitial ad full screen content closed.");
            CreateInterstitialAd();
        };
        // Raised when the ad failed to open full screen content.
        interstitialAd.OnAdFullScreenContentFailed += (AdError error) =>
        {
            Debug.LogError("Interstitial ad failed to open full screen content " +
                           "with error : " + error);
            CreateInterstitialAd();
        };


    }

    private void RegisterReloadHandler(InterstitialAd interstitialAd)
    {
        // Raised when the ad closed full screen content.
        interstitialAd.OnAdFullScreenContentClosed += () =>
    {
        Debug.Log("Interstitial Ad full screen content closed.");

        // Reload the ad so that we can show another as soon as possible.
        CreateInterstitialAd();
    };
        // Raised when the ad failed to open full screen content.
        interstitialAd.OnAdFullScreenContentFailed += (AdError error) =>
        {
            Debug.LogError("Interstitial ad failed to open full screen content " +
                           "with error : " + error);

            // Reload the ad so that we can show another as soon as possible.
            CreateInterstitialAd();
        };
    }

    private RewardedAd _rewardedAd;

    public void CreateRewardedAd()
    {
        // Clean up the old ad before loading a new one.
        if (_rewardedAd != null)
        {
            _rewardedAd.Destroy();
            _rewardedAd = null;
        }

        Debug.Log("Loading the rewarded ad.");

        // create our request used to load the ad.
        var adRequest = new AdRequest();

        // send the request to load the ad.
        RewardedAd.Load(_RewardadUnitId, adRequest,
            (RewardedAd ad, LoadAdError error) =>
            {
                // if error is not null, the load request failed.
                if (error != null || ad == null)
                {
                    Debug.LogError("Rewarded ad failed to load an ad " +
                                   "with error : " + error);
                    return;
                }

                Debug.Log("Rewarded ad loaded with response : "
                          + ad.GetResponseInfo());

                _rewardedAd = ad;
                RegisterEventHandlersReward(_rewardedAd);
            });
    }

    public void ShowRewardedAd()
    {
        const string rewardMsg =
            "Rewarded ad rewarded the user. Type: {0}, amount: {1}.";

        if (_rewardedAd != null && _rewardedAd.CanShowAd())
        {
            _rewardedAd.Show((Reward reward) =>
            {
                // TODO: Reward the user.
                Debug.Log(String.Format(rewardMsg, reward.Type, reward.Amount));
            });
        }
    }

    public void ShowRewardedAd(RewardType rewardType, int rewardAmount = 0)
    {
        const string rewardMsg =
            "Rewarded ad rewarded the user. Type: {0}, amount: {1}.";

        if (_rewardedAd != null && _rewardedAd.CanShowAd())
        {
            _rewardedAd.Show((Reward reward) =>
            {
                // TODO: Reward the user.

                switch (rewardType)
                {
                    case RewardType.FreeCoins:
                        Time.timeScale = 1;
                        PlayerEconomyManager.AddCoins(UImanager.coin * 2);
                        UImanager.NextScene();
                        break;
                    case RewardType.FreeSword:
                        Time.timeScale = 1;
                        PlayerEconomyManager.AddSword(1);
                        UImanager.instance.AfterFreeSowrd();
                        break;
                }
                Debug.Log(String.Format(rewardMsg, reward.Type, reward.Amount));
            });
        }
    }

    private void RegisterEventHandlersReward(RewardedAd ad)
    {
        // Raised when the ad is estimated to have earned money.
        ad.OnAdPaid += (AdValue adValue) =>
        {
            Debug.Log(String.Format("Rewarded ad paid {0} {1}.",
                adValue.Value,
                adValue.CurrencyCode));
        };
        // Raised when an impression is recorded for an ad.
        ad.OnAdImpressionRecorded += () =>
        {
            Debug.Log("Rewarded ad recorded an impression.");
        };
        // Raised when a click is recorded for an ad.
        ad.OnAdClicked += () =>
        {
            Debug.Log("Rewarded ad was clicked.");
        };
        // Raised when an ad opened full screen content.
        ad.OnAdFullScreenContentOpened += () =>
        {
            Debug.Log("Rewarded ad full screen content opened.");
        };
        // Raised when the ad closed full screen content.
        ad.OnAdFullScreenContentClosed += () =>
        {
            Debug.Log("Rewarded Ad full screen content closed.");

            // Reload the ad so that we can show another as soon as possible.
            CreateRewardedAd();
        };
        // Raised when the ad failed to open full screen content.
        ad.OnAdFullScreenContentFailed += (AdError error) =>
        {
            Debug.LogError("Rewarded ad failed to open full screen content " +
                           "with error : " + error);

            // Reload the ad so that we can show another as soon as possible.
            CreateRewardedAd();
        };
    }


}
