using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderUp : MonoBehaviour
{
    [SerializeField]
    Paintable peanutBread;
    [SerializeField]
    Paintable jellyBread;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 7 && !MultiMouse.instance.nextup)
        {
            MultiMouse.instance.orderup = true;
            if (peanutBread != null && jellyBread != null)
            {
                MultiMouse.instance.SaveCustomerStat();
                peanutBread.DestroyChildObjectsWithName("Brush(Clone)");
                jellyBread.DestroyChildObjectsWithName("Brush(Clone)");
            }
            Debug.Log(MultiMouse.instance.score);
        }
    }
}
