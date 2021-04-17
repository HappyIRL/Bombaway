using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
using System;

public class Goblin : MonoBehaviour, IExplodingElement, IClickable
{

    [SerializeField]
    GameObject destroyedGoblin;

    [SerializeField] private int scoreOnCollect;
    [SerializeField] private int scoreOnExplode;

    [Button]
    void Collect ()
    {
        BombsAndGoblinsTracker.Instance.AddGoblin();
        Score.Instance.Add(scoreOnCollect);
        Destroy(gameObject);
    }

    public void Explode(Bomb source)
    {
        Debug.Log("Goblin died through explosion");

        if (destroyedGoblin != null)
            Instantiate(destroyedGoblin, transform.position, Quaternion.identity);

        Score.Instance.Add(scoreOnExplode);

        Destroy(gameObject);
    }

    public void Click()
    {
        Collect();
    }
}
