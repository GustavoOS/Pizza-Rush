using UnityEngine;
using System.Collections;

public class InstanciadorGaragem : MonoBehaviour {
    public GameObject carro;
    public Transform Saida;
    public float Contador;
    private float contadorbackup;
	// Use this for initialization
	void Start () {
        contadorbackup = Contador;
	}
	
	// Update is called once per frame
	void Update () {
        Contador -= Time.deltaTime;
        if ((int)Contador==0) {
        Instantiate(carro,Saida.position,Saida.rotation);
        Contador = contadorbackup;
        }
	}
}
