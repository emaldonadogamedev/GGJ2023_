using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class GameplayUImanager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI m_timerText;
    private float m_currentTime = 0f;

    [SerializeField]
    private TextMeshProUGUI m_greenBeetleTextKilled;
    private int m_greenBeetlesKilled = 0;

    [SerializeField]
    private TextMeshProUGUI m_redBeetleTextKilled;
    private int m_redBeetlesKilled = 0;

    public readonly UnityEvent OnGreenBeetleKilled = new();
    public readonly UnityEvent OnRedBeetleKilled = new();

    private void Start()
    {
        OnGreenBeetleKilled.AddListener(OnGreenEnemyBeetleKilled);
        OnRedBeetleKilled.AddListener(OnRedEnemyBeetleKilled);
    }

    // Update is called once per frame
    void Update()
    {
        m_currentTime += Time.deltaTime;
        m_timerText.text = GetFormattedTime();
    }

    private void OnGreenEnemyBeetleKilled()
    {
        m_greenBeetlesKilled++;

        m_greenBeetleTextKilled.text = $" x {m_greenBeetleTextKilled}";
    }

    private void OnRedEnemyBeetleKilled()
    {
        m_redBeetlesKilled++;

        m_redBeetleTextKilled.text = $" x {m_redBeetlesKilled}";
    }

    private string GetFormattedTime()
    {
        int minutes = (int)(m_currentTime / 60f);
        int seconds = ((int)(m_currentTime)) % 60;

        return $"Time - {minutes}:{seconds}";
    }
}