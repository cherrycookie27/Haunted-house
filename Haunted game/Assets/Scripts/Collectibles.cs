using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectibles : MonoBehaviour
{
    public int value;
    [SerializeField] private AudioSource collectsound;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            collectsound.Play();
            Destroy(gameObject);
            CollectibleCounter.instance.IncreaseCollectibles(value);
        }
    }
}
