using UnityEngine;
public class PlayerBullet : MonoBehaviour
{
    [SerializeField] private int timeDestroy;
    [SerializeField] private int speed;
    [SerializeField] private Rigidbody2D rb;
    private GameObject player;
    private void Awake()
    {
        player = GameObject.FindWithTag("Player");
    }
    private void Start()
    {
        Vector3 diference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - player.transform.position;
        float rotateZ = Mathf.Atan2(diference.y, diference.x) * Mathf.Rad2Deg;
        transform.rotation =  Quaternion.Euler(0f, 0f, rotateZ -90f);
        rb.velocity = transform.up * speed;
        Destroy(gameObject, timeDestroy);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
