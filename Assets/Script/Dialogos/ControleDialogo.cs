using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControleDialogo : MonoBehaviour
{

    [System.Serializable]
    public enum idioma
    {
        ptBr,
        eng
    }

    public idioma linguagem;

    [Header("Componentes")]
    public GameObject dialogoObj; //Janela de dialogo
    public Image spritePerfil;    //Sprite do perfil
    public Text falaTexto;        //Texto da fala
    public Text atorNameTexto;    //Nome do NPC

    [Header("Configuracao")]
    public float velocidadeEscrita; //Velocidade da fala

    //Variáveis de controle
    private bool estaMostrando; //Se a janela está visível
    private int index;          //Index das falas
    private string[] sentencas;

    public static ControleDialogo instance;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    IEnumerator TypeSentence()
    {
        foreach (char letra in sentencas[index].ToCharArray())
        {
            falaTexto.text += letra;
            yield return new WaitForSeconds(velocidadeEscrita);
        }
    }

    //Pular para a próxima frase
    public void NextSentenca()
    {
        if(falaTexto.text == sentencas[index])
        {
            if(index < sentencas.Length - 1)
            {
                index++;
                falaTexto.text = "";
                StartCoroutine(TypeSentence());
            }
            else
            {
                falaTexto.text = "";
                index = 0;
                dialogoObj.SetActive(false);
                sentencas = null;
                estaMostrando = false;
            }
        }
    }

    //Chamar a frase do NPC
    public void Fala(string[] txt)
    {
        if (!estaMostrando)
        {
            dialogoObj.SetActive(true);
            sentencas = txt;
            StartCoroutine(TypeSentence());
            estaMostrando = true;
        }

    }
}
