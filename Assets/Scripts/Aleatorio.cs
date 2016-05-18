using UnityEngine;
using System.Collections;

public class Aleatorio : MonoBehaviour {
    public float tempo;
    private float _tempo;
    public int[] aleatorio;
    // Use this for initialization
    void Start()
    {
        aleatorio = new int[2] {0,0};
        _tempo = tempo;
    }

    // Update is called once per frame
    void Update()
    {
        tempo -= Time.deltaTime;
        if (Mathf.RoundToInt(tempo) <= 0)
        {
            aleatorio[0] = Mathf.RoundToInt(Random.Range(0.0f, 2.0f));
            aleatorio[1] = Mathf.RoundToInt(Random.Range(1.0f, 2.0f));
            tempo = _tempo;
        }
    }
}
