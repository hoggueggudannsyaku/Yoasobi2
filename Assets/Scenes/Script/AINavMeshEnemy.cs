using UnityEngine;
using UnityEngine.AI;

public class AINavMeshEnemy : MonoBehaviour
{
    [SerializeField]private GameObject SoundWander;
    [SerializeField]private Transform player_transform;
    [SerializeField]private Transform wander_transform;
    public bool playermiss;
    public float timer;
    private NavMeshAgent agent;
    public Transform agent_target;
    public enum Mode{Chase,Idle,Seach};
    public Mode NowMode = Mode.Idle;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        ChengeMode();
    }
    public void ChengeMode()
    {
        switch (NowMode)
            {
                case Mode.Idle:
                IdleMode();
                break;

                case Mode.Chase:
                ChaseMode();
                break;

                case Mode.Seach:
                SeachMode();
                break;
            }
    }
    private void IdleMode()
    {
        agent.SetDestination(wander_transform.position);
    }
    public void ChaseMode()
    {
        if (!playermiss)
        {
            timer -=Time.deltaTime;
            agent.SetDestination(player_transform.position);
        }
        Debug.Log(timer);
        if(timer < 0)
        {
            timer = 0f;
            playermiss = true;
            NowMode = Mode.Idle;
        }
    }
    private void SeachMode()
    {
        agent.SetDestination(SoundWander.transform.position);
        if(SoundWander.transform.position == this.gameObject.transform.position)
        NowMode = Mode.Idle;    
    }
}
