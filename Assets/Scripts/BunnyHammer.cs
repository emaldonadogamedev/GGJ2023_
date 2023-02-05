using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(KeyboardMovement3D))]
public class BunnyHammer : MonoBehaviour
{
    [SerializeField]
    [Range(0.1f, 4f)]
    private float m_attackCooldownTimeSeconds = 0.1f;

    private float m_currentCooldownTime = 0f;

    private bool m_canAttack = true;

    [SerializeField]
    private Collider m_hammerHitCollider;

    [SerializeField]
    private ParticleSystem m_hammerHitVFX;

    private KeyboardMovement3D m_keyboardMovement3D;

    private void Start()
    {
        m_keyboardMovement3D = GetComponent<KeyboardMovement3D>();
    }

    void Update()
    {
        if (m_canAttack && UserWantsToAttack())
        {
            ExecuteBunnyAttack();
        }

        else if (!m_canAttack)
        {
            m_currentCooldownTime -= Time.deltaTime;

            if(m_currentCooldownTime <= 0f)
            {
                PrepareForNextAttack();
            }
        }
    }

    private bool UserWantsToAttack()
    {
        return Input.GetMouseButtonDown((int)MouseButton.Left) ||
            Input.GetKeyDown(KeyCode.Space);
    }

    private void ExecuteBunnyAttack()
    {
        Debug.Log("Hammer Down!");

        m_hammerHitCollider.enabled = true;

        m_hammerHitVFX.Play();

        m_canAttack = false;

        m_currentCooldownTime = m_attackCooldownTimeSeconds;

        m_keyboardMovement3D.enabled = false;
    }

    private void PrepareForNextAttack()
    {
        Debug.Log("Can Attack again!");

        m_hammerHitCollider.enabled = false;

        m_canAttack = true;

        m_keyboardMovement3D.enabled = true;
    }
}