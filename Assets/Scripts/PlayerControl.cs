using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public float jumpForce = 5f;
    public int maxJumps = 2;
    private int jumpsRemaining;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        jumpsRemaining = maxJumps;
    }

    private void Update()
    {
        // Movimentação horizontal
        float moveX = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveX * moveSpeed, rb.velocity.y);

        if(rb.velocity != Vector2.zero){
            GetComponent<Animator>().SetBool("Run", true);
        }

        else
        {
            GetComponent<Animator>().SetBool("Run", false);
        }    

        // Verifica se o jogador quer pular
        if (Input.GetButtonDown("Jump"))
        {
            GetComponent<Animator>().SetBool("Jump", true);
            Jump();
        }
          else
        {
            GetComponent<Animator>().SetBool("Jump", false);
        }    

    }

    private void Jump()
    {
        // Verifica se ainda é possível pular
        if (jumpsRemaining > 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            jumpsRemaining--;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Reseta o contador de pulos quando o personagem toca no chão
        if (collision.gameObject.CompareTag("Ground"))
        {
            jumpsRemaining = maxJumps;
        }

        if (collision.gameObject.CompareTag("Deep"))
        {
            SceneManager.LoadScene("Lose");
        }

        if (collision.gameObject.CompareTag("Block"))
        {
            SceneManager.LoadScene("Lose");
        }
    }
}