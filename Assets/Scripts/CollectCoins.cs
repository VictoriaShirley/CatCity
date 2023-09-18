using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCoins : MonoBehaviour
{
    private int moedasColetadas = 0;

    // Define o número total de moedas a serem coletadas
    public int numeroTotalDeMoedas = 30;

    // Evento que pode ser usado para notificar outras partes do jogo quando um objeto é coletado
    public delegate void moedaColetadaAction(int moedasColetadas);
    public event moedaColetadaAction OnMoedaColetada;

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Verifica se o objeto colidido é um objeto colecionável
        if (other.CompareTag("MoedaColecionavel"))
        {
            // Destroi o objeto colecionável
            Destroy(other.gameObject);

            // Incrementa o contador de moedas coletadas
            moedasColetadas++;

            // Dispara o evento para notificar outras partes do jogo
            OnMoedaColetada?.Invoke(moedasColetadas);

            // Verifica se todos os moedas foram coletadas
            if (moedasColetadas >= numeroTotalDeMoedas)
            {
                // Faça algo quando todos os moedas forem coletadas, como exibir uma mensagem de vitória.
                Debug.Log("Você coletou todas as moedinhas!");
            }
        }
    }
}