using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI CollectedItemsText;
    private int CollectedItems;

    // Start is called before the first frame update
    void Start()
    {
       
        CollectedItemsText.text = "Collected Items:" + CollectedItems + "mushrooms!";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
