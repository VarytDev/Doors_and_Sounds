using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboarMovement : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 3;
    [SerializeField] private int jumpForce = 4;
    private Rigidbody rb;
    private bool grounded;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Vector3 verticalInput = Vector3.forward * Input.GetAxis("Vertical") * movementSpeed;
        Vector3 horizontalInput = Vector3.right * Input.GetAxis("Horizontal") * movementSpeed;

        transform.Translate(verticalInput * Time.deltaTime, Space.Self);
        transform.Translate(horizontalInput * Time.deltaTime, Space.Self);

        if(Input.GetButtonDown("Jump") && grounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        grounded = true;
    }

    void OnCollisionExit(Collision collision)
    {
        grounded = false;
    }
}
