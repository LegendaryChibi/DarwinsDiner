using UnityEngine;

public class Customers : MonoBehaviour
{
    [SerializeField]
    private float speed = 10f;

    private Vector3 target;
    private bool isMoving = false;
    private int customersServed = 0;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && customersServed < transform.childCount)
        {
            customersServed++;
            isMoving = true;
            target = new Vector3(transform.position.x, transform.position.y, transform.position.z + 5);
        }
        else if (customersServed == transform.childCount)
        {
            Debug.Log("Game Complete!");
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
        }
    }
}
