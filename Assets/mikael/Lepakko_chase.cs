using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Rendering;

public class Lepakko_chase : MonoBehaviour
{
    public float speed = 3f;
    
    private Transform targetPlayer;
    private bool isChasing = false;
    private bool isStopped = false;
    private GameObject goAwayBat;

    void Start()
    {
       
        goAwayBat = GameObject.FindGameObjectWithTag("GoAwayBat");

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
}