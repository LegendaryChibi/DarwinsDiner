using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jam : Ingredient
{
    [SerializeField] private AudioSource source;
    [SerializeField] private AudioClip clickSFX;
    private bool playing = false;

    public override void OnClick(bool isRight)
    {
        if (isRight)
        {
            /*MultiMouse.DogPawFollow.RightPaw.JamPercent = 100;*/
        }
        else
        {
            MultiMouse.DogPawFollow.LeftPaw.JamPercent = 100;
            if (!playing) { StartCoroutine(playSFX()); }
        }

    }

    private IEnumerator playSFX()
    {
        playing = true;
        source.PlayOneShot(clickSFX);
        yield return new WaitForSeconds(1f);
        playing = false;
    }
}
