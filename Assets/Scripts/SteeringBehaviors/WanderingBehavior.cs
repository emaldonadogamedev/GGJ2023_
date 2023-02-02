using UnityEngine;

public class WanderingBehavior : MonoBehaviour
{
    public float maxSpeed = 10f;
    public float wanderRadius = 1f;
    public float wanderJitter = 0.1f;

    private Rigidbody rigidbody;
    private Vector3 velocity;
    private Vector3 wanderTarget;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        velocity = transform.forward * maxSpeed;
        wanderTarget = transform.position + transform.forward * wanderRadius;
    }

    void FixedUpdate()
    {
        velocity = Wander(velocity);
        rigidbody.velocity = velocity;
    }

    Vector3 Wander(Vector3 velocity)
    {
        wanderTarget += new Vector3(Random.Range(-1f, 1f) * wanderJitter, 0, Random.Range(-1f, 1f) * wanderJitter);
        wanderTarget = wanderTarget.normalized * wanderRadius + transform.position;
        Vector3 desiredVelocity = (wanderTarget - transform.position).normalized * maxSpeed;
        velocity = desiredVelocity;
        return velocity;
    }
}