using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    public static PlayerDeath Instance;

    public Transform playerCamera;
    public GameObject deathUI;
    public float lookSpeed = 5f;

    private bool isDead = false;
    private Transform killerStatue;

    private void Awake()
    {
        Instance = this;
    }

    void Update()
    {
        if (!isDead || killerStatue == null) return;

        // rotate camera toward statue
        Vector3 dir = (killerStatue.position - playerCamera.position).normalized;
        Quaternion targetRot = Quaternion.LookRotation(dir);

        playerCamera.rotation = Quaternion.Slerp(
            playerCamera.rotation,
            targetRot,
            Time.deltaTime * lookSpeed
        );
    }

    public void Die(Transform statue)
    {
        if (isDead) return;

        isDead = true;
        killerStatue = statue;

        GetComponent<PlayerMovements>().enabled = false;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        deathUI.SetActive(true);

        Time.timeScale = 0.2f;
    }
}
