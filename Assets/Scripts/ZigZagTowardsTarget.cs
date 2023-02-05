using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class ZigZagTowardsTarget : MonoBehaviour
{
    [SerializeField]
    private Transform m_target;

    private Stack<Vector3> m_positionsToChase = new();

    [SerializeField]
    [Min(0f)]
    private float m_speed = 2f;

    private Vector3 m_direction = new();
    private Vector3 m_position;

    private float m_speedTimesDeltaTime;

    bool m_isRotationNonZero;

    public void SetNewTarget(GameObject newTarget)
    {
        m_target = newTarget.transform;
    }

    private void Start()
    {
        m_position = GetSpecialRandomTargetPos();
        m_positionsToChase.Push(m_target.position);
        m_positionsToChase.Push(GetSpecialRandomTargetPos());
        m_positionsToChase.Push(GetSpecialRandomTargetPos());
    }

    void Update()
    {
        if(m_target == null)
            return;

         if((m_position - transform.position).magnitude < 0.5f)
        {
            UpdateTargetPosition();
        }

        m_direction = m_position - transform.position;
        m_direction.Normalize();

        m_speedTimesDeltaTime = m_speed * Time.deltaTime;

        transform.position += m_direction * m_speedTimesDeltaTime;

        m_isRotationNonZero = !Mathf.Approximately(
            (m_position - transform.position).sqrMagnitude,
            0f);

        if(m_isRotationNonZero)
            transform.forward = m_direction;
    }

    private Vector3 GetSpecialRandomTargetPos()
    {
        return new Vector3(
            Random.Range(-7f, 7f),
            .5f,
            Random.Range(1f, 5f));
    }

    private void UpdateTargetPosition()
    {
        if (m_positionsToChase.Count <= 0)
            return;

        m_position = m_positionsToChase.Pop();
    }
}