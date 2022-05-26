using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Simba{
    public class GfxUpdater : MonoBehaviour
    {
        [SerializeField] Rigidbody2D rb;
        [SerializeField] GroundChecker groundChecker;
        Animator animator;

        void Start()
        {
        animator = GetComponent<Animator>();
        }

        void Update(){
            bool isGrounded = groundChecker.CheckGroundContact();
            if(isGrounded){
                if(rb.velocity.x > 0){
                    animator.SetBool("walk", true);
                    animator.SetBool("direction", true);// true <=> right, false <=> left
                }
                else if(rb.velocity.x<0){
                    animator.SetBool("walk", true);
                    animator.SetBool("direction", false);
                }
                else{
                    animator.SetBool("walk", false);
                }
            }
            else{
                animator.SetBool("walk", false);
            }

            // juste pour test 
            if(Input.GetKeyDown(KeyCode.Space)){
                animator.SetTrigger("attack");
            }

        }
    }


}