using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
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
    // Start is called before the first frame update
    void Start()
    {
        if(!GameManager.manager.RegisterPlayer(this))
        {
            GameObject.Destroy(gameObject);
        }
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
        switch(inputMode)
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
    private void BikeInputs()
    {
        //up
        //down
        //right
        //b
        //a
    }    
    private void CharacterInputs()
    {
        //up
        //down
        //left
        //right
        //b
        //a
    }
}
