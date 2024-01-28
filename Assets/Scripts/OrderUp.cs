using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderUp : MonoBehaviour
{
    [SerializeField]
    GameObject sandwhich;
    [SerializeField]
    Paintable peanutBread;
    [SerializeField]
    Paintable jellyBread;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 7 && !MultiMouse.instance.nextup)
        {
            StartCoroutine(Fling());

            if (peanutBread != null && jellyBread != null)
            {
                MultiMouse.instance.SaveCustomerStat();
                peanutBread.DestroyChildObjectsWithName("Brush(Clone)");
                jellyBread.DestroyChildObjectsWithName("Brush(Clone)");
            }
            //Debug.Log(MultiMouse.instance.score);
        }
    }

    IEnumerator Fling()
    {
        peanutBread.gameObject.SetActive(false);
        jellyBread.gameObject.SetActive(false);
        sandwhich.SetActive(true);
        yield return new WaitForSeconds(2);
        peanutBread.gameObject.SetActive(true);
        jellyBread.gameObject.SetActive(true);
        sandwhich.SetActive(false);
        MultiMouse.instance.orderup = true;
        yield return new WaitForSeconds(0.5f);
        MultiMouse.instance.orderup = false;
    }
}
