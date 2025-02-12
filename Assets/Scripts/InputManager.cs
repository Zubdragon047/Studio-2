using UnityEngine;
using System;
using UnityEngine.Events;

public class InputManager : MonoBehaviour
{
    public UnityEvent<Vector2> onMove = new UnityEvent<Vector2>();
    public UnityEvent onSpacePressed = new UnityEvent();

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            onSpacePressed?.Invoke();
        }

        Vector2 input = Vector2.zero;
        if (Input.GetKey(KeyCode.A))
        {
            input += Vector2.left;
        }
        if (Input.GetKey(KeyCode.D))
        {
            input += Vector2.right;
        }
        onMove?.Invoke(input);
    }
}
