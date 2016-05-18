using UnityEngine;
using System.Collections;

public class URPIZZA : MonoBehaviour {
    
    public float tempo;
    private float _tempo;
    
    public GameObject novaPizza;

    public GameObject SaidaDePizza;
    public GameObject Cliente1;
    public GameObject Cliente2;
    public GameObject Cliente3;
    public GameObject Cliente4;
    public GameObject Cliente5;
    public GameObject Cliente6;
    public GameObject Cliente7;

    public GameObject[] Alvos;

    public bool[] Ativos;
    public bool isBeingVisited;
    private Alvo pizzaplace;
    private bool[] Despachados;

    public int nextPizza;
    private pizza _pizza;

	// Use this for initialization
	void Start () {
        Despachados = new bool[8];
        Alvos= new GameObject[8] { SaidaDePizza, Cliente1, Cliente2, Cliente3, 
                                    Cliente4, Cliente5, Cliente6, Cliente7 };
        Ativos=new bool[8];
        for (int i = 0; i < 8; i++)
        {
            Ativos[i] = false;
            Despachados[i] = false;
            Alvos[i].SetActive(false);
        }

        _tempo = tempo;
        pizzaplace = Alvos[0].GetComponent<Alvo>();
	}
    void atualizaAtivos()
    {
        for (int i = 0; i < 8; i++)
        {
            Ativos[i] = Alvos[i].activeSelf;
        }
    }

    void novapizza()
    {
        int destino = nextPizza;
        GameObject essapizza= Instantiate(novaPizza, Alvos[0].transform.position, Alvos[0].transform.rotation) as GameObject;
        _pizza = essapizza.GetComponent<pizza>();
        _pizza.destino = destino;
        Despachados[destino] = true;
    }

	// Update is called once per frame
	void Update () {
        atualizaAtivos();
        isBeingVisited = pizzaplace.isBeingVisited;
        
        _tempo -= Time.deltaTime;
        if (Mathf.RoundToInt(_tempo) <= 0)
        {
            nextPizza = Mathf.RoundToInt(Random.Range(1.0F, 7.0F));
            Alvos[0].SetActive(true);
            novapizza();
            //Alvos[novapizza()].SetActive(true);
            _tempo = tempo;
        }
        despachante();
	}

    void despachante()
    {
        if (isBeingVisited)
        {
            for (int i = 0; i < 8; i++)
            {
                if (Despachados[i])
                {
                    Alvos[i].SetActive(true);
                    Despachados[i] = false;
                }
            }
        }
    }
}
