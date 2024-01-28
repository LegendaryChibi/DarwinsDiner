using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;

public class MultiMouse : MonoBehaviour
{
    [SerializeField]
    private Vector2 rightMouse;
    [SerializeField]
    private Vector2 leftMouse;
    [SerializeField]
    private bool isRight;
    [SerializeField]
    private bool isLeft;
    [SerializeField]
    private Camera camera;
    [SerializeField]
    private DogPawFollow dogPawFollow;
    public int peanutButterPercent = 0;
    public int jellyPercent = 0;

    public static DogPawFollow DogPawFollow { get { return instance.dogPawFollow; } }

    public Camera Camera { get { return camera; } }
    public static Vector2 RightMouse { get { return instance.rightMouse; } }
    public static Vector2 LeftMouse {  get { return instance.leftMouse; } }
    public static bool IsRMBPress { get { return instance.isRight; } }
    public static bool IsLMBPress { get { return instance.isLeft; } }

    public static MultiMouse instance;
    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
    }

 

    public void onMouse1(InputAction.CallbackContext context)
    {
        if(isRight)
        {
            rightMouse = context.ReadValue<Vector2>();
        }
        if(isLeft)
        {
            leftMouse = context.ReadValue<Vector2>();
        }
    }
    public void leftMouseButton(InputAction.CallbackContext context)
    {
        isLeft = context.ReadValueAsButton();
        
    }
    public void rightMouseButton(InputAction.CallbackContext context)
    {
        isRight = context.ReadValueAsButton();
        
    }

    public void PeanutButterPercent(int x) 
    {
        peanutButterPercent = x;
    }

    public void JellyPercent(int x)
    {
        jellyPercent = x;
    }
}
