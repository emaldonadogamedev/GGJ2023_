using System;
using UnityEngine;

[Serializable]
public struct TimeBeetleEnemyPair
{
    [Min(0f)]
    public float m_timeToWaitBeforeSpawning;

    public GameObject m_enemyBeetleToSpawn;
}