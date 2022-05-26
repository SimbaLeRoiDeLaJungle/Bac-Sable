using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
namespace Simba{
    public class GfxUpdater : MonoBehaviour
    {
        Animator animator;

        void Start()
        {
        animator = GetComponent<Animator>();
        }

        public void UpdateGfx(bool isGrounded, float xVel, bool attack, ref bool isAttacking){
            bool walk = isGrounded && xVel != 0 ; // la vitesse sur l'axe x n'est pas 0 et on est au sol => le joueur marche
            animator.SetBool("walk", walk);
            if(xVel != 0){
                bool direction = xVel > 0 ; // si la vitesse est positive il marche vers la droite : true <=> right, false <=> left
                animator.SetBool("direction", direction);
            }
            if(attack){
                animator.SetTrigger("attack");
            }

            // on verifie si le calques n°2 celui qui contient les attaques est entrain d'etre jouer
            var info = animator.GetCurrentAnimatorClipInfo(1);
            if(info.Length > 0){
                isAttacking = true;
            }
            else{
                isAttacking = false;
            }
            

        }
    }


}