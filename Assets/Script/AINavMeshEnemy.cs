using UnityEngine;
using UnityEngine.AI;

public class AINavMeshEnemy : MonoBehaviour
{
    [SerializeField]private Transform player_transform;
    private NavMeshAgent agent;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if(player_transform != null)
        {
            agent.SetDestination(player_transform.position);
        }
    }
}
