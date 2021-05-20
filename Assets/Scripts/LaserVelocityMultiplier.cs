using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class LaserVelocityMultiplier : MonoBehaviour
{
    public Rigidbody rb;
    private void Update()
    {
        rb.velocity *= 1.1f;
    }
}
