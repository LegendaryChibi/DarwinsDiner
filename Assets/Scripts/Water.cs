using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : Ingredient
{
    [SerializeField] private AudioSource source;
    [SerializeField] private AudioClip clickSFX;
    private bool playing = false;

    public override void OnClick(bool isRight)
    {
        if (isRight)
        {
            MultiMouse.DogPawFollow.RightPaw.JamPercent = 0;
            MultiMouse.DogPawFollow.RightPaw.PeanutPercent = 0;
            if(!playing) { StartCoroutine(playSFX()); }
        }
        else
        {
            MultiMouse.DogPawFollow.LeftPaw.JamPercent = 0;
            MultiMouse.DogPawFollow.LeftPaw.PeanutPercent = 0;
            if (!playing) { StartCoroutine(playSFX()); }
        }
    }

    private IEnumerator playSFX()
    {
        playing = true;
        source.PlayOneShot(clickSFX);
        yield return new WaitForSeconds(2);
        playing = false;
    }
}
