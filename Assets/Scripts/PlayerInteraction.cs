using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlayerInteraction : MonoBehaviour

{
    [SerializeField] private LayerMask playerLayers;
    [SerializeField] private UnityEvent interacted;

    private Collider2D myCollider;

    private void Start()
    {
        myCollider = GetComponent<Collider2D>();
    }

    public void Interact(InputAction.CallbackContext context)
    {
        if(context.ReadValue<float>() >= 0.5f)
        {
            if(myCollider.IsTouchingLayers( (int)playerLayers))
            {
                interacted.Invoke();
            }
        }
    }
    
    public int points = 0;

    private void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 100, 20), "Score : " + points);
    }


}
