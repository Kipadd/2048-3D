using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float speed = 0.12f; 
    private float minX = -1.04f; 
    private float maxX = 1.04f;

    private bool isDragging = false;
    private Vector3 lastMousePosition;

    public Vector3 globalDirection = Vector3.forward;
    private float pushForce = 12f;
    private Rigidbody rb;

    public GameObject arrow;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isDragging = true;
            lastMousePosition = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            Debug.Log("zapusk");
            isDragging = false;
            //Vector3 localDirection = transform.InverseTransformDirection(globalDirection.normalized);

            rb.AddForce(transform.forward * -1 * pushForce, ForceMode.Impulse);
            //Debug.Log(localDirection);

            enabled = false;
            Object.Destroy(arrow);
            
        }

        if (isDragging)
        {
            float deltaX = (Input.mousePosition.x - lastMousePosition.x) * Time.deltaTime * speed;

            lastMousePosition = Input.mousePosition;

            transform.position += new Vector3(deltaX, 0f, 0f);

            float clampedX = Mathf.Clamp(transform.position.x, minX, maxX);
            transform.position = new Vector3(clampedX, transform.position.y, transform.position.z);
        }
        if (transform.position.y >= 0.5f)
        {
            Object.Destroy(arrow);
        }
    }
}
