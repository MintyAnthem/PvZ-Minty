using UnityEngine;
using UnityEngine.EventSystems;

public class Lil_Poddas_Script : MonoBehaviour, IPointerDownHandler
{
    public SpriteRenderer lilPoddaRenderer;
    public int currentPodda;
    private int maxPodda = 3;
    public float poddaDelay;
    public Sprite zeroPodda;
    public Sprite onePodda;
    public Sprite twoPodda;
    public Sprite threePodda;
    public GameObject firstPodda;
    public GameObject secondPodda;
    public GameObject thirdPodda;
    public Transform deployPoint;
    public bool isCharging;

    void Start()
    {
        InvokeRepeating("ChargePodda", poddaDelay, poddaDelay);
    }

    void Update()
    {

        if (currentPodda == 0)
        {
            lilPoddaRenderer.sprite = zeroPodda;
        }
        else if (currentPodda == 1)
        {
            lilPoddaRenderer.sprite = onePodda;
        }
        else if (currentPodda == 2)
        {
            lilPoddaRenderer.sprite = twoPodda;
        }
        else if (currentPodda == 3)
        {
            lilPoddaRenderer.sprite = threePodda;
        }

        if (currentPodda > 3)
        {
            currentPodda = maxPodda;
        }

        if (currentPodda < 0)
        {
            currentPodda = 0;
        }
    }

    public void ChargePodda()
    {
        currentPodda++;

        if (currentPodda == 3)
        {
            CancelInvoke("ChargePodda");
        }

    }

    public void OnPointerDown(PointerEventData pointerEventData)
    {
        Debug.Log("Podda Clicked");
        if (currentPodda == 1)
        {
            Instantiate(firstPodda, deployPoint.position, Quaternion.identity);
            currentPodda--;
        }
        else if (currentPodda == 2)
        {
            Instantiate(secondPodda, deployPoint.position, Quaternion.identity);
            currentPodda--;
        }
        else if (currentPodda == 3)
        {
            Instantiate(thirdPodda, deployPoint.position, Quaternion.identity);
            currentPodda--;
            InvokeRepeating("ChargePodda", poddaDelay, poddaDelay);
        }
    }
}
