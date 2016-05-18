using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;


public class CargaDaVan : MonoBehaviour {
    public int alvoAtual;
    public bool Entrega;
    public bool Pizzaria;
    public int numerodepizzas;
    public GameObject _Pizza;
    private int[] carga;
    public bool isLastStage;
    public int MaxPizzas;
    public int pizzasEntregues;
    public Text TextoPizzas;
    public Text WinText;
    private Transform pos;
    public string nextStage;
    private float tempo = 2.0f;
    private bool won;
    // Use this for initialization
	void Start () {
        alvoAtual = -1;
        carga=new int[8]{0,0,0,0,0,0,0,0};
        numerodepizzas = 0;
        pizzasEntregues = 0;
        SetCountText();
        WinText.text = "";
        won = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (Entrega)
        {
            //Debug.Log("Entrou3");
            conferir();
        }
        if (pizzasEntregues >= MaxPizzas)
        {
            SetWinText();
            won = true;
            
            
        }
        if (won)
        {
            tempo -= Time.deltaTime;
            if (Mathf.RoundToInt(tempo) <= 0)
            {
                Application.LoadLevel(nextStage);
            }
        }
	}
    void OnTriggerEnter2D(Collider2D other)
    {
        
        if (Pizzaria)
        {
            if (other.gameObject.CompareTag("Pizza"))
            {
                //Debug.Log("Entrou1");
                pizza pedido;
                pedido = other.gameObject.GetComponent<pizza>() ;
                carga[pedido.destino]++;
                numerodepizzas++;
                Destroy(other.gameObject);
            }
        }
        pos = other.GetComponent<Transform>();
        
        
    }
    void entregar()
    {
        Instantiate(_Pizza, pos.position, pos.rotation);
        numerodepizzas--;
        pizzasEntregues++;
        SetCountText();
        
    }
    void conferir()
    {
        if (numerodepizzas > 0 && alvoAtual!=0)
        {
            //foreach (int endereco in carga)
            //{
            //    if (endereco == alvoAtual)
            //    {
            //        entregar();
            //        carga.Remove(endereco);
                    
            //    }
            //}
            int k = carga[alvoAtual];
            if (k > 0)
            {
                for (int i = 0; i < k; i++)
                {
                    carga[alvoAtual]--;
                    entregar();
                
                    
                }
            }

        }
    }
    void SetCountText()
    {
        TextoPizzas.text = "Pizzas: " + pizzasEntregues.ToString();
    }
    void SetWinText()
    {
        if (isLastStage)
        {
            WinText.text = "You Win! \nThanks for playing!";
        }
        else
        {
            WinText.text = "Level completed!";
        }
    }
}
