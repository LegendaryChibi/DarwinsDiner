using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jam : Ingredient
{
    public override void OnClick(bool isRight)
    {
        if (isRight)
        {
            /*MultiMouse.DogPawFollow.RightPaw.JamPercent = 100;*/
        }
        else
        {
            MultiMouse.DogPawFollow.LeftPaw.JamPercent = 100;
        }

    }
}
