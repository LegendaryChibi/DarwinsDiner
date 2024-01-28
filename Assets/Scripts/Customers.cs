using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Customers : MonoBehaviour
{
    [SerializeField]
    private float speed = 10f;

    private Vector3 target;
    private bool isMoving = false;
    private int customersServed = 0;


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
            Debug.Log("Game Complete! Final Score: " + Mathf.RoundToInt(MultiMouse.instance.score / transform.childCount * 200));
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
        }
    }
}
