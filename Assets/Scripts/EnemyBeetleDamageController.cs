using UnityEngine;

public class EnemyBeetleDamageController : MonoBehaviour, IDamageable
{
    [SerializeField]
    [Min(1)]
    private int m_hitPoints = 1;

    public void TakeDamage(int damage)
    {
        m_hitPoints -= damage;

        if (m_hitPoints > 0) // still alive!
            return;

        gameObject.SetActive(false);

        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        //no check in collisions because enemy beetles only collide with bunny hammer
        if(collision.collider.enabled)
            TakeDamage(1);
    }
}