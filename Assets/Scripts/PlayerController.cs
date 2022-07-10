using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float hMove = 0;
    private float vMove = 0;
    [SerializeField]
    private float mSpeed;
    private Vector3 mVector;
    private Rigidbody rb;

    void Start()
    {
        rb = transform.GetComponent<Rigidbody>();
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        hMove = Input.GetAxis("Horizontal");
        vMove = Input.GetAxis("Vertical");
        mVector.x = hMove;
        mVector.y = rb.velocity.y;
        mVector.z = vMove;

        rb.velocity = mVector.normalized * Time.deltaTime * mSpeed;
    }
}
