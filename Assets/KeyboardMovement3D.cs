using UnityEngine;

public class KeyboardMovement3D : MonoBehaviour
{
    [SerializeField]
    [Range(2f, 20f)]
    private float speed = 10.0f;

    private Vector3 m_moveDirection = new(0f,0f,0f);

    private bool m_isRotationNonZero;

    void Update()
    {
        m_moveDirection.x = Input.GetAxis("Horizontal");
        m_moveDirection.z = Input.GetAxis("Vertical");

        transform.position =
            transform.position + m_moveDirection * (speed * Time.deltaTime);

        m_isRotationNonZero =
            m_moveDirection.x != 0f || m_moveDirection.z != 0f;

        if (m_isRotationNonZero)
        {
            transform.forward = m_moveDirection;
        }
    }
}