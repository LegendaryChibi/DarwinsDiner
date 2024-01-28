using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeanutButter : Ingredient
{
    public override void OnClick(bool isRight)
    {
        if(isRight)
        {
            MultiMouse.DogPawFollow.RightPaw.PeanutPercent = 100;
        } else
        {
            MultiMouse.DogPawFollow.LeftPaw.PeanutPercent = 100;
        }
        
    }
}
