using UnityEngine;
using UnityEngine.AI;

public class CrawlerAI : MonoBehaviour
{
    public Transform player;              
    public float attackDistance = 2f;     
    public float pounceDistance = 5f;     
    public float crawlFastDistance = 10f; 
    private Animator animator;           
    private NavMeshAgent navMeshAgent;    

    void Start()
    {
        animator = GetComponent<Animator>();
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        animator.SetFloat("distanceToPlayer", distanceToPlayer);


        if (distanceToPlayer > attackDistance)
        {
            navMeshAgent.SetDestination(player.position);
        }
        else
        {
            navMeshAgent.ResetPath(); 
        }
    }
}
