using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jam : Ingredient
{
    public override void OnClick(bool isRight)
    {
        Debug.Log("JAM!");
    }
}
