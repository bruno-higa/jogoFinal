using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControleBoss : MonoBehaviour
{
    [ SerializeField ] private string acao = "movimento";
    [ SerializeField ] private GameObject tiroBoss;
    private float tempoTiro = 0.5f;
    //velocidade do Boss
    [ SerializeField ] private float velB = 4f;
    [ SerializeField ] private Rigidbody2D RbBoss;
    //limitação da movimentação da boss
    [ SerializeField ] private float limiteH = 6f;
    [ SerializeField ] private bool direita = true;
    [ SerializeField ] private int vidaBoss = 100;
    private bool morte = false;

    void Start()
    {
        RbBoss = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {   
        bool comp = GetComponentInChildren<SpriteRenderer>().isVisible;
        
        if(comp) {
            //diminuindo o tempo do tiro até que seja menor ou igual a zero para atirar
            tempoTiro -= Time.deltaTime;
            if(tempoTiro <= 0) {
                //instanciando o tiro do boss
                Instantiate(tiroBoss, transform.position, transform.rotation);
                //reiniciando o tempo do tiro;
                tempoTiro = 0.5f;
            }
        }

        switch (acao) {
            case "movimento":
            Movimento();
            break;
        }
    }
    /* método para movimentar o boss da direita para esquerda com a sua respectiva limitação 
    horizontal*/
    private void Movimento() {
        if(direita) {
            RbBoss.velocity = new Vector2(velB, 0f);
        }
        else {
            RbBoss.velocity = new Vector2(-velB, 0f);
        }
        if(transform.position.x >= limiteH) {
            direita = false;
        } else if(transform.position.x <= -limiteH) {
            direita = true;
        }
    }

    public void SofreDano(int perda) {
        //perdendo vida 
        vidaBoss -= perda; 
        if(vidaBoss <=0) {
            Destroy(gameObject);
            //SceneManager.LoadScene(0);
            morte = true;
        }
        //reiniciando o jogo após a morte do boss
        if(morte) {
            SceneManager.LoadScene(0);
        }
    }
}
