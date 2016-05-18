using UnityEngine;
using System.Collections;

public class CarStreetDetection : MonoBehaviour {
    public int numeroDeCarros;
    public bool tem4Ruas;
    public GameObject Central;
    public int numeroAleatorio;

    private ControleSemaforo1 Central1;
    private ControleSemaforo2 Central2;
	// Use this for initialization
	void Start () {
        switch (tem4Ruas)
        {
            case true:
                    Central1=Central.GetComponent<ControleSemaforo1>();
                    break;
            case false:
                Central2=Central.GetComponent<ControleSemaforo2>();
                break;
            default:
                break;
        }
	}
	
	// Update is called once per frame
	void Update () {
        
	}
    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Untagged"))
        {
            numeroDeCarros++;
        }
        
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (!other.CompareTag("Untagged"))
        {
            numeroDeCarros--;
        }
        
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Virgin") || other.CompareTag("Old"))
        {
            MotoristaAutomatico motorista = other.gameObject.GetComponent<MotoristaAutomatico>();
            atualizanum();
            motorista.proximaCurva = numeroAleatorio;
        }
    }
    void atualizanum()
    {
        if (tem4Ruas)
        {
            numeroAleatorio=Central1.atualizanum();
        }
        else
        {
            numeroAleatorio = Central2.atualizanum();
        }
    }
}
