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
            float absX = Mathf.Abs(rb.velocity.x);
            bool walk = isGrounded && absX > 0;
            animator.SetBool("walk", walk);
            if(absX > 0){
                bool direction = rb.velocity.x > 0 ;
                animator.SetBool("direction", direction);// true <=> right, false <=> left
            }
            /*         
            En moin condensée c'est ça :
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
                animator.SetBool()
            } 
            */
            // juste pour test 
            if(Input.GetKeyDown(KeyCode.Space)){
                animator.SetTrigger("attack");
            }

        }
    }


}