using UnityEngine;

public class StartMenuInteractions : MonoBehaviour
{
    [SerializeField]
    private Camera m_titleCamera;

    [SerializeField]
    private Camera m_gameplayCamera;

    [SerializeField]
    private GameObject m_beetleEnemyWaveManager;

    public void OnNewGamePressed()
    {
        if(m_titleCamera == null)
            return;

        Camera.SetupCurrent(m_gameplayCamera);

        m_titleCamera.gameObject.SetActive(false);

        m_beetleEnemyWaveManager.SetActive(true);

        gameObject.SetActive(false);
    }
}