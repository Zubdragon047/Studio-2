using UnityEngine;
using UnityEngine.Events;

public class BallController : MonoBehaviour
{
    [SerializeField] private float force = 20f;
    [SerializeField] private InputManager inputManager;
    [SerializeField] private Transform ballAnchor;
    [SerializeField] private Transform launchIndicator;
    private Rigidbody ballRB;
    private bool isBallLaunched = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ballRB = GetComponent<Rigidbody>();
        inputManager.onSpacePressed.AddListener(call: LaunchBall);
        
        
        ResetBall();
    }

    public void LaunchBall()
    {
        if (isBallLaunched) return;
        isBallLaunched = true;
        transform.parent = null;
        ballRB.isKinematic = false;
        ballRB.AddForce(launchIndicator.forward * force, ForceMode.Impulse);
        launchIndicator.gameObject.SetActive(false);
    }

    public void ResetBall()
    {
        isBallLaunched = false;
        launchIndicator.gameObject.SetActive(true);
        ballRB.isKinematic = true;
        transform.parent = ballAnchor;
        transform.localPosition = Vector3.zero;
    }
}
