using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class score : MonoBehaviour
{
    int mrow = 0;
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private AudioSource source;
    [SerializeField] private AudioClip clickSFX;
    [SerializeField] private AudioClip badSFX;
    private bool playing = false;

    private void Update()
    {
        mrow = Mathf.RoundToInt((MultiMouse.instance.score / 2000f) * 100);
        text.text = mrow.ToString() + "%";
        if (!playing) { StartCoroutine(playSFX()); }
    }

    private IEnumerator playSFX()
    {
        playing = true;
        Debug.Log(mrow.ToString());
        if (mrow >= 50) { source.PlayOneShot(clickSFX); }
        else { source.PlayOneShot(badSFX); }
        yield return new WaitForSeconds(5.0f);
        playing = false;
    }
}
