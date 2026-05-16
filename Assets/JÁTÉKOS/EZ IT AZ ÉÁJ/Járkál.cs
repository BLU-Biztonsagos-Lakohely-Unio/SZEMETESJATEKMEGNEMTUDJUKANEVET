using Game.AI;
using UnityEngine;


public class Járkál : MonoBehaviour
{
    public Arrea area;
    NPC npc;
    [SerializeField]
    public float MAXwaittime = 3f;
    private float MaxSetaloido = 5f;
    private float waittime = 0f;
    private float Sido = 0f;
    public static bool fStop=false;
    enum EState
    {
        W,
        S
    }
    EState state = EState.W;

    

    private void Awake()
    {
        npc = GetComponentInParent<NPC>();
    }
    private void Start()
    {
        Rdestination();
    }
    void Update()
    {
        if(state == EState.S)
        {
            waittime -= Time.deltaTime;
            if(waittime <= 0)
            {
                STATE_change(EState.W);
            }
        }
        else if(state == EState.W)
        {
            Sido -= Time.deltaTime;
            if (Megékezett() || Sido < 0)
            {
                STATE_change(EState.S);
            }
            
        }
    }
    bool  Megékezett()
    {
        return npc.agent.remainingDistance <= npc.agent.stoppingDistance;
    }

    void Rdestination()
    {
        npc.agent.SetDestination(area.gatrandompoin());
    }
    public void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position, npc.agent.destination);
    }
    public void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, npc.agent.destination);
    }
    void STATE_change(EState newState)
    {
        state = newState;
        if (state == EState.W)
        {
            npc.agent.isStopped = fStop? true : false;
            Sido = MaxSetaloido;
            Rdestination();
            
        }
        else if (state == EState.S)
        {
            waittime = MAXwaittime;
            npc.agent.isStopped = true;
        }
        
    }

    
}
