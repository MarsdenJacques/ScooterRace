using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField]
    Camera cam;
    [SerializeField]
    private SpriteRenderer spriteRenderer;
    [SerializeField]
    private Bike bike;
    [SerializeField]
    private Person person;
    private int playerNumber = 0;
    private int characterId = 0;
    private int money = 0;
    private int inputMode = 0;
    private bool canMove = false;
    private float moveSpeed = 1.0f;

    //bike stuff
    [SerializeField]
    private float boostVal = 1.5f;
    private float boosting = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        if(!GameManager.manager.RegisterPlayer(this))
        {
            GameObject.Destroy(gameObject);
        }
        moveSpeed = GameManager.manager.GetMoveSpeed();
        DontDestroyOnLoad(gameObject);
    }
    public void InitPlayer(int number, int character, int startingMoney)
    {
        playerNumber = number;
        characterId = character;
        money = startingMoney;
    }
    // Update is called once per frame
    void Update()
    {
        if(canMove)
        {
            switch (inputMode)
            {
                case 1:
                    BikeInputs();
                    break;
                case 2:
                    CharacterInputs();
                    break;
                case 3:
                    break;
                default:
                    break;
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("hit");
        Obstacle obstacle = other.GetComponent<Obstacle>();
        if(obstacle != null)
        {
            Debug.Log("hit obstacle");
        }
    }
    public void SetMovement(bool newMove)
    {
        canMove = newMove;
    }
    public void StartRace()
    {
        Debug.Log("swapped to bike sprite!");
        //spriteRenderer.sprite = GameManager.manager.spriteVault.GetBikeSprite(characterId);
        inputMode = 1;
    }
    public void StartTown()
    {
        Debug.Log("swapped to character sprite!");
        //spriteRenderer.sprite = GameManager.manager.spriteVault.GetCharacterSprite(characterId);
        inputMode = 2;
    }
    public void StartMiniGame()
    {
        //spriteRenderer.sprite = null;
        inputMode = 3;
    }
    public void OnMove(InputAction.CallbackContext context)
    {
        Vector2 movement = context.ReadValue<Vector2>();
        if(movement.x > 0.0f)
        {
            boosting = boostVal;
        }
        else
        {
            boosting = 1.0f;
        }
        if(movement.y > 0.0f)
        {
            ChangeLanes(true);
        }
        else if(movement.y < 0.0f)
        {
            ChangeLanes(false);
        }
    }
    public float GetBoosting()
    {
        return boosting;
    }
    private void BikeInputs()
    {
        //maybe just don't move player in the screen, maybe jsut omplement multiple versions and try playtesting it? could also smooth the transition between the two
        transform.position = new Vector3(transform.position.x + moveSpeed * boosting * Time.deltaTime, transform.position.y, transform.position.z);
        //check if boosting off the screen
        if(!(transform.position.x - cam.transform.position.x > 6.62f))//this is temp value
        {
            cam.transform.position = new Vector3(cam.transform.position.x - moveSpeed * (boosting - 1.0f) * Time.deltaTime, cam.transform.position.y, cam.transform.position.z);
        }
        if(boosting == 1.0f && cam.transform.position.x - transform.position.x < 6.62f)
        {
            cam.transform.position = new Vector3(cam.transform.position.x + moveSpeed * ((boostVal - 1.0f) * 0.5f) * Time.deltaTime, cam.transform.position.y, cam.transform.position.z);
        }
        //up
        //down
        //right
        //b
        //a
        //move
        //if player position is beyond acceptable camera scope, move camera
    }
    private void ChangeLanes(bool up)
    {
        int direction = 1;
        if (!up)
        {
            direction = -1;
        }
        transform.position = new Vector3(transform.position.x, transform.position.y + direction * GameManager.manager.GetRoadHeight(), transform.position.z);
    }
    private void CharacterInputs()
    {
        //up
        //down
        //left
        //right
        //b
        //a
        //move
        //if player position is beyond acceptable camera scope, move camera
    }
}
