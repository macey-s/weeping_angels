using UnityEngine;
using UnityEngine.AI;

public class StatueController : MonoBehaviour
{
    [Header("References")]
    public Transform player;
    public NavMeshAgent agent;
<<<<<<< Updated upstream
<<<<<<< HEAD
    public FlashlightDetector flashlight;   // <--- CONNECT THIS IN THE INSPECTOR

    public float stepInterval = 2f;   // time between jumps
    public float stepDistance = 1f;   // distance per jump

=======
=======
<<<<<<< Updated upstream
    public FlashlightDetector flashlight;   // <--- CONNECT THIS IN THE INSPECTOR

>>>>>>> Stashed changes
    public float stepInterval = 2f;   // time between jumps
    public float stepDistance = 1f;   // length of each jump

<<<<<<< Updated upstream
    bool isFrozen = false;
    float stepTimer = 0f;
=======
>>>>>>> main
    private float stepTimer = 0f;
=======

    [Header("Movement Settings")]
    public float stepInterval = 2f;
    public float stepDistance = 2f;

    [Header("Light Reaction Settings")]
    public float postLightCooldown = 1.5f; // how long after leaving the light before moving again

    private bool isFrozen = false;
    private float stepTimer = 0f;
    private float cooldownTimer = 0f;
>>>>>>> Stashed changes
<<<<<<< HEAD
=======
>>>>>>> Stashed changes
>>>>>>> main

    void Start()
    {
        if (agent != null)
<<<<<<< Updated upstream
<<<<<<< HEAD
=======
            agent.updatePosition = false;  // we control movement manually
=======
<<<<<<< Updated upstream
>>>>>>> main
            agent.updatePosition = false;  // We manually control movement
=======
        {
            agent.updatePosition = true;
        }
>>>>>>> Stashed changes
<<<<<<< HEAD
=======
>>>>>>> Stashed changes
>>>>>>> main
    }

    void Update()
    {
<<<<<<< Updated upstream
<<<<<<< HEAD
        // ----------------------------------------------------
        // FREEZE LOGIC — statue is in the flashlight cone
        // ----------------------------------------------------
        if (flashlight != null && flashlight.IsSeeingStatue)
=======
        if (isFrozen)
>>>>>>> main
        {
            agent.isStopped = true;
            return;   // stop all movement
        }
        else
        {
            agent.isStopped = false;
=======
        // do nothing
        if (isFrozen || cooldownTimer > 0f)
        {
            if (!isFrozen)
                cooldownTimer -= Time.deltaTime;

            if (agent != null)
                agent.isStopped = true;

            return;
>>>>>>> Stashed changes
        }
        else
        {
            if (agent != null)
                agent.isStopped = false;
        }

<<<<<<< HEAD
=======
        // Timer logic for choppy movement
=======
<<<<<<< Updated upstream
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
=======
        // do nothing
        if (isFrozen || cooldownTimer > 0f)
        {
            if (!isFrozen)
                cooldownTimer -= Time.deltaTime;

            if (agent != null)
                agent.isStopped = true;

            return;
>>>>>>> Stashed changes
        }
        else
        {
            if (agent != null)
                agent.isStopped = false;
        }

>>>>>>> main
<<<<<<< Updated upstream
        // ----------------------------------------------------
        // CHOPPY MOVEMENT LOGIC
        // ----------------------------------------------------
=======
        // movement
>>>>>>> Stashed changes
<<<<<<< HEAD
=======
>>>>>>> Stashed changes
>>>>>>> main
        stepTimer += Time.deltaTime;

        if (stepTimer >= stepInterval)
        {
            stepTimer = 0f;

            Vector3 direction = (player.position - transform.position).normalized;
            Vector3 targetPosition = transform.position + direction * stepDistance;

<<<<<<< Updated upstream
<<<<<<< HEAD
            agent.Warp(destination); // instant "jump"
        }
=======
            if (NavMesh.SamplePosition(targetPosition, out NavMeshHit hit, 1.0f, NavMesh.AllAreas))
            {
                agent.Warp(hit.position);
            }
=======
            agent.Warp(destination);  // instant teleport
>>>>>>> main
        }
    }

    public void SetFrozen(bool value)
    {
        // if just unfrozen > start cooldown
        if (isFrozen && !value)
        {
            cooldownTimer = postLightCooldown;
        }

        isFrozen = value;

<<<<<<< HEAD
        if (agent != null)
            agent.isStopped = value;
>>>>>>> Stashed changes
=======
        if (isFrozen)
        {
            agent.isStopped = true;
        }
        else
        {
            agent.isStopped = false;
=======
<<<<<<< Updated upstream
            agent.Warp(destination); // instant "jump"
>>>>>>> Stashed changes
        }
=======
            if (NavMesh.SamplePosition(targetPosition, out NavMeshHit hit, 1.0f, NavMesh.AllAreas))
            {
                agent.Warp(hit.position);
            }
        }
>>>>>>> main
    }

    public void SetFrozen(bool value)
    {
        // if just unfrozen > start cooldown
        if (isFrozen && !value)
        {
            cooldownTimer = postLightCooldown;
        }

        isFrozen = value;

        if (agent != null)
            agent.isStopped = value;
>>>>>>> Stashed changes
    }
}
