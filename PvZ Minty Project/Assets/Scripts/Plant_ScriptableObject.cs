using UnityEngine;

[CreateAssetMenu(fileName = "Plant_ScriptableObject", menuName = "Scriptable Objects/Plant_ScriptableObject")]
public class Plant_ScriptableObject : ScriptableObject
{
    public Sprite plantSprite;
    public string plantName;
    public int sunCost;
    public float plantReload;
    public GameObject plantObject;
}
