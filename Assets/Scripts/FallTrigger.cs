using UnityEngine;
using UnityEngine.Events;

public class FallTrigger : MonoBehaviour
{
    public UnityEvent onPinFall = new();
    public bool isPinFallen = false;

    private void OnTriggerEnter(Collider triggeredObject)
    {
        if (triggeredObject.CompareTag("Ground") && !isPinFallen)
        {
            isPinFallen = true;
            onPinFall?.Invoke();
            Debug.Log($"{gameObject.name} is fallen");
        }
    }
}
