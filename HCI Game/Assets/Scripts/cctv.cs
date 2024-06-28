using UnityEngine;
using UnityEngine.SceneManagement;

public class CCTVCamera : MonoBehaviour
{
    public Transform player; // Reference to the player
    public float detectionRange = 10f; // Detection range of the CCTV
    public LayerMask detectionLayer; // Layer for detecting the player
    public float detectionAngle = 60f; // Detection angle of the CCTV
    public bool over = false;
    public void gameover()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3);

        over = false;
    }
    void Update()
    {
        DetectPlayer();
    }

    void DetectPlayer()
    {
        Vector3 directionToPlayer = player.position - transform.position;
        float distanceToPlayer = directionToPlayer.magnitude;

        // Check if player is within detection range
        if (distanceToPlayer <= detectionRange)
        {
            // Check if player is within detection angle
            float angleToPlayer = Vector3.Angle(transform.forward, directionToPlayer);

            if (angleToPlayer <= detectionAngle / 2f)
            {
                // Perform a raycast to check if the player is in line of sight
                RaycastHit hit;
                if (Physics.Raycast(transform.position, directionToPlayer, out hit, detectionRange, detectionLayer))
                {
                    if (hit.transform.CompareTag("Player"))
                    {
                        KillPlayer();
                    }
                }
            }
        }
    }

    void KillPlayer()
    {
        // Add logic to kill the player
        Debug.Log("Player detected and killed!");
        // Example: Destroy the player GameObject
        Destroy(player.gameObject);
        // Or trigger a game over screen, reduce player health, etc.
        over = true;
        gameover();

    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Vector3 rightLimit = Quaternion.Euler(0, detectionAngle / 2f, 0) * transform.forward * detectionRange;
        Vector3 leftLimit = Quaternion.Euler(0, -detectionAngle / 2f, 0) * transform.forward * detectionRange;

        Gizmos.DrawLine(transform.position, transform.position + rightLimit);
        Gizmos.DrawLine(transform.position, transform.position + leftLimit);
        Gizmos.DrawWireSphere(transform.position, detectionRange);
    }

}
