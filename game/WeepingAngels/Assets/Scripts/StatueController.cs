using UnityEngine;
using UnityEngine.AI;

public class StatueController : MonoBehaviour
{
    [Header("References")]
    public Transform player;
    public NavMeshAgent agent;
<<<<<<< Updated upstream
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
>>>>>>> Stashed changes

    void Start()
    {
        if (agent != null)
<<<<<<< Updated upstream
            agent.updatePosition = false;  // we control movement manually
=======
<<<<<<< Updated upstream
            agent.updatePosition = false;  // We manually control movement
=======
        {
            agent.updatePosition = true;
        }
>>>>>>> Stashed changes
>>>>>>> Stashed changes
    }

    void Update()
    {
<<<<<<< Updated upstream
        if (isFrozen)
        {
            agent.isStopped = true;
            return;
        }

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

<<<<<<< Updated upstream
        // ----------------------------------------------------
        // CHOPPY MOVEMENT LOGIC
        // ----------------------------------------------------
=======
        // movement
>>>>>>> Stashed changes
>>>>>>> Stashed changes
        stepTimer += Time.deltaTime;

        if (stepTimer >= stepInterval)
        {
            stepTimer = 0f;

            // Move in a single "jump" toward the player
            Vector3 direction = (player.position - transform.position).normalized;
            Vector3 targetPosition = transform.position + direction * stepDistance;

<<<<<<< Updated upstream
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
