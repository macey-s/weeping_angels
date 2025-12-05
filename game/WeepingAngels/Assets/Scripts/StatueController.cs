using UnityEngine;
using UnityEngine.AI;

public class StatueController : MonoBehaviour
{
    public Transform player;
    public NavMeshAgent agent;
    public float stepInterval = 2f;   // time between jumps
    public float stepDistance = 1f;   // length of each jump

    bool isFrozen = false;
    float stepTimer = 0f;

    void Start()
    {
        if (agent != null)
            agent.updatePosition = false;  // we control movement manually
    }

    void Update()
    {
        if (isFrozen)
        {
            agent.isStopped = true;
            return;
        }

        // Timer logic for choppy movement
        stepTimer += Time.deltaTime;

        if (stepTimer >= stepInterval)
        {
            stepTimer = 0f;

            // Move in a single "jump" toward the player
            Vector3 direction = (player.position - transform.position).normalized;
            Vector3 destination = transform.position + (direction * stepDistance);

            agent.Warp(destination);  // instant teleport
        }
    }

    public void SetFrozen(bool value)
    {
        isFrozen = value;

        if (isFrozen)
        {
            agent.isStopped = true;
        }
        else
        {
            agent.isStopped = false;
        }
    }
}
