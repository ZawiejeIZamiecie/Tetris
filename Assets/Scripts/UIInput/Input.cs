using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Input : MonoBehaviour
{
    [SerializeField]
    string playerName;

    public Vector2 InputValue { get; private set; }

    public void OnInput(InputAction.CallbackContext context)
    {
        InputValue = context.ReadValue<Vector2>();
    }

    void Update()
    {
        GameManager.Instance.OnInput(playerName, InputValue);
    }
}
