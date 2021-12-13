using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLayer : MonoBehaviour
{
    [SerializeField]
    private float parallaxValue;
    // Start is called before the first frame update
    void Start()
    {
        GameManager.manager.layerController.RegisterLayer(this);
    }
    void Update()
    {
        
    }
    public float GetParallaxValue()
    {
        return parallaxValue;
    }
}
