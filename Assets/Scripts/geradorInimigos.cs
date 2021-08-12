using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class geradorInimigos : MonoBehaviour
{
    [ SerializeField ] private GameObject inimigo1;
    //tempo de espera para o inimigo surgir
    [ SerializeField ] private float espera = 5f;
    //reiniciando a contagem de espera
    private float tempoInimigo = 0f;
    [ SerializeField ] private int pontuacao = 0;
    //level
    [ SerializeField ] private int level = 1;
    [ SerializeField ] private int proxLevel = 600;
    [ SerializeField ] private GameObject boss;
    private int numeroDeInimigos = 0;
    private bool apareceBoss = false;
    
    private GameObject maisInimigo;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GerandoInimigos();
        if(level < 4) {
            GerandoInimigos();
        }else{
            //fazendo o boss surgir caso o level seja maior do que 4
            SurgeBoss();
        }
    }

    private void SurgeBoss() {
        //instanciando o boss
        if(!apareceBoss) {
            transform.position = new Vector3(0f, 3f, 0f);
            Instantiate(boss, transform.position, transform.rotation); 
            apareceBoss = true;
        }
        
    }

    //pontuação do player
    public void Pontos(int pontuacao) {
        this.pontuacao += pontuacao;
        //aumentando o level caso a pontuação seja maior do que o proxLevel
        if(this.pontuacao > proxLevel * level) {
            level++;
        }
    }

    private void GerandoInimigos() {
        //diminuindo o tempo de espera do inimigo
        if(tempoInimigo > 0) {
            tempoInimigo -= Time.deltaTime;
        }
        //verificando se a espera zerou
        if(tempoInimigo <= 0f) {
            numeroDeInimigos = level * 4;
            int numInimigos = 0;
            int qtdVezes = 0;
            do
            {
            //saindo do laço caso o numero de repetição seja maior que 150
            qtdVezes++;
            if(qtdVezes > 150) {
                break;
            }
            //encerrando o gerador de inimigos caso o level seja maior do que 4
            if(level > 3) {
                break;
            }
            //criando mais inimigo de acordo com o level
            float nivel = Random.Range(0f, level);
            if(nivel > 3f) {
                maisInimigo = inimigo1;
            } else {
                maisInimigo = inimigo1;
            }
            //posição inicial do inimigo
            Vector3 posicaoInimigo = new Vector3(Random.Range(-9f, 9f), Random.Range(6f, 8f), 0f);
            //fazendo surgir inimigo
            Instantiate(maisInimigo, posicaoInimigo, transform.rotation);
            //aumentando o numero de inimigos
            numInimigos++;
            //fazendo a espera pelo inimigo de novo
            tempoInimigo = espera;
            }while(numInimigos < numeroDeInimigos);
        }
    }
}
