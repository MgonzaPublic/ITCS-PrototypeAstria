using System;
using System.Collections;
using System.Collections.Generic;
using Global;
using UI.PlayerUI;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float PlayerMovementSpeed;
    public Vector2 MovementDirection;
    public LayerMask ObjectsLayer, InteractionLayer;


    private Rigidbody2D _rb;
    [SerializeField]
    private InputActionReference _movement, _interaction, _jumping;
     
    private bool _isMoving;
    private Animator _animator;
    
    private void Awake()
    {
        _animator = this.GetComponent<Animator>();
    }

    private void OnEnable()
    {
        new AstriaManager();
        _rb = this.gameObject.GetComponent<Rigidbody2D>();
        _interaction.action.performed += InteractionButtonPressed;
    }

    private void InteractionButtonPressed(InputAction.CallbackContext obj)
    {
        Debug.Log("Pressed!");
        InteractWithObject();
    }

    // Update is called once per frame
    void Update()
    {
        
        MovementAnimation();
    }

    private void MovementAnimation()
    {
        if (!AstriaManager.Instance.LocalPlayerMovementEnabled) return;
        MovementDirection = _movement.action.ReadValue<Vector2>();

        MovementDirection.Normalize();

        if (MovementDirection != Vector2.zero)
        {
            _animator.SetFloat("moveX", MovementDirection.x);
            _animator.SetFloat("moveY", MovementDirection.y);
        }

        _animator.SetBool("isMoving", _isMoving);
    }

    private void FixedUpdate()
    {
       
        Move(MovementDirection);
    }
    
    void Move(Vector2 newPositionForCharacter)
    {
        if (!isWalkable(newPositionForCharacter)) return;
        _isMoving = true;
        _rb.velocity = new Vector2(newPositionForCharacter.x * PlayerMovementSpeed,
            newPositionForCharacter.y * PlayerMovementSpeed);
        _isMoving = false;
    }

     bool isWalkable(Vector2 newPositionForCharacter)
     {
         if (!AstriaManager.Instance.LocalPlayerMovementEnabled) return false;

             var currPos = this.gameObject.transform.position;
         currPos.x += newPositionForCharacter.x;
         currPos.y += newPositionForCharacter.y;

         if (Physics2D.OverlapCircle(currPos, 0.2f, ObjectsLayer | InteractionLayer) != null)
         {
             return false;
         }
         return true;

     }

     public void InteractWithObject()
     {
         var fd = new Vector3(_animator.GetFloat("moveX"), _animator.GetFloat("moveY"));
         var i = transform.position + fd;

         var collider = Physics2D.OverlapCircle(i, .2f, InteractionLayer);
         if (collider != null)
         {
             Debug.Log("NPC");
             var t = collider.gameObject.GetComponent<InteractionNpc>();
             if (t.SceneChange)
             {
                 t.ChangeScene(t.SceneName);
                 return;
             }
             t.OpenInteractionNPCMenu();
         }
     }
     
     public void SetWalkable(bool isWalkable)
     {
         AstriaManager.Instance.LocalPlayerMovementEnabled = isWalkable;
     }
}
