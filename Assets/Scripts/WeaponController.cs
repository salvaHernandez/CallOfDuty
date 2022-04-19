using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum ShotType 
{
    Manual,
    Atuomatic
}

public class WeaponController : MonoBehaviour
{

    private GameObject objCargador;
    private Text txtCargador;
    
    private GameObject objRecamara;
    private Text txtRecamara;
    public GameObject DisparoPrefab;


    [Header("References")]
    public Transform weaponMuzzle;
    private string ficheroCargador = "txtBalas";
    private string ficheroRecamara = "txtTotalBalas";

    [Header("General")]
    
    private Animator anim;

    [Header("Shoot Paramaters")]
    public ShotType shotType;
    public float fireRange = 200;
    public float recoilForce = 4f; //Fuerza de retroceso del arma
    public float fireRate = 0.6f;
    public int maxAmmo = 0;

    [Header("Balas")]
    public int recamara;
    public int cargador;
    

    [Header("Reload Parameters")]
    public float reloadTime;
    public int currentAmmo { get; private set; }
    private float lastTimeShoot = Mathf.NegativeInfinity;


    [Header("Sounds & Visuals")]
    public GameObject flashEffect;

    private Transform cameraPlayerTransform;
    public AudioClip sonidoDisparo;
    AudioSource audioS;


    private void Awake () 
    {
        currentAmmo = maxAmmo;
    }


    private void Start()
    {
        audioS = GetComponent<AudioSource>();

        cameraPlayerTransform = GameObject.FindGameObjectWithTag("MainCamera").transform;

        objCargador = GameObject.Find(ficheroCargador);
        txtCargador = objCargador.GetComponent<Text>();
        currentAmmo = int.Parse(txtCargador.text);

        objRecamara = GameObject.Find(ficheroRecamara);
        txtRecamara = objRecamara.GetComponent<Text>();
        maxAmmo = int.Parse(txtRecamara.text);

        anim = GetComponent<Animator>();
    }


    private void Update()
    {
        if (shotType == ShotType.Manual) 
        {
            if (Input.GetButtonDown("Fire1"))
            {
                if (TryShoot())
                {
                    HandleShoot();
                }
            }
        } else if (shotType == ShotType.Atuomatic) 
        {
            if (Input.GetButton("Fire1"))
            {
                if (TryShoot())
                {
                    HandleShoot();
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine(Reload());
        }

    }



    public bool TryShoot () {


        if (lastTimeShoot + fireRate < Time.time)
        {
            if (currentAmmo >= 1)
            {
                IteracionTxtBalas();
                return true;
            }
        }
            return false;
    }



    private void HandleShoot()
    {
        
        Instantiate (DisparoPrefab, cameraPlayerTransform.position, cameraPlayerTransform.rotation);
        

        GameObject flashClone = Instantiate(flashEffect, weaponMuzzle.position, Quaternion.Euler(weaponMuzzle.forward), transform);
        Destroy(flashClone, 1f);

        audioS.PlayOneShot(sonidoDisparo);
        
        AddRecoil();

        lastTimeShoot = Time.time;
    }

    private void AddRecoil()
    {
        transform.Rotate(-recoilForce, 0f, 0f);
    }

    


   IEnumerator Reload()
    {
        if (IteracionRecarga())
        {
            //animacion de recarga
            Debug.Log("Recargando... Tiempo de recarga:"+ reloadTime);
            yield return new WaitForSeconds(reloadTime);
            Debug.Log("Recargada Se pausan los segundos pero solo en este mensaje");
            //termina la animacion
        }
    }

    private void IteracionTxtBalas () 
    {

        currentAmmo -= 1;
        txtCargador.text = currentAmmo.ToString();
        if (currentAmmo == 0) 
        {
            txtCargador.color = new Color(1,0,0);
        } else 
        {
            txtCargador.color = Color.white;
        }

    }

    private bool IteracionRecarga () 
    {        
        
        bool recarga = false;
        if (maxAmmo > 0) 
        {
            txtRecamara.color = Color.white;
            txtCargador.color = Color.white;
            recarga = true;
            int totalBalas = maxAmmo + currentAmmo;
            if (totalBalas <= cargador)
            {
                currentAmmo = totalBalas;
                maxAmmo = 0;
                txtRecamara.color = new Color(1,0,0);

            } else 
            {
                currentAmmo = cargador;
                maxAmmo = totalBalas - currentAmmo;
            }
            
            txtCargador.text = currentAmmo.ToString();
            txtRecamara.text = maxAmmo.ToString();
        }
        return recarga;
    }


}