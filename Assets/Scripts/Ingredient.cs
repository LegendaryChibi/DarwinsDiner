using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ingredient : MonoBehaviour
{
    private static List<Ingredient> Ingredients = new List<Ingredient>();
    [SerializeField]
    private Collider collider;
    private void OnEnable()
    {
        Ingredients.Add(this);
        
    }

    private void OnDisable()
    {
        Ingredients.Remove(this);
    }
    //Run the code for all ingredient objects when the player is clicking the mouse.
    public static void UpdateAllIngredients(Vector3 pos, bool isRight)
    {
        foreach (Ingredient item in Ingredients)
        { 
            if (item.collider.bounds.Contains(pos)) {
                item.OnClick(isRight);
            }
        }
    }

    public abstract void OnClick(bool isRight);
}
