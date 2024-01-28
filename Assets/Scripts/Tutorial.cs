using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(kill());
    }

    private IEnumerator kill()
    {
        yield return new WaitForSeconds(5f);
        gameObject.SetActive(false);
    }
}
