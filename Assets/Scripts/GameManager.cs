using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI CollectedItemsText;
    public TextMeshProUGUI GameOVerText;
    public int CollectedItems;

    private void Start()
    {
        SetInitialCollectedItems();
       

        
    }

    private void Update()
    {
        UpdateCollectedItems();
    }

    // Start is called before the first frame update
    public void SetInitialCollectedItems()
    {
        CollectedItems = 0;
        DisplayCollectedItems(CollectedItems);
    }

    public void UpdateCollectedItems()
    {

        DisplayCollectedItems(CollectedItems);
    }

    private void DisplayCollectedItems(int count)
    { 
        CollectedItemsText.text = "Collected Items: " + count + " mushrooms"; 
    }

    public void GameOver()
    {
        GameOVerText.gameObject.SetActive(true);
       
    }

    
}
 