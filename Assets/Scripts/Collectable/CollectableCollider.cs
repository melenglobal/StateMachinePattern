using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CollectableCollider : MonoBehaviour
{
    public List<Transform> transformList = new List<Transform>();

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gameObject.SetActive(false);

            gameObject.transform.position =
                new Vector3(Random.Range(15, 22), 0, Random.Range(-3, 3));
        }
    }
}
