using UnityEngine;
using UnityEngine.Events;

public class BallController : MonoBehaviour
{
    [SerializeField] private float force = 20f;
    [SerializeField] private InputManager inputManager;
    private Rigidbody ballRB;
    private bool isBallLaunched = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // grab reference to RigidBody
        ballRB = GetComponent<Rigidbody>();

        // add listener to onSpacePressed event
        // if triggered calls LaunchBall
        inputManager.onSpacePressed.AddListener(call: LaunchBall);
    }

    public void LaunchBall()
    {
        if (isBallLaunched) return;
        isBallLaunched = true;
        ballRB.AddForce(transform.forward * force, ForceMode.Impulse);
    }
}
