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
            float xvel = rb.velocity.x;
            bool walk = isGrounded && xvel != 0 ; // la vitesse sur l'axe x n'est pas 0 et on est au sol => le joueur marche
            animator.SetBool("walk", walk);
            if(xvel != 0){
                bool direction = rb.velocity.x > 0 ; // si la vitesse est positive il marche vers la droite : true <=> right, false <=> left
                animator.SetBool("direction", direction);
            }
            // juste pour test 
            if(Input.GetKeyDown(KeyCode.Space)){
                animator.SetTrigger("attack");
            }

        }
    }


}