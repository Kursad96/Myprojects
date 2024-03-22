using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class DamageController : MonoBehaviour
{
   PlayerHealtController playerHealtController;
    //private IEnumerable<Transform> bitkiTransform;

    [SerializeField]
    
    public void Awake()
    {
        
        playerHealtController = Object.FindObjectOfType<PlayerHealtController>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.tag == "Player")
        {
            playerHealtController.TakenDamage();

        }  
    }  
}
    

