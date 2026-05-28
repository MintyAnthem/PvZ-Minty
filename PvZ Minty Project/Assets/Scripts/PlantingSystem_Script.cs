using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.InputSystem;

public class PlantingSystem_Script : MonoBehaviour
{
    public PreviewPlant_Script previewPlant;
    public Plant_ScriptableObject plantStats;

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
    public bool canBePlanted;

    void Update()
    {
        plantStats = previewPlant.currentPlant;
        if (plantStats != null)
        {
            selectMapObject.SetActive(true);
            
            PlantingMode(plantStats);

        }
        else if (plantStats == null)
        {
            selectMapObject.SetActive(false);
        }

    }

    public void PlantingMode(Plant_ScriptableObject plantStats)
    {

        mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        selectCoord = selectMap.WorldToCell(mousePos);
        plantCoord = plantLevel.WorldToCell(mousePos);
        gameObjectCoord = plantLevel.GetCellCenterWorld(plantCoord);

        //Checks if farm tile or already planted on
        if (plantLevel.GetTile(plantCoord) == null)
        {
            SelectorDisplay(greenSelector);
            canBePlanted = true;
        }
        else
        {
            SelectorDisplay(redSelector);
            canBePlanted = false;
        }
        return;
    }

    public void OnClick(InputAction.CallbackContext context)
    {
        if (canBePlanted)
        {
            plantLevel.SetTile(plantCoord, plantDetector);
            Instantiate(plantStats.plantObject, gameObjectCoord, Quaternion.identity);
            previewPlant.EmptyPlant();
            Debug.Log("Planted");
            canBePlanted = false;
        }
        else if (!canBePlanted)
        {
            Debug.Log("Cannoted Be Placed");
        }

    }

    public void SelectorDisplay(Tile selectorColor)
    {
        if (selectCoord != previousSelectCoord)
        {
            selectMap.SetTile(previousSelectCoord, null);
            selectMap.SetTile(selectCoord, selectorColor);
            previousSelectCoord = selectCoord;
        }
    }
}
