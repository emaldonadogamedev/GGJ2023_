using System.Collections.Generic;
using UnityEngine;

public class BeetleWaveManager : MonoBehaviour
{
    [SerializeField]
    private List<BeetleEnemyWave> m_beetleEnemyWavesToChooseFrom;

    private BeetleEnemyWave m_currentBeetleEnemyWave = null;

    private bool m_isWaitingInBetweenWaves = false;
    private float m_timeToWaitInBetweenWaves;

    private float m_currentTimeToWaitInBetweenEnemies;
    private int m_currentEnemyIndex;

    private GameObject m_carrotHouse = null;

    private bool m_isReadyForNextWave;

    private void Start()
    {
        // TODO: IMPROVE THIS
        // EXPENSIVE AND NOT EFFICIENT, but only once per game session
        m_carrotHouse = GameObject.Find("House_SM");

        PickAnewEnemyWave();
    }

    // Update is called once per frame
    void Update()
    {
        if(m_isWaitingInBetweenWaves)
        {
            m_timeToWaitInBetweenWaves -= Time.deltaTime;

            if(m_timeToWaitInBetweenWaves <= 0f)
            {
                m_isWaitingInBetweenWaves = false;

                PickAnewEnemyWave();
            }
        }
        else
        {
            m_currentTimeToWaitInBetweenEnemies -= Time.deltaTime;

            if(m_currentTimeToWaitInBetweenEnemies <= 0f)
            {
                SpawnBeetleEnemyFromWave(
                    m_currentEnemyIndex,
                    m_currentBeetleEnemyWave.m_timeBeetleEnemyPairs);

                m_isReadyForNextWave =
                    m_currentEnemyIndex + 1 >= m_currentBeetleEnemyWave.m_timeBeetleEnemyPairs.Count;

                if (m_isReadyForNextWave)
                {
                    m_isWaitingInBetweenWaves = true;
                    m_timeToWaitInBetweenWaves = Random.Range(10f, 15f);

                    return;
                }

                UpdateEnemyIndex();
            }
        }
    }

    private void PickAnewEnemyWave()
    {
        m_currentBeetleEnemyWave =
            m_beetleEnemyWavesToChooseFrom[
                Random.Range(
                    0,
                    m_beetleEnemyWavesToChooseFrom.Count - 1)
            ];

        // Prepare for frst enemy
        m_currentTimeToWaitInBetweenEnemies =
            m_currentBeetleEnemyWave.m_timeBeetleEnemyPairs[0].m_timeToWaitBeforeSpawning;

        m_currentEnemyIndex = 0;
    }

    private void SpawnBeetleEnemyFromWave(
        int enemyIndex,
        List<TimeBeetleEnemyPair> m_timeBeetleEnemyPairs)
    {
        GameObject newBeetleEnemy = 
            Instantiate(
                m_timeBeetleEnemyPairs[enemyIndex].m_enemyBeetleToSpawn,
                gameObject.transform.position,
                Quaternion.identity);

        if(newBeetleEnemy.TryGetComponent(
            out MoveStraightTowardsTarget moveStraightTowardsTarget))
        {
            moveStraightTowardsTarget.SetNewTarget(m_carrotHouse);
        }

    }

    private void UpdateEnemyIndex()
    {
        ++m_currentEnemyIndex;

        m_currentTimeToWaitInBetweenEnemies =
            m_currentBeetleEnemyWave.m_timeBeetleEnemyPairs[
                m_currentEnemyIndex].m_timeToWaitBeforeSpawning;
    }
}