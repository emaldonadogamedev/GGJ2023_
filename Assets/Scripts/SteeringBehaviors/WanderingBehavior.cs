using UnityEngine;

public class WanderingBehavior : MonoBehaviour
{
    public float m_maxSpeed = 10f;
    public float wanderRadius = 1f;
    public float wanderJitter = 0.1f;

    private Rigidbody m_rigidbody;
    private Vector3 velocity;
    private Vector3 wanderTarget;

    void Start()
    {
        m_rigidbody = GetComponent<Rigidbody>();
        velocity = transform.forward * m_maxSpeed;
        wanderTarget = transform.position + transform.forward * wanderRadius;
    }

    void FixedUpdate()
    {
        velocity = Wander(velocity);
        m_rigidbody.velocity = velocity;
    }

    Vector3 Wander(Vector3 velocity)
    {
        wanderTarget += new Vector3(Random.Range(-1f, 1f) * wanderJitter, 0, Random.Range(-1f, 1f) * wanderJitter);
        wanderTarget = wanderTarget.normalized * wanderRadius + transform.position;
        Vector3 desiredVelocity = (wanderTarget - transform.position).normalized * m_maxSpeed;
        velocity = desiredVelocity;
        return velocity;
    }
}