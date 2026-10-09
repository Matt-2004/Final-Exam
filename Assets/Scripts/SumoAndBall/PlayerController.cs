using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerController : MonoBehaviour
{
    public bool hasPowerup;
    public GameObject powerupIndicator;
    private GameObject focalPoint;
    private Rigidbody playerRb;
    public float speed = 5.0f;
    private float powerupStrength = 5.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
    }

    // Update is called once per frame
    void Update()
    {
        if (focalPoint == null || playerRb == null) return;
        float forwardInput = Input.GetAxis("Vertical");
        playerRb.AddForce(focalPoint.transform.forward * speed * forwardInput);
        if (powerupIndicator != null) powerupIndicator.transform.position = transform.position + new Vector3(0, -0.5f, 0);
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PlayerPrefs.SetString(
                "PreviousScene",
                SceneManager.GetActiveScene().name
            );

            SceneManager.LoadScene("InGameMenu");
        }
    }

    private void OnTriggerEnter(Collider other) {
    if (other.CompareTag("Powerup")) {
        hasPowerup = true;
        Destroy(other.gameObject);
        StartCoroutine(PowerupCountdownRoutine()); 
        if (powerupIndicator != null) powerupIndicator.SetActive(true);
    } }

    IEnumerator PowerupCountdownRoutine() {
        yield return new WaitForSeconds(7); hasPowerup = false; 
        if (powerupIndicator != null) powerupIndicator.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy") && hasPowerup)
        {
            Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = (collision.gameObject.transform.position - transform.position).normalized;
            
            Debug.Log("Player collided with " + collision.gameObject + " with powerup set to " + hasPowerup);
            if (enemyRigidbody != null)
            {
                enemyRigidbody.AddForce(awayFromPlayer * powerupStrength, ForceMode.Impulse);
            }
        }        
    }
}
