using UnityEngine;
using UnityEngine.AI;

public class StatueController : MonoBehaviour
{
    public Transform player;
    public NavMeshAgent agent;
    public FlashlightDetector flashlight;   // <--- CONNECT THIS IN THE INSPECTOR

    public float stepInterval = 2f;   // time between jumps
    public float stepDistance = 1f;   // distance per jump

    private float stepTimer = 0f;

    void Start()
    {
        if (agent != null)
            agent.updatePosition = false;  // We manually control movement
    }

    void Update()
    {
        // ----------------------------------------------------
        // FREEZE LOGIC — statue is in the flashlight cone
        // ----------------------------------------------------
        if (flashlight != null && flashlight.IsSeeingStatue)
        {
            agent.isStopped = true;
            return;   // stop all movement
        }
        else
        {
            agent.isStopped = false;
        }

        // ----------------------------------------------------
        // CHOPPY MOVEMENT LOGIC
        // ----------------------------------------------------
        stepTimer += Time.deltaTime;

        if (stepTimer >= stepInterval)
        {
            stepTimer = 0f;

            Vector3 direction = (player.position - transform.position).normalized;
            Vector3 destination = transform.position + (direction * stepDistance);

            agent.Warp(destination); // instant "jump"
        }
    }
}
