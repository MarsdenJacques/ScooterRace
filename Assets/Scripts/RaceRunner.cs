using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RaceRunner : MonoBehaviour
{
    [SerializeField]
    private float raceDistance;
    [SerializeField]
    private Slider raceProgress;
    private LayerController layerController;
    private bool raceRunning = false;
    // Start is called before the first frame update
    void Start()
    {
        layerController = GameManager.manager.layerController;
        if (!GameManager.manager.RegisterRaceRunner(this))
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(raceRunning)
        {
            if (layerController.GetCurrentX() >= raceDistance)//inefficient, need to make this more elegant (especially if we want to release for NES)
            {
                EndRace();
            }
            else
            {
                raceProgress.value = layerController.GetCurrentX() / raceDistance;
            }
        }
        
    }
    public void StartRace()
    {
        raceProgress.value = 0;
        layerController.SetTarget(layerController.GetCurrentX() + raceDistance);
        raceRunning = true;
    }
    public void PauseRace()
    {
        raceRunning = false;
        raceDistance -= layerController.GetCurrentX();
        layerController.SetTarget(layerController.GetCurrentX());
    }
    public void SetRaceDistance(float distance)
    {
        raceDistance = distance;
    }
    private void EndRace()
    {
        //have coroutine here play end of race stuff I guess?
        raceRunning = false;
        GameManager.manager.LoadTown();
    }
}
