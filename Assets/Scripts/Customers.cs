using System.Collections;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Customers : MonoBehaviour
{
    [SerializeField]
    private float speed = 10f;

    private Vector3 target;
    private bool isMoving = false;
    private int customersServed = 0;
    [SerializeField]
    private Animator[] animators;

    private void Start()
    {
        if (customersServed == 0)
        {
            StartCoroutine(Talking());
        }
    }

    void FixedUpdate()
    {
        if (MultiMouse.instance.orderup && !MultiMouse.instance.nextup && customersServed < transform.childCount)
        {
            MultiMouse.instance.orderup = false;
            MultiMouse.instance.nextup = true;
            customersServed++;
            isMoving = true;
            target = new Vector3(transform.position.x - 20, transform.position.y, transform.position.z);
        }
        else if (customersServed == transform.childCount)
        {
            int totalscore = Mathf.RoundToInt(MultiMouse.instance.score / ((float)transform.childCount * 200) * 100);
            Debug.Log("Game Complete! Final Score: " + totalscore + "%");
        }

        if (isMoving)
        {
            MoveTowardsTarget();
        }
    }

    private void MoveTowardsTarget()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target, step);

        if (Vector3.Distance(transform.position, target) < 0.001f)
        {
            isMoving = false;
            MultiMouse.instance.nextup = false;
            StartCoroutine(Talking());
        }
    }

    IEnumerator Talking()
    {
        if (customersServed > 0 && customersServed < transform.childCount)
        {
            animators[customersServed - 1].SetBool("Talking", false);
        }

        if (customersServed < transform.childCount - 1)
        {
            animators[customersServed].SetBool("Talking", true);
            yield return new WaitForSeconds(3);
            animators[customersServed].SetBool("Talking", false);
        }
        else
        {
            yield return null;
        }
    }
}
