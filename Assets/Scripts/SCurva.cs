using UnityEngine;
using System.Collections;

public class SCurva : MonoBehaviour {
    public int inclinacao;
    public int este;
	// Use this for initialization
	void Start () {
	
	}

    void OnTriggerExit2D(Collider2D outro)
    {
        if (outro.gameObject.CompareTag("Virgin") || outro.gameObject.CompareTag("Old"))
        {
            MotoristaAutomatico motorista = 
                outro.gameObject.GetComponent<MotoristaAutomatico>();
            if (motorista.proximaCurva == este)
            {
                Rigidbody2D rb =
                    outro.gameObject.GetComponent<Rigidbody2D>();
                rb.velocity = new Vector2(0, 0);
                rb.transform.Rotate(rb.transform.forward, inclinacao);
            }
        }
    }
}
