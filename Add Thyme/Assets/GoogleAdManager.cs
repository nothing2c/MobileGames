using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class GoogleAdManager : MonoBehaviour
{
    private BannerView banner;
    private InterstitialAd interstitial;
    private RewardedAd reward;

    // Start is called before the first frame update
    void Start()
    {
        MobileAds.Initialize(initStatus => { });

        RequestBanner();

        RequestInterstitial();
        StartCoroutine(ShowInterstitial());

        RequestReward();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void RequestBanner()
    {
        string testID = "ca-app-pub-3940256099942544/6300978111";

        banner = new BannerView(testID, AdSize.Banner, AdPosition.Top);

        AdRequest request = new AdRequest.Builder().Build();
        banner.LoadAd(request);
    }

    private void RequestInterstitial()
    {
        string testID = "ca-app-pub-3940256099942544/1033173712";

        interstitial = new InterstitialAd(testID);

        AdRequest request = new AdRequest.Builder().Build();
        interstitial.LoadAd(request);
    }

    private void RequestReward()
    {
        string testID = "ca-app-pub-3940256099942544/5224354917";

        reward = new RewardedAd(testID);

        AdRequest request = new AdRequest.Builder().Build();
        reward.LoadAd(request);
    }

    IEnumerator ShowInterstitial()
    {
        while (!interstitial.IsLoaded())
            yield return null;

        interstitial.Show();
    }

    public void ShowReward()
    {
        StartCoroutine(ShowRewardCo());
    }

    IEnumerator ShowRewardCo()
    {
        while (!reward.IsLoaded())
            yield return null;

        reward.Show();
    }
}
