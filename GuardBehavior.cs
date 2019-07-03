using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class GuardBehavior : MonoBehaviour {

    public GameObject Player;

    public GameObject Guard;
    public float guardSpeed;
    public float rotationSpeed = 2;
    public float waitTime;

    private Collider detectionRadius;
    public int guardState = 0;
    public bool moveState;
    public bool watchState;
    public bool alarmState;
    public bool attackState;
    public bool heardPlayer;
    private bool guardAlive = true;

    public int guardAttack;
    private int guardRange;

    public Transform[] points;
    private int destPoint = 0;
    public NavMeshAgent agentNav;

    void Awake()
    {
        detectionRadius = GetComponent<Collider>();
    }

    // Use this for initialization
    void Start () {
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        GoToNextPoint();
	}

    // Update is called once per frame
    void Update()
    {
        if(!agentNav.pathPending && agentNav.remainingDistance < 0.5f)
        {
            GoToNextPoint();
        }

        if(heardPlayer)
        {
            CheckLineOfSight();
        }
       
    }

    void GoToNextPoint()
    {
        if (points.Length == 0)
        {
            return;
        }
        agentNav.destination = points[destPoint].position;

        destPoint = (destPoint + 1) % points.Length;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            heardPlayer = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            alarmState = false;
            heardPlayer = false;
        }
    }

    //can the guard see the player?
    void CheckLineOfSight()
    {
        RaycastHit sight;
        if (Physics.Raycast(transform.position, (Player.gameObject.transform.position - transform.position).normalized, out sight))
        {
            if (sight.transform.gameObject.CompareTag("Player"))
            {
                alarmState = true;
            }
            else
            {
                alarmState = false;
            }
        }
    }
}
