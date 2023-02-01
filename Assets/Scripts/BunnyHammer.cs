using Unity.VisualScripting;
using UnityEngine;

public class BunnyHammer : MonoBehaviour
{
    [Range(.1f, 4f)]
    [SerializeField]
    private float m_attackCooldownTimeSeconds = 1f;

    private float m_currentCooldownTime = 0f;

    private bool m_canAttack = true;

    void Update()
    {
        if (m_canAttack && UserWantsToAttack())
        {
            Debug.Log("Hammer Down");

            m_canAttack = false;

            m_currentCooldownTime = 0f;
        }

        else if (!m_canAttack)
        {
            m_currentCooldownTime += Time.deltaTime;

            if(m_currentCooldownTime > m_attackCooldownTimeSeconds)
            {
                m_canAttack = true;
            }
        }
    }

    private bool UserWantsToAttack()
    {
        return Input.GetMouseButtonDown((int)MouseButton.Left) ||
            Input.GetKeyDown(KeyCode.Space);
    }
}
