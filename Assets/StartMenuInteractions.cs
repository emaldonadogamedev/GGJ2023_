using UnityEngine;

public class StartMenuInteractions : MonoBehaviour
{
    [SerializeField]
    public Camera m_titleCamera;

    [SerializeField]
    public Camera m_gameplayCamera;

    public void OnNewGamePressed()
    {
        if(m_titleCamera == null)
            return;

        Camera.SetupCurrent(m_gameplayCamera);

        m_titleCamera.gameObject.SetActive(false);

        gameObject.SetActive(false);
    }
}