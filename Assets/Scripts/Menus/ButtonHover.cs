using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This is used to display a paw for the cursor when the player hovers a button WOW
/// </summary>


public class ButtonHover : MonoBehaviour
{
    [SerializeField]
    private Texture2D paw;
    private CursorMode cursorMode = CursorMode.Auto;
    private Vector2 hotSpot = Vector2.zero;

    //Set mouse as the dogpaw
    private void OnMouseEnter()
    {
        Cursor.SetCursor(paw, hotSpot, cursorMode);
    }

    private void OnMouseExit()
    {
        Cursor.SetCursor(null, Vector2.zero, cursorMode);
    }
}
