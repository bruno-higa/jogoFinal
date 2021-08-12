using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlePlayer : MonoBehaviour
{
    private Rigidbody2D rb;
    [ SerializeField ] private float vel = 5f;
    [ SerializeField ] private GameObject tiroJogador;
    [ SerializeField ] private int vidaJogador = 30;
    [ SerializeField ] private float limX1;
    [ SerializeField ] private float limX2;
    [ SerializeField ] private float limY1;
    [ SerializeField ] private float limY2;
    private bool morte = false;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //Input horizontal e vertical
        float horizontal = Input.GetAxis ("Horizontal");
        float vertical = Input.GetAxis ("Vertical");
        Vector2 velocidade = new Vector2 (horizontal, vertical);
        //Normalizando a velocidade
        velocidade.Normalize();
        //Passando para a velocidade o Rigidbody
        rb.velocity = velocidade*vel;
        //Tiro do jogador
        if(Input.GetButtonDown("Fire1")) {
            Instantiate(tiroJogador, transform.position, transform.rotation);
        }
        //verificando a posição e limitando a posição na tela
        float xLim = Mathf.Clamp(transform.position.x, limX1, limX2);
        float yLim = Mathf.Clamp(transform.position.y, limY1, limY2);
        //limitando a movimentação do player na tela
        transform.position = new Vector3(xLim, yLim, transform.position.z);

    }
    public void SofreDano(int perda) {
        //perdendo vida 
        vidaJogador -= perda; 
        if(vidaJogador <=0) {
            Destroy(gameObject);
            morte = true;
            
        }
        //reiniciando o jogo após a morte do jogador
        if(morte) {
            SceneManager.LoadScene(0);
        }
    }
}
