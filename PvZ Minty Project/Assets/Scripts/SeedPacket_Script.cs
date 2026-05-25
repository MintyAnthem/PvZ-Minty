using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SeedPacket_Script : MonoBehaviour
{
    public GameObject sunCounter;
    public Plant_ScriptableObject plantStats;
    public Image packetImage;
    public TextMeshProUGUI packetCost;

    void Awake()
    {
        sunCounter = GameObject.Find("Sun Counter");

        if (plantStats != null)
        {
            packetImage.sprite = plantStats.plantSprite;
            packetCost.text = plantStats.sunCost.ToString();
        }
        else if (plantStats == null)
        {
            packetImage.sprite = null;
            packetCost.text = "0";
        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
