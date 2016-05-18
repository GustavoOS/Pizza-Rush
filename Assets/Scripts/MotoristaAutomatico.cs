using UnityEngine;
using System.Collections;

public class MotoristaAutomatico : MonoBehaviour {
    public int HP;
    public int Velocidade;
    public int VelocidadeMaxima;
    private Rigidbody2D rb;
    public int proximaCurva;


	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
    void Update()
    {
        if (HP <= 0)
        {
            Destroy(transform.gameObject);
        }
    }
	void FixedUpdate () {
        
        if (rb.velocity.magnitude <= VelocidadeMaxima)
        {
            rb.AddForce(Velocidade * rb.transform.up);
        }
        
	}

 
    void OnCollisionStay2D(Collision2D other)
    {
        if (!(other.gameObject.CompareTag("Virador")||other.gameObject.CompareTag("Pizza")||other.gameObject.CompareTag("Semaforo")))
        {
            HP--;
            transform.gameObject.tag = "Old";
        }
        
    }
    

}
