using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteVault : MonoBehaviour
{
    [SerializeField]
    private Sprite[] bikeSprites;
    [SerializeField]
    private Sprite[] characterSprites;
    // Start is called before the first frame update
    void Start()
    {
        if (GameManager.manager.spriteVault != null && GameManager.manager.spriteVault != this)
        {
            Destroy(gameObject);
        }
        else
        {
            GameManager.manager.spriteVault = this;
        }
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public Sprite GetBikeSprite(int spriteId)
    {
        return bikeSprites[spriteId];
    }
    public Sprite GetCharacterSprite(int spriteId)
    {
        return characterSprites[spriteId];
    }
}
