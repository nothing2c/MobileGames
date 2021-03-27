using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class UnityAdManager : MonoBehaviour, IUnityAdsListener
{
    string gameId = "4045765";
    string bannerId = "Banner_Android";
    string intertsitialId = "Interstitial_Android";
    string rewardId = "Rewarded_Android";
    bool testMode = true;

    void Start()
    {
        Advertisement.Initialize(gameId, testMode);

        StartCoroutine(ShowBanner());
        StartCoroutine(ShowIntertsitial());
        //StartCoroutine(ShowReward());
    }

    IEnumerator ShowBanner()
    {
        while (!Advertisement.IsReady(bannerId))
            yield return null;

        Advertisement.Banner.SetPosition(BannerPosition.TOP_CENTER);
        Advertisement.Banner.Show(bannerId);
    }

    IEnumerator ShowIntertsitial()
    {
        while (!Advertisement.IsReady(intertsitialId))
            yield return null;

        Advertisement.Show(intertsitialId);
    }

    IEnumerator ShowReward()
    {
        while (!Advertisement.IsReady(rewardId))
            yield return null;

        Advertisement.Show(rewardId);
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        throw new System.NotImplementedException();
    }

    public void OnUnityAdsDidError(string message)
    {
    }


    public void OnUnityAdsDidStart(string placementId)
    {
    }

    public void OnUnityAdsReady(string placementId)
    {
    }

}
