using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inimigo : MonoBehaviour
{
    //acessando o rigidbody
    private Rigidbody2D rb;
    
    private float tempoTiro = 0.5f;
    //tiro do inimigo
    [ SerializeField ] private GameObject tiroInimigo;
    //velocidade do inimigo
    [ SerializeField ] private float vel;
    //muda direção do inimigo a partir da altura
    [ SerializeField ] private float alturaD = 3f;
    private bool movimentacao = true;
    [ SerializeField ] private int vidaInimigo;

    void Start()
    {
        //passando rigidbody
        rb = GetComponent<Rigidbody2D>();
        //passando a velocidade para o rb
        rb.velocity = new Vector2(0f, vel);
        //rb.velocity = Vector2.up*vel;
    }

    void Update()
    {
        
        //acessando a componente do filho
        bool comp = GetComponentInChildren<SpriteRenderer>().isVisible;
        
        if(comp) {
            //diminuindo o tempo do tiro até que seja menor ou igual a zero para atirar
            tempoTiro -= Time.deltaTime;
            if(tempoTiro <= 0) {
                //instanciando o tiro do inimigo
                Instantiate(tiroInimigo, transform.position, transform.rotation);
                //reiniciando o tempo do tiro;
                tempoTiro = 0.5f;
            }
        }
        //mudando a direção do inimigo dependendo da posição x a partir da altura definida
        if(transform.position.y < alturaD && movimentacao && transform.position.x < 0f) {
            rb.velocity = new Vector2(vel * -1, vel);
            movimentacao = false;
        } else if (transform.position.y < alturaD && movimentacao && transform.position.x > 0f) {
            rb.velocity = new Vector2(vel, vel);
            movimentacao = false;
        }

        if(transform.position.y < -5f || transform.position.x < -9f || transform.position.x > 9) {
            Destroy(gameObject);
        }

    }

    public void SofreDano(int perda) {
        //perdendo vida 
        vidaInimigo -= perda; 
        if(vidaInimigo <=0) {
            Destroy(gameObject);
        //pontuação do player
        FindObjectOfType<geradorInimigos>().Pontos(10);
        }
    }
    
}
