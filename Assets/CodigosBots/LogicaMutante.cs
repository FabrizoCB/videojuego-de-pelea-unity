using UnityEngine;
using UnityEngine.AI;

public class LogicaMutante : MonoBehaviour
{
    public float rangoDeteccion = 5f;
    public float rangoAtaque = 2f;
    public float tiempoCambioDireccion = 3f;

    private Animator anim;
    private NavMeshAgent agente;
    private GameObject personaje;
    private float tiempoProximoMovimiento;
    private Vector3 destinoAleatorio;

    void Start()
    {
        anim = GetComponent<Animator>();
        agente = GetComponent<NavMeshAgent>();
        personaje = GameObject.FindGameObjectWithTag("jugador");
        tiempoProximoMovimiento = Time.time + tiempoCambioDireccion;
    }

    void Update()
    {
        //  Verifica si el agente está sobre el NavMesh antes de todo
        if (agente == null || !agente.isOnNavMesh)
        {
            Debug.LogWarning("El mutante no está sobre el NavMesh.");
            return;
        }

        float distancia = Vector3.Distance(transform.position, personaje.transform.position);
        anim.SetFloat("distanciaJugador", distancia);

        if (distancia <= rangoAtaque)
        {
            agente.SetDestination(transform.position); // se detiene
            transform.LookAt(personaje.transform);
            anim.SetTrigger("golpear");
            anim.SetFloat("velocidad", 0f);
        }
        else if (distancia <= rangoDeteccion)
        {
            agente.SetDestination(personaje.transform.position);
            anim.SetFloat("velocidad", agente.velocity.magnitude);
        }
        else
        {
            //  Verifica que el agente esté en el NavMesh antes de usar remainingDistance
            if (Time.time >= tiempoProximoMovimiento ||
                (!agente.pathPending && agente.remainingDistance < 0.5f))
            {
                Vector3 nuevaDireccion = Random.insideUnitSphere * 5f;
                nuevaDireccion += transform.position;
                NavMeshHit hit;
                if (NavMesh.SamplePosition(nuevaDireccion, out hit, 5f, NavMesh.AllAreas))
                {
                    agente.SetDestination(hit.position);
                }
                tiempoProximoMovimiento = Time.time + tiempoCambioDireccion;
            }
            anim.SetFloat("velocidad", agente.velocity.magnitude);
        }
    }
}


