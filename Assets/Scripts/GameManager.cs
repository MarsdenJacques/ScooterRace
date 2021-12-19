using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager manager;
    public LayerController layerController;
    public SpriteVault spriteVault;
    [SerializeField]
    private float speed = 1.0f;
    [SerializeField]
    private float roadHeight = 1.0f;
    private LoadingInterface loader;
    private RaceRunner raceRunner;
    private List<Player> players = new List<Player>();
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
    }
    public bool RegisterLoader(LoadingInterface candidateLoader)
    {
        if (loader != null && loader != candidateLoader)
        {
            return false;
        }
        else
        {
            loader = candidateLoader;
            loader.LoadScene(1, StartMainMenu);
            return true;
        }
    }
    public bool RegisterRaceRunner(RaceRunner candidateRunner)
    {
        if (raceRunner != null && raceRunner != candidateRunner)
        {
            return false;
        }
        else
        {
            raceRunner = candidateRunner;
            StartRace();
            return true;
        }
    }
    public bool RegisterPlayer(Player player)
    {
        if(players.Contains(player))
        {
            return false;
        }
        players.Add(player);
        return true;
    }
    public void SetMovement(bool newMove)
    {
        foreach(Player player in players)
        {
            player.SetMovement(newMove);
        }
    }
    public float GetMoveSpeed()
    {
        return speed;
    }
    public float GetPlayerBoosting()
    {
        return players[0].GetBoosting();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    private void StartMainMenu()
    {

    }
    public void LoadRace()
    {
        loader.LoadScene(2);
    }
    private void StartRace()
    {
        raceRunner.SetRaceDistance(100.0f);
        foreach(Player player in players)
        {
            player.StartRace();
        }
        raceRunner.StartRace();
    }
    public void LoadTown()
    {
        loader.LoadScene(3, StartTown);
    }
    private void StartTown()
    {
        foreach (Player player in players)
        {
            player.StartTown();
        }
    }
    public float GetRoadHeight()
    {
        return roadHeight;
    }
}
