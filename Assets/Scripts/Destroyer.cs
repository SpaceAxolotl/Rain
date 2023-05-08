using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DestroyOnTriggerEnter : MonoBehaviour
{

    
    public Collider2D _triggerCollider;
    public TMP_Text Score;
    
    
 
      

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other == _triggerCollider)
        {
            
            Destroy(gameObject);
            RegenSpawner.count++;
           print(RegenSpawner.count);
           CountToText();

        }
    }

    

   private void CountToText() {
    
    Score.text = RegenSpawner.count.ToString();
   }
}