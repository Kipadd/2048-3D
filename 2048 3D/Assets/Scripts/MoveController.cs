using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour
{
    private const float MoveSpeed = 1.0f;
    private const float MinXPosition = -1.04f;
    private const float MaxXPosition = 1.04f;
    private const float PushForce = 12f;

    private bool isDragging = false;
    private Vector3 lastMousePosition;
    private Rigidbody _rb;

    public GameObject arrow;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        HandleMouseInput();
        ClampPlayerPosition();
        CheckForArrowDestruction();
    }

    private void HandleMouseInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isDragging = true;
            lastMousePosition = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
            _rb.AddForce(transform.forward * -1 * PushForce, ForceMode.Impulse);

            enabled = false;
            Destroy(arrow);
        }

        if (isDragging)
        {
            float deltaX = (Input.mousePosition.x - lastMousePosition.x) * Time.deltaTime * MoveSpeed;
            lastMousePosition = Input.mousePosition;
            transform.position += new Vector3(deltaX, 0f, 0f);
        }
    }

    private void ClampPlayerPosition()
    {
        float clampedX = Mathf.Clamp(transform.position.x, MinXPosition, MaxXPosition);
        transform.position = new Vector3(clampedX, transform.position.y, transform.position.z);
    }

    private void CheckForArrowDestruction()
    {
        if (transform.position.y >= 0.5f)
        {
            Destroy(arrow);
        }
    }
}
