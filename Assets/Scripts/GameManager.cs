using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI CollectedItemsText;
    public TextMeshProUGUI scorePointsText;
    public int score;
    public int CollectedItems;
    public GameObject PickUpScore;
    public GameObject challenge;
    private bool endBool;
    private void Start()
    {
        CollectedItems = 00;
        endBool = true;
        SetInitialCollectedItems();
       

        
    }

    private void Update()
    {
        scorePointsText.text = "" + score;
        UpdateCollectedItems();
        if(endBool == true && CollectedItems < 10)
        {
            PickUpScore.SetActive(true);
            challenge.SetActive(false);
        }else if(endBool == true && CollectedItems == 10)
        {
            PickUpScore.SetActive(false);
            challenge.SetActive(true);
            endBool = false;
            
        }
    }

    // Start is called before the first frame update
    public void SetInitialCollectedItems()
    {
        DisplayCollectedItems(CollectedItems);
    }

    public void UpdateCollectedItems()
    {

        DisplayCollectedItems(CollectedItems);
    }

    private void DisplayCollectedItems(int count)
    { 
        if(count < 10)
        {
            CollectedItemsText.text = "0" + count + "/10";
        }else if (count >= 10)
        {
            CollectedItemsText.text = count + "/10";
        }
        
    }

   

    
}
 