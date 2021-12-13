using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerController : MonoBehaviour
{
    [SerializeField]
    private float parallaxMultiplier = 1.0f;
    [SerializeField]
    private float moveSpeed = 1.0f;
    private List<GameLayer> currentLayers = new List<GameLayer>();
    private float targetX = 0.0f;
    private float currentX = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        if (GameManager.manager.layerController != null && GameManager.manager.layerController != this)
        {
            Destroy(gameObject);
        }
        else
        {
            GameManager.manager.layerController = this;
        }
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if(currentX != targetX)
        {
            Debug.Log(currentX);
            MoveLayers();
        }
    }
    public void SetTarget(float newTargetX)
    {
        targetX = newTargetX;
    }
    private void MoveLayers()
    {
        int direction = 1;
        if(targetX < currentX)
        {
            direction = -1;
        }
        foreach (GameLayer layer in currentLayers)
        {
            MoveLayer(layer, direction);
        }
        currentX += moveSpeed * direction * Time.deltaTime;
        if(direction == 1)
        {
            if(currentX > targetX)
            {
                SetTarget(currentX);
            }
        }
        else
        {
            if(currentX < targetX)
            {
                SetTarget(currentX);
            }
        }
    }
    private void MoveLayer(GameLayer layer, int direction)
    {
        layer.transform.position = new Vector3(layer.transform.position.x + moveSpeed * -direction / (layer.GetParallaxValue() * parallaxMultiplier) * Time.deltaTime, layer.transform.position.y, layer.transform.position.z);
    }
    public void RegisterLayer(GameLayer layer)
    {
        currentLayers.Add(layer);
    }
    public void ResetLayers()
    {
        currentLayers.Clear();
    }
    public float GetCurrentX()
    {
        return currentX;
    }
}
