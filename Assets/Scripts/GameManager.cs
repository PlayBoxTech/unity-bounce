using UnityEngine;
// using UnityEngine.UI;
using TMPro;
using System;


public class GameManager : MonoBehaviour
{
   public static GameManager instance; // Static instance variable
   [SerializeField] private TextMeshProUGUI score; // Reference to the TextMeshPro UGUI component
   [SerializeField] private GameObject ball; // Reference to the ball game object
   [SerializeField] private GameObject player; // Reference to the player game object


   private void Start()
{
    // Find all objects with the tag "Ground"
    GameObject[] groundObjects = GameObject.FindGameObjectsWithTag("Ground");

    foreach (GameObject groundObject in groundObjects)
    {
        // Check if the object has the GroundCollision script attached
        GroundCollision groundCollision = groundObject.GetComponent<GroundCollision>();

        if (groundCollision != null)
        {
            // Subscribe to the GroundCollisionEvent of this specific object
            groundCollision.OnGroundCollision += HandleGroundCollision;
        }
        else
        {
            // Log a warning if the object doesn't have the GroundCollision script
            Debug.LogWarning("GameObject tagged 'Ground' does not have GroundCollision script attached: " + groundObject.name);
        }
    }
}

    private void HandleGroundCollision(string collidedObjectName)
    {
        // Implement logic to handle the collision event here
        Debug.Log("GameManager received GroundCollision: " + collidedObjectName);

        // You can perform actions based on the collided object's name
        // or take other actions needed for the game
    }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject); // Destroy duplicate if it exists
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Persist across scenes
        }
    }

public void OnBallHitPaddle(int currentCount)
{
    if (score != null)
    {
        // Get the Text component from the GameObject
        TextMeshProUGUI scoreText = score.GetComponent<TextMeshProUGUI>();
        if (scoreText != null)
        {
            // Update the text content using 'text' property
            scoreText.text = "Score: " + currentCount;
            if (currentCount % 5 == 0)
            {
                IncreaseBallGravity();
            }
            if (currentCount % 10 == 0)
            {
                LowerPlayerMoveSpeed();
            }
        }
        else
        {
            Debug.LogError("Score Text component not found on GameObject!");
        }
    }
    else
    {
        Debug.LogError("Score GameObject reference not set in Inspector!");
    }
}

    public void IncreaseBallGravity() // Example function name
    {
        if (ball != null) // Check if the reference is set
        {
            // Get the Rigidbody2D and CircleCollider2D components from the Ball GameObject
            Rigidbody2D ballRigidbody = ball.GetComponent<Rigidbody2D>();
            CircleCollider2D ballCollider = ball.GetComponent<CircleCollider2D>();

            if (ballRigidbody != null) // Check if Rigidbody2D component exists
            {
                // Modify gravity as before
                float currentGravity = ballRigidbody.gravityScale;
                currentGravity+= 0.5f;
                ballRigidbody.gravityScale = currentGravity;
            }
            else
            {
                Debug.LogError("Rigidbody2D component not found on Ball GameObject!");
            }

            
        }
        else
        {
            Debug.LogError("Ball GameObject reference not set in Inspector!");
        }
    }

    public void LowerPlayerMoveSpeed()
    {
        if (player != null)
        {
            player.GetComponent<PlayerMovement>().moveSpeed -= 0.5f;
        }
    }


}

