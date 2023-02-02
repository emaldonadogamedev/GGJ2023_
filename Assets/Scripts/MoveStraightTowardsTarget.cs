using UnityEngine;
using UnityEngine.EventSystems;

public class MoveStraightTowardsTarget : MonoBehaviour
{
    [SerializeField]
    private Transform m_target;

    [SerializeField]
    [Min(0f)]
    private float m_speed = 2f;

    private Vector3 m_direction = new();

    private float m_speedTimesDeltaTime;

    void Update()
    {
        if(m_target == null)
            return;

        m_direction = m_target.position - transform.position;
        m_direction.Normalize();

        m_speedTimesDeltaTime = m_speed * Time.deltaTime;

        transform.position += m_direction * m_speedTimesDeltaTime;

        transform.forward = m_direction;
    }
}