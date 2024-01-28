using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogPawFollow : MonoBehaviour
{
    private Camera camera;
    [SerializeField]
    private Rigidbody leftArm;
    [SerializeField] 
    private Rigidbody rightArm;
    [SerializeField]
    private DogPaw leftPaw;
    [SerializeField]
    private DogPaw rightPaw;

    private LayerMask groundMask;

    private RaycastHit leftHit, rightHit;
    private bool leftHasHit = false, rightHasHit = false;

    private Quaternion rightArmRotation = Quaternion.identity;
    private Quaternion leftArmRotation = Quaternion.identity;
    

    public RaycastHit LeftPawRayhit { get { return leftHit; } }
    public RaycastHit RightPawRayhit { get { return rightHit; } }
    public DogPaw LeftPaw { get {  return leftPaw; } }
    public DogPaw RightPaw { get { return rightPaw; } }
    private void Start()
    {
        camera = MultiMouse.instance.Camera;
        groundMask = LayerMask.GetMask("Ground");
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        
        Ray leftRay = camera.ScreenPointToRay(MultiMouse.LeftMouse);
        
        Ray rightRay = camera.ScreenPointToRay(MultiMouse.RightMouse);

        
        

        leftHasHit = Physics.Raycast(camera.transform.position, leftRay.direction, out leftHit, 100f, groundMask);
        rightHasHit = Physics.Raycast(camera.transform.position, rightRay.direction, out rightHit, 100f, groundMask);
        if(MultiMouse.IsLMBPress)
        {
            if (leftHasHit)
            {
                leftArmRotation = Quaternion.LookRotation(leftHit.point - leftArm.transform.position);
                Ingredient.UpdateAllIngredients(leftHit.point, false);
            }
            else
            {
                leftArmRotation = Quaternion.LookRotation(leftRay.direction);
                
            }
        }

        if(MultiMouse.IsRMBPress)
        {
            if (rightHasHit)
            {
                rightArmRotation = Quaternion.LookRotation(rightHit.point - rightArm.transform.position);
                
                Ingredient.UpdateAllIngredients(rightHit.point, true);
            }
            else
            {
                rightArmRotation = Quaternion.LookRotation(rightRay.direction);
            }
        }

        leftArm.MoveRotation(Quaternion.Slerp(leftArm.rotation, leftArmRotation, Time.deltaTime * 5f));
        rightArm.MoveRotation(Quaternion.Slerp(rightArm.rotation, rightArmRotation, Time.deltaTime * 5f));
        //rightArm.transform.rotation = rightArmRotation;
        //Quaternion.Slerp(leftArm.transform.rotation, leftArmRotation, 0.7f);
        //Quaternion.Slerp(rightArm.transform.rotation, rightArmRotation, 0.7f);
        
    }

    private void OnDrawGizmos()
    {
        if(leftHasHit)
            Gizmos.DrawSphere(leftHit.point, 1f);
        if(rightHasHit)
            Gizmos.DrawSphere(rightHit.point, 1f);
    }
}
