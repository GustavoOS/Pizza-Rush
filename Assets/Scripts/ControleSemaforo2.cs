using UnityEngine;
using System.Collections;

public class ControleSemaforo2 : MonoBehaviour
{
    public int max;

    public GameObject Rua1;
    public GameObject Rua2;
    public GameObject Rua3;

    public GameObject Semaphore1;
    public GameObject Semaphore2;
    public GameObject Semaphore3;

    public GameObject Amenizador1;
    public GameObject Amenizador2;
    public GameObject Amenizador3;

    private Amenizador[] Amenizadores = new Amenizador[3];
    private SemaforoControlado[] Semaforos = new SemaforoControlado[3];
    private CarStreetDetection[] Ruas = new CarStreetDetection[3];
    public int[] Qtd = new int[3];

    public int MAX;

    //Semáforos do Controlador. Não aparecem no jogo, mas garantem o sincronismo do controlador
    private bool semaforoaoquadrado = false;
    public bool semaforoDoControlador = false;

    public GameObject DispositivoAleatorio;
    private Aleatorio meuDispositivo;



    // Use this for initialization
    void Start()
    {

        meuDispositivo = DispositivoAleatorio.GetComponent<Aleatorio>();

        Ruas[0] = Rua1.GetComponent<CarStreetDetection>();
        Ruas[1] = Rua2.GetComponent<CarStreetDetection>();
        Ruas[2] = Rua3.GetComponent<CarStreetDetection>();

        Semaforos[0] = Semaphore1.GetComponent<SemaforoControlado>();
        Semaforos[0].este = 0;
        Semaforos[1] = Semaphore2.GetComponent<SemaforoControlado>();
        Semaforos[1].este = 1;
        Semaforos[2] = Semaphore3.GetComponent<SemaforoControlado>();
        Semaforos[2].este = 2;

        Amenizadores[0] = Amenizador1.GetComponent<Amenizador>();
        Amenizadores[1] = Amenizador2.GetComponent<Amenizador>();
        Amenizadores[2] = Amenizador3.GetComponent<Amenizador>();
    }


    void OnTriggerStay2D(Collider2D other)
    {
        if (!other.CompareTag("Virador"))
        {
            foreach (SemaforoControlado sem in Semaforos)
            {
                sem.isVerde = false;
                semaforoaoquadrado = true;
            }
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (!other.CompareTag("Virador"))
        {
            semaforoaoquadrado = false;
            semaforoDoControlador = false;
        }
    }



    // Update is called once per frame
    void Update()
    {
        atualiza();
        if (!semaforoDoControlador)
        {
            for (int i = 0; i < 3; i++)
            {
                if (i == MAX && !semaforoaoquadrado)
                {
                    Semaforos[i].isVerde = true;
                    foreach (SemaforoControlado sem in Semaforos)
                    {
                        sem.ultimoAberto = i;
                    }
                }
                else
                {
                    Semaforos[i].isVerde = false;
                }
            }
        }
    }
    void atualiza()
    {
        int cont = 0;
        for (int i = 0; i < 3; i++)
        {
            if (Amenizadores[i].gatilho)
            {
                semaforoDoControlador = true;
            }
            else
            {
                cont++;
            }
            Qtd[i] = Ruas[i].numeroDeCarros;
            MAX = RuaMaisCheia();
            //Debug
            max = Qtd[MAX];

        }
        if (cont == 3)
        {
            semaforoDoControlador = false;
        }
    }
    int RuaMaisCheia()
    {
        int aux = 0;
        for (int i = 1; i < 3; i++)
        {
            if (Qtd[i] > Qtd[aux])
            {
                aux = i;
            }
        }
        return aux;
    }
    public int atualizanum()
    {

        return meuDispositivo.aleatorio[1];
       
    }
}
