using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.InputSystem;

public class PlantingSystem_Script : MonoBehaviour
{

    public Plant_ScriptableObject plantStats;
    public PreviewPlant_Script previewPlant;

    public GameObject selectMapObject;
    public Tilemap selectMap;
    public Vector3Int selectCoord;
    public Vector3Int previousSelectCoord;
    public Tile greenSelector;
    public Tile redSelector;

    public Tilemap plantLevel;
    public Vector3Int plantCoord;
    public Vector3Int previousPlantCoord;
    public Tile plantDetector;

    public Vector3 gameObjectCoord;

    public Vector2 mousePos;

    void Update()
    {
        if (plantStats != null)
        {
            selectMapObject.SetActive(true);
            mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());

        }
        else if (plantStats == null)
        {
            selectMapObject.SetActive(false);
        }

    }
}
