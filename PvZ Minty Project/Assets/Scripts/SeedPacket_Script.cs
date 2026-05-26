using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class SeedPacket_Script : MonoBehaviour, IPointerDownHandler
{
    public GameObject sunCounterObject;
    public SunCounter_Script sunCounter;
    public GameObject previewPlantObject;
    public PreviewPlant_Script previewPlant;

    public bool isReloaded;
    public Image reloadBar;
    public float maxReload;
    public float currentReload;

    public Plant_ScriptableObject plantStats;
    public Image packetImage;
    public TextMeshProUGUI packetCost;
    public BoxCollider2D boxCollider;

    void Awake()
    {
        sunCounterObject = GameObject.Find("Sun Counter");
        sunCounter = sunCounterObject.GetComponent<SunCounter_Script>();

        previewPlantObject = GameObject.Find("PreviewPlant");
        previewPlant = previewPlantObject.GetComponent<PreviewPlant_Script>();

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

        isReloaded = true;
        reloadBar.enabled = false;
        maxReload = plantStats.plantReload;
        currentReload = maxReload;
    }

    void Update()
    {
        if (!isReloaded)
        {
            ReloadPacket();          
        }

        
    }

    public void ReloadPacket()
    {
        reloadBar.fillAmount = currentReload / maxReload;
        currentReload -= Time.deltaTime;
        if (currentReload <= 0)
        {
            boxCollider.enabled = true;
            reloadBar.enabled = false;
            isReloaded = true;
            currentReload = maxReload;
        }
    }


    public void OnPointerDown(PointerEventData pointerEventData)
    {
        if (plantStats.sunCost <= sunCounter.sunAmount && isReloaded)
        {
            Debug.Log("Success");
            sunCounter.ChangeSun(-plantStats.sunCost);
            previewPlant.SetPlant(plantStats);
            boxCollider.enabled = false;
            reloadBar.enabled = true;
            isReloaded = false;
        }
        else if (plantStats.sunCost > sunCounter.sunAmount)
        {
            Debug.Log("Failure");
        }

    }

    //Detect if clicks are no longer registering
    //public void OnPointerUp(PointerEventData pointerEventData)
    //{
        //Debug.Log(name + "No longer being clicked");
    //}
}
