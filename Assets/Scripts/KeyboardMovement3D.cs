using UnityEngine;
using UnityEngine.EventSystems;

public class KeyboardMovement3D : MonoBehaviour
{
    [SerializeField]
    [Range(1f, 20f)]
    private float m_speed = 10.0f;

    [SerializeField]
    private Rigidbody m_rigidbody;

    private Vector3 m_moveDirection = new(0f, 0f, 0f);
    private float m_speedTimesDeltaTime = 0f;

    private bool m_isRotationNonZero = false;

    void Update()
    {
        m_moveDirection.x = Input.GetAxis("Horizontal");
        m_moveDirection.z = Input.GetAxis("Vertical");

        m_moveDirection.Normalize();

        m_speedTimesDeltaTime = m_speed * Time.deltaTime;

        //m_rigidbody.velocity = m_moveDirection * m_speed;

        transform.position += m_moveDirection * m_speedTimesDeltaTime;

        m_isRotationNonZero =
            m_moveDirection.x != 0f || m_moveDirection.z != 0f;

        if (m_isRotationNonZero)
        {
            transform.forward = m_moveDirection;
        }
    }

}