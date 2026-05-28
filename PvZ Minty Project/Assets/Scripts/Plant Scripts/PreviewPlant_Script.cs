using UnityEngine;
using UnityEngine.InputSystem;

public class PreviewPlant_Script : MonoBehaviour
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

    public void EmptyPlant()
    {
        currentPlant = null;
        previewRenderer.sprite = null;
    }
}
