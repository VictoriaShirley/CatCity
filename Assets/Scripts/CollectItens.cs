using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectItens : MonoBehaviour
{
     private int itensColetados = 0;

    // Define o número total de itens a serem Coletados
    public int numeroTotalDeItens = 3;

    // Evento que pode ser usado para notificar outras partes do jogo quando um objeto é coletado
    public delegate void itemColetadoAction(int itensColetados);
    public event itemColetadoAction OnitemColetado;

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Verifica se o objeto colidido é um objeto colecionável
        if (other.CompareTag("ObjetoColecionavel"))
        {
            // Destroi o objeto colecionável
            Destroy(other.gameObject);

            // Incrementa o contador de itens Coletados
            itensColetados++;

            // Dispara o evento para notificar outras partes do jogo
            OnitemColetado?.Invoke(itensColetados);

            // Verifica se todos os itens foram Coletados
            if (itensColetados >= numeroTotalDeItens)
            {
                // Faça algo quando todos os itens forem Coletados, como exibir uma mensagem de vitória.
                Debug.Log("Você coletou todos os itens!");
            }
        }
    }
}