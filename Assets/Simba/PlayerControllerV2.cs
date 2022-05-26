using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Simba{
    // Un autres système de déplacement peut etre mieu pour du rétro
    public class PlayerControllerV2 : MonoBehaviour
    {
        Rigidbody2D rb;
        [SerializeField] float speed;
        [SerializeField] float jumpSpeed;
        GroundChecker groundChecker;
        
        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            if(rb == null){
                Debug.Log("error : RigidBody2D missing.");
            }
            groundChecker = GetComponent<GroundChecker>();
            if(groundChecker == null){
                Debug.Log("error : GroundChecker missing.");
            }
        }

        void FixedUpdate() {
            float dt = Time.fixedDeltaTime; // temps entre 2 fixedUpdate
            float x = Input.GetAxisRaw("Horizontal");
            float y = Input.GetAxisRaw("Vertical");
            //mvt latéraux
            float latVelocity = x * speed;
            rb.velocity = latVelocity * Vector3.right + rb.velocity.y * Vector3.up;
            //saut 
            Vector3 dF = Vector3.zero;
            if(y > 0){
                bool isGrounded = groundChecker.CheckGroundContact();
                if(isGrounded){
                    dF = Vector3.up * jumpSpeed * dt;
                }
            }
            rb.AddForce(dF, ForceMode2D.Impulse);
        }
    }
}