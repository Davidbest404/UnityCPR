using UnityEngine;
using UnityEngine.InputSystem;

public class DroneController : MonoBehaviour
{
    [SerializeField] private GameObject Player;
    [SerializeField] private GameObject Drone;

    [SerializeField] private bool turn;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            Change();
        }
    }

    private void Change()
    {
        if (turn)
        {
            Player.SetActive(false);
            Drone.SetActive(true);
        }
        else
        {
            Player.SetActive(true);
            Drone.SetActive(false);
        }        
    }
}
