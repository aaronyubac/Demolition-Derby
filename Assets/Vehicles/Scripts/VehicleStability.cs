using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class VehicleStability : MonoBehaviour
{
    [Header("Upright Torque")]
    [SerializeField] float uprightStrength = 20f;    // how hard it pushes back upright
    [SerializeField] float tiltDamping = 3f;         // stops it wobbling back and forth
    [SerializeField] float airborneMultiplier = 0.3f; // weaker correction while in the air

    [Header("Wheels (for ground check)")]
    [SerializeField] WheelCollider[] wheels;

    Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // Direction the car's roof is pointing vs. straight up
        Vector3 axis = Vector3.Cross(transform.up, Vector3.up);
        float strength = uprightStrength * (IsGrounded() ? 1f : airborneMultiplier);

        // Torque proportional to how tilted the car is
        rb.AddTorque(axis * strength, ForceMode.Acceleration);

        // Damp roll/pitch only, so steering (yaw) is untouched
        Vector3 angVel = rb.angularVelocity;
        Vector3 tiltVel = angVel - Vector3.Project(angVel, transform.up);
        rb.AddTorque(-tiltVel * tiltDamping, ForceMode.Acceleration);
    }

    bool IsGrounded()
    {
        foreach (var w in wheels)
            if (w.isGrounded) return true;
        return false;
    }
}