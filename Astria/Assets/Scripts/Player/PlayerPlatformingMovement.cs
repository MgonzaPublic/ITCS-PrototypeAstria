using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class PlayerPlatformingMovement : MonoBehaviour
    {
        public float Speed;
        public float JumpHeight;

        public bool isInAir;
        [SerializeField]
        private InputActionReference _movement, _interaction, _jumping;
        public LayerMask ObjectsLayer, InteractionLayer;
        
        private Rigidbody2D _rb;
        public void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
            _interaction.action.performed += InteractionButtonPressed;
            _jumping.action.performed += JumpingButtonPressed;
        }

        private void JumpingButtonPressed(InputAction.CallbackContext obj)
        {
            Debug.Log("Jum Hit" + _rb.velocity.y);
            /*if (_rb.velocity.y == 0)
            {
                _rb.AddForce(new Vector2(_rb.velocity.x, JumpHeight));
            }*/
            if (Physics2D.OverlapCircle(this.transform.position, 1f, ObjectsLayer | InteractionLayer) != null)
            {
                _rb.AddForce(new Vector2(_rb.velocity.x, JumpHeight));
            }
                                        
        }

        private void InteractionButtonPressed(InputAction.CallbackContext obj)
        {
            InteractWithObject();
        }
        
        public void InteractWithObject()
        {
            

            var collider = Physics2D.OverlapCircle(this.gameObject.transform.position, 1f, InteractionLayer);
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

        private void Update()
        {
            var t = _movement.action.ReadValue<Vector2>();
            _rb.velocity = new Vector2(Speed * t.x, _rb.velocity.y);
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.tag == "Blocker")
            {
                isInAir = false;
            }
        }
    }
}