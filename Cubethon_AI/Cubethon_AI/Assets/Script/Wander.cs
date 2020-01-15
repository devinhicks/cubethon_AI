using UnityEngine;

// Define steering variables
public class KinematicSteeringOutput
{
    public Vector3 velocity;
    public Vector3 rotation;
}

public class Wander : MonoBehaviour
{
    public float maxSpeed = 3f;
    public float maxRotation = 1f; // limits degrees in which character can turn

    void Update()
    {
        // Get new velocity and rotation based on target position
        KinematicSteeringOutput newSteering = GetSteering();

        transform.position += newSteering.velocity * Time.deltaTime;
        transform.eulerAngles = newSteering.rotation;
    }

    public KinematicSteeringOutput GetSteering()
    {
        KinematicSteeringOutput result = new KinematicSteeringOutput();

        float angle;

        // Get velocity from vector form of the orientation
        result.velocity = maxSpeed * transform.position;

        // Change orientataion randomly
        angle = RandomBinomial() * maxRotation;

        result.rotation = new Vector3(0, angle, 0);
        return result;
    }

    float RandomBinomial()
    {
        return Random.Range(0, 1) - Random.Range(0, 1);
    }
}
