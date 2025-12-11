using UnityEngine;
using UnityEngine.AI;

public class StatueController : MonoBehaviour
{
    [Header("References")]
    public Transform player;
    public NavMeshAgent agent;

    [Header("Movement Settings")]
    public float stepInterval = 2f;
    public float stepDistance = 2f;

    [Header("Light Reaction Settings")]
    public float postLightCooldown = 1.5f; // how long after leaving the light before moving again

    private bool isFrozen = false;
    private float stepTimer = 0f;
    private float cooldownTimer = 0f;

    void Start()
    {
        if (agent != null)
        {
            agent.updatePosition = true;
        }
    }

    void Update()
    {
        // ❗ If statue is frozen OR still cooling down after light → do nothing
        if (isFrozen || cooldownTimer > 0f)
        {
            if (!isFrozen)
                cooldownTimer -= Time.deltaTime;

            if (agent != null)
                agent.isStopped = true;

            return;
        }
        else
        {
            if (agent != null)
                agent.isStopped = false;
        }

        // Normal movement logic
        stepTimer += Time.deltaTime;

        if (stepTimer >= stepInterval)
        {
            stepTimer = 0f;

            Vector3 direction = (player.position - transform.position).normalized;
            Vector3 targetPosition = transform.position + direction * stepDistance;

            if (NavMesh.SamplePosition(targetPosition, out NavMeshHit hit, 1.0f, NavMesh.AllAreas))
            {
                agent.Warp(hit.position);
            }
        }
    }

    public void SetFrozen(bool value)
    {
        // If we were frozen and are now unfreezing → start cooldown
        if (isFrozen && !value)
        {
            cooldownTimer = postLightCooldown;
        }

        isFrozen = value;

        if (agent != null)
            agent.isStopped = value;
    }
}
