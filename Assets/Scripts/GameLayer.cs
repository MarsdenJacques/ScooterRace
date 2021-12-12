using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLayer : MonoBehaviour
{
    [SerializeField]
    private float parallaxMultiplier;
    // Start is called before the first frame update
    void Start()
    {

    }
    void Update()
    {

    }
    public float GetParallaxMultiplier()
    {
        return parallaxMultiplier;
    }
}
