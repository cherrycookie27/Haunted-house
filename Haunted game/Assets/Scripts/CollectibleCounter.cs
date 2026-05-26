using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollectibleCounter : MonoBehaviour
{
    public static CollectibleCounter instance;

    public TMP_Text collectibleText;
    public int currentCollectibles = 0;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        collectibleText.text = "Treasures: " + currentCollectibles.ToString();
    }

    public void IncreaseCollectibles(int v)
    {
        currentCollectibles += v;
        collectibleText.text = "Treasures:" + currentCollectibles.ToString();
    }
}
