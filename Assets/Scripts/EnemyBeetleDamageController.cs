using System;
using UnityEngine;

[Serializable]
public enum BEETLE_ENEMY_TYPE
{
    GREEN,
    RED,
    BLUE,
    BLACK
}

public class EnemyBeetleDamageController : MonoBehaviour, IDamageable
{
    public BEETLE_ENEMY_TYPE beetleEnemyType => m_beetleEnemyType;

    [SerializeField]
    private BEETLE_ENEMY_TYPE m_beetleEnemyType;

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