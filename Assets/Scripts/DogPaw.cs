using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogPaw : MonoBehaviour
{
    [SerializeField]
    private float peanutPercent;
    [SerializeField]
    private float jamPercent;
    [SerializeField]
    private MeshRenderer mRenderer;
    [SerializeField]
    private Material pawMat;
    [SerializeField]
    private Material pawP25Mat;
    [SerializeField]
    private Material pawP50Mat;
    [SerializeField]
    private Material pawP75Mat;
    [SerializeField]
    private Material pawP100Mat;
    [SerializeField]
    private Material pawJ25Mat;
    [SerializeField]
    private Material pawJ50Mat;
    [SerializeField]
    private Material pawJ75Mat;
    [SerializeField]
    private Material pawJ100Mat;

    public float PeanutPercent { get { return peanutPercent; } set {  peanutPercent = value; } }
    public float JamPercent { get { return jamPercent; } set {  jamPercent = value; } }
    // Update is called once per frame
    void Update()
    {
        if (jamPercent > 75)
        {
            mRenderer.material = pawJ100Mat;
        }
        else if (jamPercent > 50)
        {
            mRenderer.material = pawJ75Mat;
        }
        else if (jamPercent > 25)
        {
            mRenderer.material = pawJ50Mat;
        }
        else if (jamPercent > 0)
        {
            mRenderer.material = pawJ25Mat;
        } 

        if (peanutPercent > 75)
        {
            mRenderer.material = pawP100Mat;
        }
        else if (peanutPercent > 50)
        {
            mRenderer.material = pawP75Mat;
        }
        else if (peanutPercent > 25)
        {
            mRenderer.material = pawP50Mat;
        }
        else if (peanutPercent > 0)
        {
            mRenderer.material = pawP25Mat;
        }

        if(jamPercent <= 0 && peanutPercent <= 0)
        {
            mRenderer.material = pawMat;
        }

    }
}
