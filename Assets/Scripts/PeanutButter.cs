using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeanutButter : Ingredient
{ 
    [SerializeField] private AudioSource source;
    [SerializeField] private AudioClip clickSFX;
    private bool playing = false;

    public override void OnClick(bool isRight)
    {
        if(isRight)
        {
            MultiMouse.DogPawFollow.RightPaw.PeanutPercent = 100;
            if (!playing) { StartCoroutine(playSFX()); }
        } /*else
        {
            MultiMouse.DogPawFollow.LeftPaw.PeanutPercent = 100;
        }*/
        
    }

    private IEnumerator playSFX()
    {
        playing = true;
        source.PlayOneShot(clickSFX);
        yield return new WaitForSeconds(1f);
        playing = false;
    }
}
