using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField]
    private float speed = 1.0f;
    public static GameManager manager;
    public LoadingInterface loader;
    // Start is called before the first frame update
    void Awake()
    {
        if (manager != null && manager != this)
        {
            Destroy(gameObject);
        }
        else
        {
            manager = this;
        }
        DontDestroyOnLoad(gameObject);
        loader.LoadScene(1, StartMainMenu);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void StartMainMenu()
    {

    }
    private void StartGameplay()
    {

    }
    public float GetSpeed()
    {
        return speed;
    }
}
