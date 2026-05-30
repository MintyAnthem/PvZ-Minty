using UnityEngine;

public class Sunflower_Script : MonoBehaviour
{
    public GameObject sunCounterObject;
    public SunCounter_Script sunCounter;
    public float generateDelay;

    void Start()
    {
        sunCounterObject = GameObject.Find("Sun Counter");
        sunCounter = sunCounterObject.GetComponent<SunCounter_Script>();
        InvokeRepeating("GenerateSun", generateDelay, generateDelay);
    }

    public void GenerateSun()
    {
        sunCounter.ChangeSun(25);
    }
}
