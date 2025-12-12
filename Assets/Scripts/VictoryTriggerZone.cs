using UnityEngine;

public class VictoryTriggerZone : MonoBehaviour
{
    [Header("UI de Vitória")]
    public GameObject victoryPanel; 
    public string playerTag = "Player"; 

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(playerTag))
        {
            EndGameVictory();
        }
    }

    void EndGameVictory()
    {
        if (victoryPanel != null)
        {
            victoryPanel.SetActive(true);
        }
        Time.timeScale = 0f;
    }
}