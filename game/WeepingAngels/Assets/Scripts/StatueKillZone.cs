using UnityEngine;

public class StatueKillZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerDeath.Instance.Die(transform);
        }
    }
}
