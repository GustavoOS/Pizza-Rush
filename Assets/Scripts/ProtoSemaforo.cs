using UnityEngine;
using System.Collections;

public class ProtoSemaforo : MonoBehaviour {
    public GameObject esteSemaforo;
    public float Contador;
    public float ContadorVerde;
    private Collider2D estesem;
    private float contadorbackup;
    private float contadorbackupverde;
    public bool IsVerde;
    // Use this for initialization
    void Start()
    {
        estesem=esteSemaforo.GetComponent<Collider2D>();
        contadorbackup = Contador;
        contadorbackupverde = ContadorVerde;
    }

    // Update is called once per frame
    private void trocaEstado()
    {
        estesem.enabled = !estesem.enabled;
        IsVerde = !IsVerde;
    }
    void Update()
    {
        

        switch (IsVerde)
        {
            case false:
                Debug.Log("Verde");
                ContadorVerde -= Time.deltaTime;
                if ((int)ContadorVerde <= 0)
                {
                    trocaEstado();
                    ContadorVerde = contadorbackupverde;
                    
                }
                break;
            case true:
                Contador -= Time.deltaTime;
                if ((int)Contador == 0)
                {
                    trocaEstado();
                    Contador = contadorbackup;
                }
                break;
            default:
                break;
        }

        
    }
}
