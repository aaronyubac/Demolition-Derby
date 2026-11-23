using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class VehicleController : MonoBehaviour
{
    [Header("Wheel Colliders")]
    [SerializeField] WheelCollider frontLeft;
    [SerializeField] WheelCollider frontRight;
    [SerializeField] WheelCollider rearLeft;
    [SerializeField] WheelCollider rearRight;

    [Header("Wheel Meshes")]
    [SerializeField] Transform frontLeftMesh;
    [SerializeField] Transform frontRightMesh;
    [SerializeField] Transform rearLeftMesh;
    [SerializeField] Transform rearRightMesh;

    [Header("Tuning")]
    [SerializeField] float motorTorque = 1800f;
    [SerializeField] float brakeTorque = 4000f;
    [SerializeField] float maxSteerAngle = 30f;
    [SerializeField] float maxSpeed = 25f; // m/s
    [SerializeField] Vector3 centerOfMassOffset = new Vector3(0f, -0.6f, 0f);

    Rigidbody rb;
    InputAction moveAction;
    InputAction brakeAction;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.centerOfMass += centerOfMassOffset; // low center of mass = fewer rollovers

        moveAction = new InputAction("Move", InputActionType.Value);
        moveAction.AddCompositeBinding("2DVector")
            .With("Up", "<Keyboard>/w")
            .With("Down", "<Keyboard>/s")
            .With("Left", "<Keyboard>/a")
            .With("Right", "<Keyboard>/d");
        moveAction.AddBinding("<Gamepad>/leftStick");

        brakeAction = new InputAction("Brake", InputActionType.Button, "<Keyboard>/space");
        brakeAction.AddBinding("<Gamepad>/buttonSouth");
    }

    void OnEnable()
    {
        moveAction.Enable();
        brakeAction.Enable();
    }

    void OnDisable()
    {
        moveAction.Disable();
        brakeAction.Disable();
    }

    void FixedUpdate()
    {
        Vector2 move = moveAction.ReadValue<Vector2>();
        float throttle = move.y;
        float steer = move.x;
        bool braking = brakeAction.IsPressed();

        // Rear-wheel drive, with a speed cap
        float torque = rb.linearVelocity.magnitude < maxSpeed ? throttle * motorTorque : 0f;
        rearLeft.motorTorque = torque;
        rearRight.motorTorque = torque;

        // Front-wheel steering
        float angle = steer * maxSteerAngle;
        frontLeft.steerAngle = angle;
        frontRight.steerAngle = angle;

        // Brakes
        float brake = braking ? brakeTorque : 0f;
        frontLeft.brakeTorque = brake;
        frontRight.brakeTorque = brake;
        rearLeft.brakeTorque = brake;
        rearRight.brakeTorque = brake;
    }

    void Update()
    {
        SyncWheel(frontLeft, frontLeftMesh);
        SyncWheel(frontRight, frontRightMesh);
        SyncWheel(rearLeft, rearLeftMesh);
        SyncWheel(rearRight, rearRightMesh);
    }

    static void SyncWheel(WheelCollider col, Transform mesh)
    {
        if (mesh == null) return;
        col.GetWorldPose(out Vector3 pos, out Quaternion rot);
        mesh.SetPositionAndRotation(pos, rot);
    }
}