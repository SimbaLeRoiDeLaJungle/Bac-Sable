using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Simba{
    //Pour checker si le joueur touche le sol ou pas
    public class GroundChecker : MonoBehaviour
    {
        [SerializeField] LayerMask groundLayers;
        [SerializeField] float rayLength;
        float playerSize;

        void Start(){
            Collider2D col = GetComponent<Collider2D>(); // méthode MonoBehaviour.GetComponent 
            if( col == null){
                Debug.Log("error : Collider2D missing.");
            }
            playerSize = col.bounds.extents.y; // C'est le rayon du cercle, plus précisement extents sa te renvoi la taille total de chaque composante divisé par 2.
        }

        //renvoi true si le joueur touche le sol, false sinon.
        public bool CheckGroundContact() {
            Vector3 playerCenter = transform.position; // (transform est un monobehaviour attaché par default qui donne la position, rotation, ... du gameObject)
            Vector3 playerBottom = playerCenter - Vector3.up * playerSize;  
            var hit = Physics2D.Raycast(playerBottom, Vector3.down, rayLength, groundLayers); // https://docs.unity3d.com/ScriptReference/Physics2D.Raycast.html
            return hit.collider != null;
        }
    }

}
