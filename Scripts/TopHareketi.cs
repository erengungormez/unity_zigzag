using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopHareketi : MonoBehaviour
{
    Vector3 yön;
    public float hız;
    public ZeminSpawner zeminekle;
    public static bool düştü_mü;
    public float eklenecekhız; 

    void Start()
    {
        yön = Vector3.forward;
        düştü_mü = false;   
    }

  
    void Update()
    {
        if(transform.position.y<= 0.5f)
          {
             düştü_mü = true;
          }  
         if(düştü_mü == true)
         {
            return;
         }

       if(Input.GetMouseButtonDown(0))
       {
          if(yön.x == 0)
          {
             yön = Vector3.left;
          }
           else
           {    
             yön = Vector3.forward;
           }

           hız += eklenecekhız*Time.deltaTime;
       }   
 }
     
     private void FixedUpdate()
     {
        Vector3 hareket = yön * Time.deltaTime * hız;
        transform.position += hareket;
     }

     private void OnCollisionExit(Collision collision)

     {   
        if(collision.gameObject.tag == "zemin")
        {  
           Skor.skor++; 
           collision.gameObject.AddComponent<Rigidbody>();
           zeminekle.zemin_oluştur();
           StartCoroutine(ZeminiSil(collision.gameObject));        
        }
     }

     IEnumerator ZeminiSil(GameObject SilinecekZemin)
     {
        yield return new WaitForSeconds(3f);
        Destroy(SilinecekZemin);
     }

}   
