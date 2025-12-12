using UnityEngine;

public class VictoryTriggerZone : MonoBehaviour
{
    [Header("UI de Vitória")]
    // Arraste para cá o objeto Panel (ou o Canvas) que você criou no Passo 1
    public GameObject victoryPanel; 

    // O Tag que identifica o jogador
    public string playerTag = "Player"; 

    // Chamado quando um objeto entra no Trigger
    void OnTriggerEnter2D(Collider2D other)
    {
        // Verifica se o objeto que entrou no trigger é o jogador
        if (other.CompareTag(playerTag))
        {
            EndGameVictory();
        }
    }

    void EndGameVictory()
    {
        // 1. EXIBE A MENSAGEM DE VITÓRIA (tornando o painel ativo)
        if (victoryPanel != null)
        {
            victoryPanel.SetActive(true);
        }

        // 2. PAUSA O JOGO
        // Define a escala de tempo para 0, parando o movimento e a lógica do jogo.
        Time.timeScale = 0f;

        // Opcional: Desative scripts de controle do jogador se o Time.timeScale=0 não for suficiente.
        // Opcional: Aqui você pode colocar botões para 'Reiniciar' (setando Time.timeScale=1 e SceneManager.LoadScene(CurrentScene))
    }
}