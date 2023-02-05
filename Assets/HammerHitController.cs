using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerHitController : MonoBehaviour
{
    [SerializeField]
    private GameplayUImanager m_gameplayUImanager;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.TryGetComponent(
            out EnemyBeetleDamageController enemyBeetleDamageController))
        {
            switch(enemyBeetleDamageController.beetleEnemyType)
            {
                case BEETLE_ENEMY_TYPE.GREEN:
                    m_gameplayUImanager.OnGreenBeetleKilled.Invoke();
                    break;

                case BEETLE_ENEMY_TYPE.RED:
                    m_gameplayUImanager.OnRedBeetleKilled.Invoke();
                    break;
            }
        }
    }
}
