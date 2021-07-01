using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public Transform[] wayPoints;
    Transform playerTrm;
    NavMeshAgent enemyAgent;
    public float enemySpeed;
    public float chaseSpeed;
    public float sightRange;
    public int destPoint = 0;
    public bool bPlayerInSightRange;
    public LayerMask whatIsPlayer;

    private EnemyFov enemyFov;

    private void Awake()
    {

        enemyAgent = GetComponent<NavMeshAgent>();
        enemyFov = GetComponent<EnemyFov>(); 

    }
    void Start()
    {
        playerTrm = GameObject.Find("Player").transform;
        if (enemyAgent != null)
        {
            enemyAgent.autoBraking = false;
            Patrolling();
        }

    }

    // Update is called once per frame
    void Update()
    {
        bPlayerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);

        if (bPlayerInSightRange)
        {
            ChasePlayer();
        }
        if (!enemyAgent.pathPending && enemyAgent.remainingDistance <= 1f)
        {


            if (bPlayerInSightRange)
            {
                ChasePlayer();
            }
            Patrolling();

        }

    }
    void Patrolling()
    {

        enemyAgent.destination = wayPoints[destPoint].position;


        destPoint = (destPoint + 1) % wayPoints.Length;
    }

    void ChasePlayer()
    {
        transform.LookAt(playerTrm);
        enemyAgent.autoBraking = false;
        enemyAgent.SetDestination(playerTrm.position);


        if (!bPlayerInSightRange)
        {
            Patrolling();
        }

    }
    //IEnumerator CheckState()
    //{
    //    yield return new WaitForSeconds(1.0f);
    //}
}