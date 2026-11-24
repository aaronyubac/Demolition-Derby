using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Health))]
public class VehicleCollisionDamage : MonoBehaviour
{
    [SerializeField] float minImpactSpeed = 4f;     // speed change below this does nothing
    [SerializeField] float damageMultiplier = 3f;   // damage per m/s above the threshold
    [SerializeField] float hitCooldown = 0.1f;      // ignores duplicate contacts from one crash
    [SerializeField] bool logHits = true;

    Rigidbody rb;
    Health health;
    float lastHitTime = -999f;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        health = GetComponent<Health>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (Time.time - lastHitTime < hitCooldown) return;

        // How much this car's velocity changed in the hit.
        // Using the impulse means a heavy car hitting a light one
        // hurts the light one more, which is what you want in a derby.
        float speedChange = collision.impulse.magnitude / rb.mass;
        float damage = (speedChange - minImpactSpeed) * damageMultiplier;
        if (damage <= 0f) return;

        lastHitTime = Time.time;
        health.TakeDamage(damage);

        if (logHits)
            Debug.Log($"{name} took {damage:F1} damage (speed change {speedChange:F1} m/s). HP: {health.CurrentHealth:F0}");
    }
}