using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HellNahButton : MonoBehaviour
{
    [SerializeField] private AudioSource source;
    [SerializeField] private AudioClip clickSFX;
    private bool playing = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 7 && !MultiMouse.instance.nextup)
        {
            if (!playing) { StartCoroutine(playSFX()); }

            //Debug.Log(MultiMouse.instance.score);
        }
    }

    private IEnumerator playSFX()
    {
        playing = true;
        source.PlayOneShot(clickSFX);
        yield return new WaitForSeconds(1);
        playing = false;
    }
}
