using UnityEngine;
using System.Collections;

public class Amenizador : MonoBehaviour {

    public bool gatilho;
	// Use this for initialization
	void Start () {
        gatilho = false;
	}
    void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Virgin")||other.gameObject.CompareTag("Old")
            || other.gameObject.CompareTag("Player"))
        {
            gatilho = true;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Virgin") || other.gameObject.CompareTag("Old")
            || other.gameObject.CompareTag("Player"))
        {
            gatilho = false;
        }
    }
}
