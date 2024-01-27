using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioShifter : MonoBehaviour
{
    [SerializeField]
    AudioSource source;
    [SerializeField]
    List<AudioClip> clipList;
    [SerializeField]
    private float SecondsPerDoot;
    private float waitTime = 0;

    private void Update()
    {
        float notesToPlay = 0;
        waitTime += Time.deltaTime;

        if(waitTime > SecondsPerDoot)
        {
            waitTime = 0;
            int rand = Random.Range(0, clipList.Count);
            source.clip = clipList[rand];
            //source.pitch = Random.Range(0.0f, 2.0f);

            source.Play();
        }
    }
}
