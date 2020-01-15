using UnityEngine;

// Define steering variables
public class KinematicSteeringOutput
{
    public Vector3 velocity;
    public Vector3 rotation;
}

public class Wander : MonoBehaviour
{
    public float maxSpeed = 1f;
    public float maxRotation = 15f; // limits degrees in which character can turn
    private int delay = 0;

    void Update()
    {
        KinematicSteeringOutput newSteering = GetSteering();
        transform.position += newSteering.velocity * Time.deltaTime;

        if (delay == 50)
        {
            transform.eulerAngles += newSteering.rotation;
            delay = 0;
        }
        else
        {
            delay++;
        }
    }

    public KinematicSteeringOutput GetSteering()
    {
        KinematicSteeringOutput result = new KinematicSteeringOutput();

        float angle;

        // Get velocity from vector form of the orientation
        result.velocity = maxSpeed * transform.position;

        // Change orientataion randomly
        angle = RandomBinomial() * maxRotation;
        angle *= Mathf.Rad2Deg;

        result.rotation = new Vector3(Mathf.Sin(transform.eulerAngles.y), angle, 
                                      Mathf.Cos(transform.eulerAngles.z));

        return result;
    }

    float RandomBinomial()
    {
        return Random.Range(0.0f, 1.0f) - Random.Range(0.0f, 1.0f);
    }
}


/// speed
/// vector3 for direction
/// x and z floats
/// start wander
/// void wander
///     random x and z values in certain range
///     add to direction vector
///     transform.LookAt(direction)
/// update ()
///     position += transform.TransformDirection * speed * time
///     call wander after certain time or distance