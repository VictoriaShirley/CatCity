using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Camera : MonoBehaviour
{
    public float scrollSpeed = 2.0f; // Velocidade de deslocamento da câmera
    public Vector2 scrollDirection = Vector2.right; // Direção do deslocamento
    public float endGameXPosition = 170.0f; // Posição em que o jogo terminará
    public Transform player; // Transform do jogador
    public float playerDistanceToCamera = 2.0f; // Distância mínima entre o jogador e a câmera

    private bool gameEnded = false;

    private void Update()
    {
        if (!gameEnded)
        {
            Vector3 newPosition = transform.position + new Vector3(scrollDirection.x, scrollDirection.y, 0) * scrollSpeed * Time.deltaTime;
            transform.position = newPosition;

            // Verificar se a posição da câmera excedeu a posição de término do jogo
            if (transform.position.x >= endGameXPosition)
            {
                // Se sim, encerrar o jogo
                EndGame();
            }

            // Verificar a distância entre o jogador e a câmera
            if (player != null)
            {
                float distance = Mathf.Abs(player.position.x - transform.position.x);
                if (distance < playerDistanceToCamera)
                {
                    // Se o jogador estiver muito perto da câmera, ajuste a posição do jogador
                    Vector3 playerPosition = player.position;
                    playerPosition.x = transform.position.x + playerDistanceToCamera;
                    player.position = playerPosition;
                }
            }
        }
    }

    private void EndGame()
    {
        // Realize as ações necessárias para encerrar o jogo, como exibir uma tela de pontuação ou mensagem de vitória/derrota.
        // Você também pode carregar uma cena de tela de fim de jogo ou fazer qualquer outra ação necessária aqui.

        // Defina o jogo como encerrado para que a câmera não continue se movendo
        gameEnded = true;

        // Carregar uma nova cena
        SceneManager.LoadScene("Win"); // Substitua "NomeDaSuaCena" pelo nome da cena que você deseja carregar
    }
}