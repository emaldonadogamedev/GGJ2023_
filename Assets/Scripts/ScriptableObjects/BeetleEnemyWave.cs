using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(
    fileName = "BeetleEnemyWaveData",
    menuName = "GGJ_2023/BeetleEnemyWave", order = 1)]
[Serializable]
public class BeetleEnemyWave : ScriptableObject
{
    public List<TimeBeetleEnemyPair> m_timeBeetleEnemyPairs;
}