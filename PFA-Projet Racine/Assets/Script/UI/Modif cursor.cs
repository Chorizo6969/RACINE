using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using static UnityEngine.CursorMode;

public class Modifcursor : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField]
    private Texture2D _curseurWood;

    [SerializeField]
    private Texture2D _curseurWater;

    [SerializeField]
    private Texture2D _curseurStone;

    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (eventData.pointerEnter.gameObject.layer == 12)
        {
            Cursor.SetCursor(_curseurWood, hotSpot, cursorMode);
        }
        else if(eventData.pointerEnter.gameObject.layer == 13)
        {
            Cursor.SetCursor(_curseurWater, hotSpot, cursorMode);
        }
        else
        {
            Cursor.SetCursor(_curseurStone, hotSpot, cursorMode);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Cursor.SetCursor(null, hotSpot, cursorMode);
    }

    public void ChangeCursor(Texture2D texture)
    {
        Cursor.SetCursor(texture, hotSpot, cursorMode);
    }
}
