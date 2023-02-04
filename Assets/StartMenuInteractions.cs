using UnityEngine;

public class StartMenuInteractions : MonoBehaviour
{
    [SerializeField]
    private Camera m_titleCamera;

    [SerializeField]
    private Camera m_gameplayCamera;

    [SerializeField]
    private GameObject m_beetleEnemyWaveManager;

    [SerializeField]
    private GameObject m_gameplayUI;

    public void OnNewGamePressed()
    {
        if(m_titleCamera == null)
            return;

        Camera.SetupCurrent(m_gameplayCamera);

        m_titleCamera.gameObject.SetActive(false);

        m_beetleEnemyWaveManager.SetActive(true);

        m_gameplayUI.SetActive(true);

        gameObject.SetActive(false);
    }
}