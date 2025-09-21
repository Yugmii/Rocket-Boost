using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    [SerializeField] InputAction thrust;
    [SerializeField] float thrustStrength = 100f;
    [SerializeField] InputAction rotation;
    [SerializeField] float rotationStrength = 100f;

    
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnEnable()
    {
        thrust.Enable();
        rotation.Enable();

    }

    void FixedUpdate()
    {
        processThrust();
        processRotation();
    }


    private void processThrust()
    {
        if (thrust.IsPressed())
        {
            rb.AddRelativeForce(Vector3.up * thrustStrength * Time.fixedDeltaTime);
        }
    }
    private void processRotation()
    {
        float rotationValue = rotation.ReadValue<float>();

        if (rotationValue < 0)
        {
            // transform.Rotate(0f, 0f, 1f);  Or we can write as: 
            ApplyRotation(rotationStrength);
        }
        else if (rotationValue > 0)
        {
            // transform.Rotate(0f, 0f, 1f);  Or we can write as: 
            // transform.Rotate(Vector3.back);  Or
            ApplyRotation(-rotationStrength);
        }
    }

    private void ApplyRotation(float RotationThisFrame)
    {
        transform.Rotate(Vector3.forward * RotationThisFrame * Time.fixedDeltaTime);
    }
}
