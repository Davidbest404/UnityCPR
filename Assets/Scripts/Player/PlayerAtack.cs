using UnityEngine;

public class PlayerAtack : MonoBehaviour
{
    [SerializeField] private GameObject bulletPref;
    [SerializeField] private Transform shootPosition;   
    [SerializeField] private Transform rotateZone;
    private const float _offset = -90;
    void Update()
    {
        RotateGan();
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Instantiate(bulletPref, shootPosition.position, Quaternion.identity);
        }
    }
    private void RotateGan()
    {
        Vector3 diference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotateZ = Mathf.Atan2(diference.y, diference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(rotateZ, Vector3.forward);
        shootPosition.rotation = Quaternion.Euler(0f, 0f, rotateZ + _offset);
        
    }
}