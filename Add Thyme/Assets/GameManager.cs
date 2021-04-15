using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Canvas gui;
    public GameObject MainOptionsPanel;
    public GameObject ChoicePanel;
    public Text ResultText;

    public Text TriesText;
    public Text ChoiceText;

    private string choice;
    private List<GameObject> Panels;

    private Coin coin;

    private GoogleAdManager googleAds;
    private UnityAdManager unityAds;
    private int tries;
    private bool unlimitedTriesActive;
    // Start is called before the first frame update
    void Start()
    {
        coin = FindCoin();

        ResultText.text = "";

        ChoiceText.text = "";

        Panels = new List<GameObject>();
        Panels.Add(MainOptionsPanel);
        Panels.Add(ChoicePanel);

        googleAds = GetComponent<GoogleAdManager>();
        unityAds = GetComponent<UnityAdManager>();
        UpdateTries(3);
        unlimitedTriesActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private Coin FindCoin()
    {
        return FindObjectOfType<Coin>();
    }

    public void ShowPanel(string menu)
    {
        GameObject currentPanel;

        switch(menu)
        {
            case "Main":
                currentPanel = MainOptionsPanel;
                break;

            case "Choice":
                currentPanel = ChoicePanel;
                break;

            default:
                currentPanel = MainOptionsPanel;
                break;
        }

        foreach(GameObject panel in Panels)
        {
            if (panel == currentPanel)
                panel.SetActive(true);
            else
                panel.SetActive(false);
        }
    }

    private void DeactivatePanels()
    {
        foreach (GameObject panel in Panels)
        {
            panel.SetActive(false);
        }
    }

    public void ShowResult(string result)
    {
        if (result != choice)
            ResultText.text = result + "\nWrong";
        else
            ResultText.text = result + "\nRight";

        if (!unlimitedTriesActive)
        {
            UpdateTries(-1);
        }

        if (tries <= 0 && !unlimitedTriesActive)
        {
            Debug.Log("out of tries");
            int adSource = DetermineAdSource();

            if(adSource == 0)
            {
                StartCoroutine(googleAds.ShowInterstitial());
            }
            else
            {
                StartCoroutine(unityAds.ShowInterstitial());
            }
        }
        else
            ShowPanel("Main");
    }

    public void OnChoiceSelected(string option)
    {
        choice = option;
        ChoiceText.text = "Your Choice: " + option;
        DeactivatePanels();
        coin.Flip();
    }

    public void OnRewardButtonClick()
    {
        if(unlimitedTriesActive)
        {
            Debug.Log("already active");
            return;
        }

        int adSource = DetermineAdSource();

        if (adSource == 0)
        {
            StartCoroutine(googleAds.ShowReward());
        }
        else
        {
            StartCoroutine(unityAds.ShowReward());
        }
    }

    // 0 for unity, 1 for google
    private int DetermineAdSource()
    {
        return Random.Range(0, 2);
    }

    public void UpdateTries(int amount)
    {
        if(amount == 0)
        {
            unlimitedTriesActive = true;
            tries = 0;
            StartCoroutine(UnlimitedTriesTimer());
        }
        else
        {
            tries += amount;
            TriesText.text = "Number of tries left: " + tries.ToString();
        }
    }

    private IEnumerator UnlimitedTriesTimer()
    {
        float duration = 3f;
        float timeRemaining = duration;

        while (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;

            float minutes = Mathf.FloorToInt(timeRemaining / 60);
            float seconds = Mathf.FloorToInt(timeRemaining % 60);

            if (timeRemaining > 0)
                TriesText.text = "Unlimited Tries: " + string.Format("{0:00}:{1:00}", minutes, seconds);

            yield return null;
        }

        while (coin.isFlipping)
            yield return null;

        unlimitedTriesActive = false;
        UpdateTries(3);
    }
}
