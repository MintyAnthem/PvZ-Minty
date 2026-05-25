using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SunCounter_Script : MonoBehaviour
{
    public int sunAmount;
    public TextMeshProUGUI sunAmountDisplay;

    void Awake()
    {
        sunAmount = 0;
        sunAmountDisplay.text = sunAmount.ToString();
    }

    public void ChangeSun(int sunChange)
    {
        sunAmount += sunChange;
        sunAmountDisplay.text = sunAmount.ToString();
    }
}
