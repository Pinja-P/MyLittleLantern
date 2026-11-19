using System.Runtime.CompilerServices;
using UnityEngine;

public class Lepakko_chase : MonoBehaviour
{
    public float speed = 3f;
   
    private Transform targetPlayer;
    private bool isChasing = false;

    void Update()
    {
        if (isChasing && targetPlayer != null)
        {
            CheckLanter();
            transform.position = Vector3.MoveTowards(transform.position, targetPlayer.position, speed * Time.deltaTime);
        }
       
    }

    public void StartChasing(Transform player)
    {
        if (Lyhty.instance != null && Lyhty.instance.brightnessLevel >= 3)
        {
            return;
        }

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
    } 
}