using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Rendering;

public class Lepakko_chase : MonoBehaviour
{
    public float speed = 3f;
    
    
    private bool isChasing = false;
    private bool isStopped = false;
    private Transform targetPlayer;
    private GameObject goAwayBat;
    private Collider2D GoAwayBat;

    void Start()
    {
        targetPlayer = GameObject.FindGameObjectWithTag("Player").transform;
        goAwayBat = GameObject.FindGameObjectWithTag("GoAwayBat");
        GoAwayBat = goAwayBat.GetComponent<Collider2D>();

    }

    void Update()
    {
        if (isChasing && targetPlayer != null)
        {
            CheckLanter();
            transform.position = Vector3.MoveTowards(transform.position, targetPlayer.position, speed * Time.deltaTime);
        }
       if (isStopped)
        {
            transform.position = Vector3.MoveTowards(transform.position,goAwayBat.transform.position, speed * Time.deltaTime);
            
            if(Vector3.Distance(transform.position, goAwayBat.transform.position) < 0.1f)
            {
                Destroy(gameObject);
            }

        }
    }

    public void StartChasing(Transform player)
    {
        if (Lyhty.instance != null && Lyhty.instance.brightnessLevel >= 3)
        {
            return;
        }
        isStopped = false;
        targetPlayer = player;
        isChasing = true;
    }

    private void CheckLanter()
    {
        if (Lyhty.instance != null && Lyhty.instance.brightnessLevel >= 3)
        {
            StopChasing();
        }
    }

 
    public void StopChasing()
    {
        isChasing = false;
        targetPlayer = null;
        isStopped = true;
        
    }
    public void OnTriggerEnter2D(Collider2D player)
    {
       if(player.CompareTag("Player"))
        {
            player = GoAwayBat;

            Debug.Log("Player collided with Lepakko");
        }
    }
}