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
        bool isAttacking;
        [SerializeField] GfxUpdater gfx;
        
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
            bool attackInput = Input.GetKeyDown(KeyCode.Space);
            bool isGrounded = groundChecker.CheckGroundContact();
            
            bool attackLaunch = false;
            if(attackInput){
                if(!isAttacking){
                    attackLaunch = true;
                }
                isAttacking = true;
                rb.velocity = rb.velocity.y * Vector3.up;
            }
            else{
                if(isAttacking){
                    rb.velocity = rb.velocity.y * Vector3.up;
                }
                else{
                    //mvt latéraux
                    float latVelocity = x * speed;
                    rb.velocity = latVelocity * Vector3.right + rb.velocity.y * Vector3.up;
                    //saut 
                    Vector3 dF = Vector3.zero;
                    
                    if(y > 0 && isGrounded){
                        dF = Vector3.up * jumpSpeed * dt;
                    }
                    rb.AddForce(dF, ForceMode2D.Impulse);
                }
            } 
            // On met à jour le sprite du personnage en fonction des inputs
            gfx.UpdateGfx(isGrounded, rb.velocity.x , attackLaunch, ref isAttacking);
        }
    }
}