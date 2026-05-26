using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PreviewPlant_Script : MonoBehaviour, IPointerDownHandler
{
    public Plant_ScriptableObject currentPlant;
    public SpriteRenderer previewRenderer;

    private void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        transform.position = mousePos;
    }

    public void SetPlant(Plant_ScriptableObject plantStats)
    {
        currentPlant = plantStats;
        previewRenderer.sprite = currentPlant.plantSprite;
    }

    public void OnPointerDown(PointerEventData pointerEventData)
    {
        if (currentPlant != null)
        {
            Debug.Log("Successfully Placed");
            Instantiate(currentPlant.plantObject);
            currentPlant = null;
        }
        else if (currentPlant == null)
        {
            Debug.Log("Nothing To Place");
        }

    }
}
