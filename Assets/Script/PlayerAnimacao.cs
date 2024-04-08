using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimacao : MonoBehaviour
{
    private Player player;
    private Animator anim;

    void Start()
    {
        player = GetComponent<Player>();  
        anim = GetComponent<Animator>();
    }


    void Update()
    {

        OnMove();
        OnRun();
    }

    #region Movimentacao

    void OnMove()
    {
        if (player.direcao.sqrMagnitude > 0)
        {
            if (player.estaRolando)
            {
                anim.SetTrigger("Rolagem");
            }else

            {
                anim.SetInteger("Transiçao", 1);

            }
        }
        else
        {
            anim.SetInteger("Transiçao", 0);
        }
        if (player.direcao.x > 0)
        {
            transform.eulerAngles = new Vector2(0, 0);
        }
        if (player.direcao.x < 0)
        {
            transform.eulerAngles = new Vector2(0, 180);
        }
    }

    void OnRun()
    {
        if (player.estaCorrendo)
        {
            anim.SetInteger("Transiçao", 2);
        }
    }

    #endregion
}
