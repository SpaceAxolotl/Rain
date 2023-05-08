using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyHandler : MonoBehaviour
{
    [SerializeField] GameObject TheDestroyer;
    [SerializeField] int GevangenDruppels;
    [SerializeField] GameObject Regen;
   
    private void OnTriggerEnter(Collider other)
    {
        
        
        
            print("ik werk");
            Destroy(other.gameObject);
            GevangenDruppels=GevangenDruppels+1;
            print(GevangenDruppels);
        
        
        
            // GevangenDruppels=GevangenDruppels+1;
            // print(GevangenDruppels);
        
         
    }

    // Update is called once per frame
    
}
