using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    //Speed and moving variables set.
    //private float hMove = 0;
    //private float vMove = 0;
    [SerializeField]
    private float mSpeed;
    [SerializeField]
    private float jHeight;

    //Rigidbody and movement vector set.
    private Vector2 mVector;
    private Rigidbody rb;
    //New Input System
    //private PlayerInput playerInput;
    private PlayerInputActions playerInputActions;


    //Camera side set. It goes between 0 (for left) and 1 (for right)
    private float camSide;
    private CinemachineVirtualDynamic camController;

    private void Awake()
    {
        rb = transform.GetComponent<Rigidbody>();
        camController = transform.GetComponent<CinemachineVirtualDynamic>();
        //playerInput = GetComponent<PlayerInput>();

        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();
        playerInputActions.Player.Jump.performed += Jump;
        playerInputActions.Player.Movement.performed += Movement_performed;
    }

    private void Movement_performed(InputAction.CallbackContext context)
    {
        //Debug.Log(context);
        //mVector = context.ReadValue<Vector2>();
        //rb.velocity = new Vector3(mVector.x, rb.velocity.y, mVector.y) * Time.deltaTime * mSpeed;
        
    }

    void FixedUpdate()
    {
        //Move();
        Movement();
    }

    private void Update()
    {
        SetCamera();
    }

    private void Movement()
    {
        mVector = playerInputActions.Player.Movement.ReadValue<Vector2>();
        rb.velocity += new Vector3(mVector.x, 0, mVector.y) * Time.deltaTime * mSpeed;
    }

    private void SetCamera()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            camSide = camSide==1f ? 0f : 1f;
        }
        camController.SetCameraSide(camSide);
    }

    //void Move()
    //{
    //    hMove = Input.GetAxis("Horizontal");
    //    vMove = Input.GetAxis("Vertical");
    //    mVector.x = hMove;
    //    mVector.y = rb.velocity.y;
    //    mVector.z = vMove;

    //    rb.velocity = mVector.normalized * Time.deltaTime * mSpeed;
    //}

    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            //Debug.Log("Jump!");
            rb.AddForce(Vector3.up * jHeight, ForceMode.Impulse);
        }
    }
}
