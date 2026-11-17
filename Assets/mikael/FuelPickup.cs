using UnityEngine;
using UnityEngine.InputSystem;

public class FuelPickup : MonoBehaviour
{
    private bool pickupAllowed;
    private Lyhty playerLyhty;
    private float fuelAmount = 50f;


    void Start()
    {
        
    }
  
    public void PickUp(InputAction.CallbackContext context)
    {
       if(pickupAllowed && context.performed)
        {
            
            playerLyhty.CurrentFuel += fuelAmount;
           Destroy(gameObject);
            Debug.Log("Fuel picked up");
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerLyhty = other.GetComponent<Lyhty>();
            pickupAllowed = true; 
            Debug.Log("Player entered trigger");
            
        }
       
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerLyhty = null;
            pickupAllowed = false;
            Debug.Log("Player exited trigger");
        }
        
    }
}
