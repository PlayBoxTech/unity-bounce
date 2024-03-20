using UnityEngine;

public class BallCollision : MonoBehaviour
{
    private int collisionCount = 0; // Variable to store collision count

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the colliding object has the tag "Player"
        if (collision.gameObject.tag == "Player")
        {
            collisionCount++; // Increment collision count
            // Debug.Log("Ball hit paddle! Collision count: " + collisionCount);
            GameManager.instance?.OnBallHitPaddle(collisionCount); // Assuming a GameManager singleton

            // You can add additional logic here like playing a sound effect or triggering an animation
        }
    }
}
