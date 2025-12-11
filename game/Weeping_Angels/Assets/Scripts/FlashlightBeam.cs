using UnityEngine;

public class FlashlightBeam : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Statue"))
        {
            var statue = other.GetComponent<StatueController>();
            if (statue != null)
                statue.SetFrozen(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Statue"))
        {
            var statue = other.GetComponent<StatueController>();
            if (statue != null)
                statue.SetFrozen(false);
        }
    }
}
