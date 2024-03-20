using UnityEngine;

public class GroundCollision : MonoBehaviour
{
    public delegate void GroundCollisionEvent(string collidedObjectName);

    public GroundCollisionEvent OnGroundCollision;

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the colliding object has a Rigidbody2D component
        if (other.TryGetComponent<Rigidbody2D>(out Rigidbody2D rb))
        {
            // Do something when collision happens, 
            // for example, print a message to the console
            // Debug.Log("Ground collided with: " + other.name);
            OnGroundCollision?.Invoke(other.name);

            // You can access the colliding object's properties here
            // like its velocity, position, etc.
            // rb.velocity;
        }
    }
}
