using System;
using UnityEngine;

[Serializable]
public struct TimeBeetleEnemyPair
{
    [Range(0f, 10f)]
    public float m_timeToWaitBeforeSpawning;

    public GameObject m_enemyBeetleToSpawn;
}