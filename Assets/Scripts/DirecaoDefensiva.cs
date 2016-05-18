using UnityEngine;
using System.Collections;

public class DirecaoDefensiva : MonoBehaviour {
    public GameObject carro;
    private Rigidbody2D rb;
    // Use this for initialization
    void Start () {
        rb = carro.GetComponent<Rigidbody2D>();
	}

    void OnTriggerStay2D(Collider2D outro)
    {
        if (!(outro.CompareTag("Virador")||outro.CompareTag("Pizza")))
        {
            rb.velocity = new Vector2(0, 0);
        }
        
    }
}
