using UnityEngine;
namespace Game.AI
{
    public class NPCSPAWNER : MonoBehaviour
    {
        [SerializeField]
        public NPC npc;
        [SerializeField]
        public Arrea Arrea;
        [SerializeField]
        public int menyi = 3;

        private void Start()
        {
            for (int i = 0; i < menyi; i++)
            {
                Vector3 posi = Arrea.gatrandompoin();
                Quaternion rot = Quaternion.Euler(0, Random.Range(0, 360), 0);
                NPC newnpc = Instantiate(npc, posi, rot );
                newnpc.GetComponent<Járkál>().area = Arrea;
            }   
        }
    }
}