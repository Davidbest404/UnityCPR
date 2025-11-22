using UnityEngine;

public class RockHP : MonoBehaviour
{
    [SerializeField] private float rockHP = 3;
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private LayerMask _layerMask2;

    private void Update()
    {
        if (rockHP <= 0)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (LayerMaskUtil.ContainsLayer(_layerMask, collision.gameObject.layer) || LayerMaskUtil.ContainsLayer(_layerMask2, collision.gameObject.layer))
        {
            rockHP -= 1;
        }
    }
}
