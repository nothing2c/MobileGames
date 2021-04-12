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

    private string choice;
    private List<GameObject> Panels;

    private Coin coin;

    private int tries;
    // Start is called before the first frame update
    void Start()
    {
        coin = FindCoin();

        Panels = new List<GameObject>();
        Panels.Add(MainOptionsPanel);
        Panels.Add(ChoicePanel);

        tries = 3;
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
        tries -= 1;

        if (result != choice)
            ResultText.text = result + "\nWrong";
        else
            ResultText.text = result + "\nRight";

        if (tries <= 0)
            Debug.Log("out of tries");
        else
            ShowPanel("Main");
    }

    public void OnChoiceSelected(string option)
    {
        choice = option;
        DeactivatePanels();
        coin.Flip();
    }
}
