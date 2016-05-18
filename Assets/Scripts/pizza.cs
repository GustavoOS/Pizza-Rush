using UnityEngine;
using System.Collections;

public class pizza : MonoBehaviour {
    public int destino;
    public bool Entregue;
    public float tempoDestruicao;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (!Entregue)
        {
            Roda(100);
        }
        else
        {
            Roda(-500);
            Destroy(gameObject, tempoDestruicao);
        }
	}

    void Roda(int speed)
    {
        gameObject.transform.Rotate(new Vector3(0,0,speed) * Time.deltaTime);
    }
}
