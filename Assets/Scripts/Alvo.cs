using UnityEngine;
using System.Collections;

public class Alvo : MonoBehaviour {
    public bool coleta;
    public int endereco;
    public bool isReceiver;
    public float tempo;
    public float _tempo;
    public bool gatilho;
    public bool isBeingVisited;
    public GameObject alvo;
	// Use this for initialization
	void Start () {
        _tempo = tempo;
        gatilho = false;
	}
	
	// Update is called once per frame
	void Update () {

        if (gatilho)
        {
            _tempo -= Time.deltaTime;

             if (_tempo<= 0)
            {
                sumir();
                _tempo = tempo;
                gatilho = false;
            }
        }
	}
    void OnTriggerEnter2D(Collider2D other)
    {

        if(!(other.CompareTag("Old")||other.CompareTag("Virgin")))
        decide(other);
    }
    void sumir()
    {
        alvo.SetActive(false);  
    }
   public void aparecer()
    {
        alvo.SetActive(true);
    }
    void decide(Collider2D other)
    {
        
        if (isReceiver)
        {
            if (other.CompareTag("Player"))
            {
                 CargaDaVan van = other.gameObject.GetComponent<CargaDaVan>();
                 van.Entrega = true;
                 van.alvoAtual = endereco;
                 gatilho=true;
                 isBeingVisited = true;
            }
        }
    
        else
        {
            if (other.CompareTag("Player"))
            {
                isBeingVisited = true;
                encaminhar(other);
            }
        }
    }
    void encaminhar(Collider2D other)
    {
        
        CargaDaVan van = other.gameObject.GetComponent<CargaDaVan>();
        if (isReceiver) van.Entrega = true;
        else
        {
            van.Pizzaria = true;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player")) { 
            CargaDaVan van = other.gameObject.GetComponent<CargaDaVan>();
            van.Pizzaria = false;
            van.Entrega = false;
            van.alvoAtual = -1;
            isBeingVisited = false;
            if (!isReceiver)
            {
                gatilho = true;
            }
        }
    }
}
