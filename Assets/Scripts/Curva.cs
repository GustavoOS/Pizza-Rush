using UnityEngine;
using System.Collections;


public class Curva : MonoBehaviour {
    public int inclinacao;
	// Use this for initialization
	void Start () {
	
	}

    void OnTriggerExit2D(Collider2D outro)
    {
        if (outro.gameObject.CompareTag("Virgin") || outro.gameObject.CompareTag("Old"))
        {
            Rigidbody2D rb =
            outro.gameObject.GetComponent<Rigidbody2D>();
            rb.velocity = new Vector2(0, 0);
            rb.transform.Rotate(rb.transform.forward, inclinacao);
        }
    }
}
