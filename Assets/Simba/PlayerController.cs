using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Simba
{
   //MonoBehaviour == C'est une classe qui peut s'attacher aux "GameObjects" ici le gameObject est le Player, on dit aussi que PlayerController est un "component" de Player. 
    public class PlayerController : MonoBehaviour
    {
        Rigidbody2D rb;
        [SerializeField] float speed;
        [SerializeField] float jumpSpeed;
        GroundChecker groundChecker;
        // appeller au moment où l'objet s'initialise (avant le start)
        void Awake(){

        }
        // Start is called before the first frame update 
        void Start()
        {
            rb = GetComponent<Rigidbody2D>(); // méthode MonoBehaviour.GetComponent 
            if(rb == null){
                // il n'y a pas de RigidBody2D attaché a notre gameObject
                Debug.Log("error : RigidBody2D missing.");
            }
            groundChecker = GetComponent<GroundChecker>();
            if(groundChecker == null){
                Debug.Log("error : GroundChecker missing.");
            }
        }

        // Update is called once per frame (pour mettre à jour les informations)
        void Update()
        {
            
        }

        // Pour la physique
        void FixedUpdate() {
            float dt = Time.fixedDeltaTime; // temps entre 2 fixedUpdate
            float x = Input.GetAxisRaw("Horizontal");
            float y = Input.GetAxisRaw("Vertical");
            Vector3 dF = Vector3.zero;
            float conversionFactor = 500f; // pour que l'on es pas besoin de mettre des chiffre trop grand en vitesse
            if(x>0){
                dF = Vector3.right * speed * dt * conversionFactor ;
            }
            else if(x<0){
                dF += Vector3.left * speed * dt * conversionFactor ;
            }
            if(y > 0){
                bool isGrounded = groundChecker.CheckGroundContact();
                if(isGrounded){
                    dF += Vector3.up * jumpSpeed * dt *conversionFactor ;
                }
            }
            rb.AddForce(dF);
        }

    }


}