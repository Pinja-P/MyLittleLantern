using UnityEngine;

public class FuelPickup : MonoBehaviour
{
    private bool pickupAllowed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if(pickupAllowed && Input.GetKeyDown(KeyCode.F)||Input.GetKeyDown(KeyCode.Space))
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<Lyhty>().CurrentFuel += 20;
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            pickupAllowed = true;
        }
    }
}
