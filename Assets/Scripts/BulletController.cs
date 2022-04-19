using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{

    private Transform cameraPlayerTransform;
    // Start is called before the first frame update
    float speed = 100f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }

    private void OnTriggerEnter(Collider other)
    {      
        if (other.gameObject.tag == "Zombie"){
            
            // Crear mancha de sangre
    //        Instantiate (explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
            Destroy(other.gameObject); 

        } else {


        }

        
    }
}
