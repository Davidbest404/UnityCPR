using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] private List<GameObject> allObjects;
    [SerializeField] private LayerMask _layerMask;

    private void OnCollisionEnter(Collision collision)
    {
        if (LayerMaskUtil.ContainsLayer(_layerMask, collision.gameObject.layer))
        {
            for (int i = 0; i < allObjects.Count; ++i)
            {
                allObjects[i].GetComponent<Collider>().enabled = false;
            }
        }
    }
}
