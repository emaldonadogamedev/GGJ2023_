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

    bool m_isRotationNonZero;

    public void SetNewTarget(GameObject newTarget)
    {
        m_target = newTarget.transform;
    }

    void Update()
    {
        if(m_target == null)
            return;

        m_direction = m_target.position - transform.position;
        m_direction.Normalize();

        m_speedTimesDeltaTime = m_speed * Time.deltaTime;

        transform.position += m_direction * m_speedTimesDeltaTime;

        m_isRotationNonZero = !Mathf.Approximately(m_direction.sqrMagnitude, 0f);

        if(m_isRotationNonZero)
            transform.forward = m_direction;
    }
}