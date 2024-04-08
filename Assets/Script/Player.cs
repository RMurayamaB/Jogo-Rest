using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Player : MonoBehaviour
{
  [SerializeField] private float velocidade;
    [SerializeField] private float corridaVelocidade;

    private Rigidbody2D rig;

    private bool _estaCorrendo;
    private bool _estaRolando;
    private float VelocidadeInicial;
    private Vector2 _direcao;

    public bool estaRolando
    {
        get { return _estaRolando; }
        set { _estaRolando = value; }
    }
    public bool estaCorrendo
    {
        get { return _estaCorrendo; }
        set { _estaCorrendo = value; }
    }

    public Vector2 direcao
    {
        get { return _direcao; }
        set { _direcao = value; }
    }

    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        VelocidadeInicial = velocidade;
    }

    private void Update()
    {
        OnInput();
        OnRun();
        EstaRolando();
    }

    private void FixedUpdate()
    {
        OnMove();
    }

    #region Movement

    void OnInput()
    {
        _direcao = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }

    void OnMove()
    {
        rig.MovePosition(rig.position + _direcao * velocidade * Time.fixedDeltaTime);
    }

    void OnRun()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            velocidade = corridaVelocidade;
            _estaCorrendo = true;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            velocidade = VelocidadeInicial;
            _estaCorrendo = false;
        }
    }

    void EstaRolando()
    {
        if (Input.GetMouseButtonDown(1))
        {
            velocidade = corridaVelocidade;
            _estaRolando = true;
        }
        if(Input.GetMouseButtonUp(1))
        {
            _estaRolando = false;
        }
    }

    #endregion
}
