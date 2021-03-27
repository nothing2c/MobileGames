using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Canvas gui;
    public GameObject ChoicePanel;
    public GameObject MainOptionsPanel;
    public Text ResultText;

    private string choice;

    private Coin coin;
    // Start is called before the first frame update
    void Start()
    {
        coin = FindCoin();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private Coin FindCoin()
    {
        return FindObjectOfType<Coin>();
    }

    public void TogglePanels()
    {
        MainOptionsPanel.SetActive(!MainOptionsPanel.activeInHierarchy);
        ChoicePanel.SetActive(!ChoicePanel.activeInHierarchy);
    }

    public void ShowResult(string result)
    {
        ResultText.text = result;

        if (result != choice)
            Debug.Log("Wrong");
        else
            Debug.Log("Right");
    }

    public void OnChoiceSelected(string option)
    {
        choice = option;
        coin.Flip();
    }
}
