using UnityEngine;

public class FlashlightDetector : MonoBehaviour
{
    private bool seeingStatue = false;

    public bool IsSeeingStatue => seeingStatue;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Statue"))
            seeingStatue = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Statue"))
            seeingStatue = false;
    }
}
