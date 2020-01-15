using UnityEngine;

public class SeekAndFlee : MonoBehaviour
{
    // Define steering variables
    public class KinematicSteeringOutput
    {
        public Vector3 velocity;
        public Vector3 rotation;
    }

    public float maxSpeed = 10f; // maximum speed of character
    public bool seekOrFlee = false; // whether character is seeking or fleeing

    public Transform target;

    // Arrive variables
    public float searchRadius = 50f; // outside of which the AI won't care
    public float satisfactionRadius = 3f; // radius in which character is satisfied
    public float timeToTarget = 0.25f; // time to target constant

    void Update()
    {
        // Get new velocity and rotation based on target position
        KinematicSteeringOutput newSteering = GetSteering();

        // Apply steering
        if (newSteering != null)
        {
            transform.position += newSteering.velocity * Time.deltaTime;
            transform.eulerAngles = newSteering.rotation;
        }
    }

    public KinematicSteeringOutput GetSteering()
    {
        KinematicSteeringOutput result = new KinematicSteeringOutput();

        float angle;

        // Get the direction to (or away from) the target
        if (seekOrFlee == false) 
        {
            result.velocity = target.position - transform.position;
        }
        else
        {
            result.velocity = transform.position - target.position;
        }


        // Check if target is in search radius
        if (result.velocity.magnitude > searchRadius)
        {
            Debug.Log(this.name + ": Nothing to worry about here");
            return null;
        }

        // Check if we're in satisfaction radius
        if (result.velocity.magnitude < satisfactionRadius)
        {
            return null;
        }

        // Beat the clock!
        result.velocity /= timeToTarget;

        // Velocity is along this direction, at full speed
        result.velocity.Normalize();
        result.velocity *= maxSpeed;

        // Get angle to set character to
        angle = NewOrientation(transform.eulerAngles.y, result.velocity);
        angle *= Mathf.Rad2Deg;

        result.rotation = new Vector3(0, angle, 0);

        return result;
    }

    // Find orientation to set character to (basically just LookAt)
    float NewOrientation(float current, Vector3 velocity)
    {
        if (velocity != Vector3.zero)
        {
            return Mathf.Atan2(velocity.x, velocity.z);
        }

        // if the velocity is zero, return current orientation
        return current;
    }
}
