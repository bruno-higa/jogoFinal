using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiroJogador : MonoBehaviour
{
    private Rigidbody2D rb;
    //velocidade do tiro do player
    [ SerializeField ] private float vel = 10f;
    [ SerializeField ] private GameObject explosao;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //tiro para cima
        rb.velocity = new Vector2(0f, vel);
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //verificando se a tag de colisão é um inimigo
        if(collision.CompareTag("inimigo")) {
            //acessando o metodo SofreDano e aplicando dano
            collision.GetComponent<inimigo>().SofreDano(1);
            
        }

        if(collision.CompareTag("jogador")) {
            //acessando o metodo SofreDano e aplicando dano
            collision.GetComponent<ControlePlayer>().SofreDano(1);
            
        }
        if(collision.CompareTag("chefe")) {
            //acessando o metodo SofreDano e aplicando dano
            collision.GetComponent<ControleBoss>().SofreDano(1);
            
        }
        Destroy(gameObject);
        //explosao do tiro
        Instantiate(explosao, transform.position, transform.rotation);
    }
}
