using UnityEngine;

public class PunteroController : MonoBehaviour
{
    public Texture2D[] CursorTexture;
    CursorMode cursorMode = CursorMode.Auto;
    Vector2 hotSpot = Vector2.zero;

    // Update is called once per frame
    public void OnLayerChange(string layerName)
    {
        print("layer: " + layerName);
        
        switch (layerName)
        {
            case "caminable":
                Cursor.SetCursor(CursorTexture[0], hotSpot, cursorMode);
                break;
            case "seleccionable":
                Cursor.SetCursor(CursorTexture[1], hotSpot, cursorMode);
                break;
            case "endstop":
                Cursor.SetCursor(CursorTexture[2], hotSpot, cursorMode);
                break;
            case "noCaminable":
                Cursor.SetCursor(CursorTexture[3], hotSpot, cursorMode);
                break;
            case "personaje":
                Cursor.SetCursor(CursorTexture[4], hotSpot, cursorMode);
                break;
            case "enemigo":
                Cursor.SetCursor(CursorTexture[5], hotSpot, cursorMode);
                break;
        }
    }
    
}