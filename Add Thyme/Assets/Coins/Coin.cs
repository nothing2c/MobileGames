using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private GameManager manager;
    private Animator Anim;
    private string result;

    void Awake()
    {
        manager = FindObjectOfType<GameManager>();
        Anim = GetComponent<Animator>();
        result = "";
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Flip()
    {
        Anim.SetTrigger("Flip");
        int resultInt = Random.Range(0, 2);

        if (resultInt == 0)
            result = "Heads";
        else
            result = "Tails";
    }

    // Called by event at the end of flip annimation
    public void ShowResult()
    {
        manager.ShowResult(result);
    }
}
