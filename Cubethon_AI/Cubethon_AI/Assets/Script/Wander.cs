using UnityEngine;

public class Wander : MonoBehaviour
{
    public Vector3 lookHere;
    public float maxSpeed = 3f;
    public float maxRotation = 15f; // limits degrees in which character can turn
    private int delay = 0;

    void Update()
    {
        //KinematicSteeringOutput newSteering = GetSteering();
        transform.position += transform.TransformDirection(Vector3.forward)
            * maxSpeed * Time.deltaTime;

        if (delay == 50)
        {
            WanderAbout();
            delay = 0;
        }
        else
        {
            delay++;
        }
    }

    void WanderAbout()
    {
        float x = RandomBinomial() * maxRotation;
        float z = RandomBinomial() * maxRotation;

        lookHere = new Vector3(x, 1.0f, z);

        transform.LookAt(lookHere);
    }

    float RandomBinomial()
    {
        return Random.Range(0.0f, 1.0f) - Random.Range(0.0f, 1.0f);
    }
}