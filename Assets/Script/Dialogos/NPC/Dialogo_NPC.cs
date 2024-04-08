using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogo_NPC : MonoBehaviour
{
    public float dialogoAlcance;
    public LayerMask playerLayer;

    public ConfiguracaoDialogo dialogo;

    bool playerHit;

    private List<string> sentencas = new List<string>();

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerHit)
        {
            ControleDialogo.instance.Fala(sentencas.ToArray());
        }
    }

    void TextosNpc()
    {
        for (int i = 0; i < dialogo.dialogos.Count; i++)
        {
            switch (ControleDialogo.instance.linguagem)
            {
                case ControleDialogo.idioma.ptBr:
                    sentencas.Add(dialogo.dialogos[i].sentenca.portugues);
                    break;

                case ControleDialogo.idioma.eng:
                    sentencas.Add(dialogo.dialogos[i].sentenca.english);
                    break;
            }

        }
    }
    void Start()
    {
        TextosNpc();
    }


    void FixedUpdate()
    {
        MostrarDialogo();
    }

    void MostrarDialogo()
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position, dialogoAlcance, playerLayer);

        if (hit != null)
        {
            playerHit = true;
        }
        else
        {
           playerHit= false;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, dialogoAlcance);
    }


}
