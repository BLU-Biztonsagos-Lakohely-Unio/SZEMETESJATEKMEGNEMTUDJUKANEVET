using UnityEngine;
using UnityEngine.AI;

namespace Game.AI
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class NPC : MonoBehaviour
    {
        public NavMeshAgent agent;

        public float Speed { get { return agent.velocity.magnitude; } }

        public void Awake()
        {
            agent = GetComponent<NavMeshAgent>();
        }
    }
}