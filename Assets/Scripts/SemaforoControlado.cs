using UnityEngine;
using System.Collections;

public class SemaforoControlado : MonoBehaviour {
    public bool isVerde;
    public GameObject esteSemaforo;
    public GameObject SemaforoVerde;
    public GameObject SemaforoVermelho;

    private SpriteRenderer Verde;
    private SpriteRenderer Vermelho;
    private Collider2D colisor;


    public GameObject Virador1;
    public GameObject Virador2;
    private Collider2D v1;
    private Collider2D v2;

    public int este;
    public int ultimoAberto;

	// Use this for initialization
	void Start () {
        colisor = esteSemaforo.GetComponent<Collider2D>();
        Verde = SemaforoVerde.GetComponent<SpriteRenderer>();
        Vermelho = SemaforoVermelho.GetComponent<SpriteRenderer>();
        v1 = Virador1.GetComponent<Collider2D>();
        v2 = Virador2.GetComponent<Collider2D>();
	}
	
	// Update is called once per frame
	void Update () {
        if (isVerde)
        {            
            Verde.enabled = true;
            Vermelho.enabled = false;            
            colisor.enabled = false;  
        }
        else
        {
            Verde.enabled = false;
            Vermelho.enabled = true;            
            colisor.enabled = true;

        }
        if (este == ultimoAberto)
        {
            v1.enabled = true;
            v2.enabled = true;
        }
        else
        {

            v1.enabled = false;
            v2.enabled = false;
        }
	}

    
}
