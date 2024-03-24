using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float chaseRange = 5f;
    [SerializeField] float turnSpeed = 5f;

    NavMeshAgent navMeshAgent;
    float distanceToTarget = Mathf.Infinity;
    bool isProvoked = false;
    EnemyHealth health;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        health = GetComponent<EnemyHealth>();
    }

    void Update()
    {
        if(health.IsDead())
        {
            enabled = false;
            navMeshAgent.enabled = false;
            return;
        }

        distanceToTarget = Vector3.Distance(target.position, transform.position);
        if(isProvoked)
        {             
            EngageTarget();
        }
        else if(distanceToTarget <= chaseRange)
        {
            isProvoked = true;
        }
    }

    public void OnDamageTaken()
    {
        isProvoked = true;
    }

    void EngageTarget()
    {
        FaceTarget();
        if (distanceToTarget > navMeshAgent.stoppingDistance)
        {
            ChaseTarget();            
        }

        if(distanceToTarget <= navMeshAgent.stoppingDistance)
        {
            AttackTarget();
        }     
    }

    void ChaseTarget()
    {
        GetComponent<Animator>().SetBool("attack", false);
        GetComponent<Animator>().SetTrigger("move");
        navMeshAgent.SetDestination(target.position);
    }

    void AttackTarget()
    {
        GetComponent<Animator>().SetBool("attack", true);
    }

    private void FaceTarget()
    {        
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));

        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }
}
