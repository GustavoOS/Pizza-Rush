using UnityEngine;
using System;
using System.Collections.Generic;
using UnityEngine.UI;



public class ControleUsuario : MonoBehaviour {
    public float velocidade;
    public float curva;
    private Rigidbody2D rb;
    public float HP;
    public Text HPText;
    public Text Perdeu;
    private float tempo = 2.0f;
    private bool lost;
    public string FirstStage;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        SetCountText();
        Perdeu.text = "";
        lost = false;
	}
	
	// FixedUpdate is called once per frame
   
    float FrenteOuRe(float moveVertical)
    {
        if (moveVertical > 0f)
        {
            return 1;
        }
        else
        {
            if (moveVertical < 0f)
            {
                return -1;
            }
            else
            {
                return 1;
            }
        }
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        
        rb.AddTorque(-moveHorizontal * curva * Time.deltaTime*FrenteOuRe(moveVertical));
        Vector2 movimento = rb.transform.up * moveVertical ;
        rb.AddForce(movimento.normalized*velocidade);
    }
    void OnCollisionStay2D(Collision2D other){
        if (!(other.gameObject.CompareTag("Pizza") || other.gameObject.CompareTag("Semaforo") || other.gameObject.CompareTag("Virador")))
        {
            HP -= Time.deltaTime;
            SetCountText();
        }
    }
    void Update()
    {
        if (Mathf.RoundToInt(HP) <= 0)
        {
            velocidade = 0;
            curva = 0;
            Perdeu.text = "Game Over!";
            lost = true;
        }
        if (lost)
        {
            tempo -= Time.deltaTime;
            if (Mathf.RoundToInt(tempo) <= 0)
            {
                Application.LoadLevel(FirstStage);
            }
        }
    }
    void SetCountText()
    {
        int _hp=0;
        _hp = Mathf.RoundToInt(20 * HP);
        HPText.text = "HP: " + _hp.ToString()+@"%";
    }
}
