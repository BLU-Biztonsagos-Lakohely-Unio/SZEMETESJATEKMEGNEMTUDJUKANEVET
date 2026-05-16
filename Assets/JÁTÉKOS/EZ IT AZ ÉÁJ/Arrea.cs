using UnityEngine;
using UnityEngine.AI;


public class Arrea : MonoBehaviour
{
    public float Radius = 20f;

    public void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, Radius);
    }
    public Vector3 gatrandompoin()
    {
        Vector3 randomDirection = Random.insideUnitSphere * Radius;
        randomDirection.y = 2;

        Vector3 ranpoint = transform.position + randomDirection;

        NavMeshHit hit;
        Vector3 finalPosition = transform.position;

        if (NavMesh.SamplePosition(ranpoint, out hit, 2f, 1)) { 
            finalPosition = hit.position;
        }
        return finalPosition;
    }
}
