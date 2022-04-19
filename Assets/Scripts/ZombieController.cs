using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieController : MonoBehaviour
{

    public float speed = 20f;
    private float distanciaGolpeo = 2f;
    private Transform target;
    private Rigidbody enemyRb;
    private Animator aniAtack;
    private int damage = 20;
    // Start is called before the first frame update
    void Start()
    {
        aniAtack = GetComponent<Animator>();
        enemyRb = GetComponent<Rigidbody>(); 
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();  
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 posicion = Vector3.MoveTowards(transform.position, target.position, speed * Time.fixedDeltaTime);
        enemyRb.MovePosition(posicion);
        transform.LookAt(target);

        zombieAtaca();
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            target.GetComponent<PlayerController>().restaVida(damage);
        }
    }

    private void zombieAtaca ()
    {
        float distancia = (target.transform.position - transform.position).magnitude;

        if (distancia <= distanciaGolpeo)
        {
            aniAtack.SetBool("isAtacking", true);
        } else
        {
            aniAtack.SetBool("isAtacking", false);
        }

    }
}
