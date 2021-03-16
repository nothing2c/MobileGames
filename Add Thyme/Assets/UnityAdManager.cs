using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class UnityAdManager : MonoBehaviour, IUnityAdsListener
{
    string gameId = "4045765";
    string rewardId = "Rewarded_Android";
    bool testMode = true;

    IEnumerator Start()
    {
        Advertisement.Initialize(gameId, testMode);

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
