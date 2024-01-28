using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : Ingredient
{
    public override void OnClick(bool isRight)
    {
        if (isRight)
        {
            MultiMouse.DogPawFollow.RightPaw.JamPercent = 0;
            MultiMouse.DogPawFollow.RightPaw.PeanutPercent = 0;
        }
        else
        {
            MultiMouse.DogPawFollow.LeftPaw.JamPercent = 0;
            MultiMouse.DogPawFollow.LeftPaw.PeanutPercent = 0;
        }
    }
}
