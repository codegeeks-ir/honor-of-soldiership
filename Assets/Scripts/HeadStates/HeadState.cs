using UnityEngine;

public abstract class HeadState
{
    // Fields
    private static readonly int startIndexOfSprites = 1;
    private static readonly int endIndexOfSprites = 181;
    protected Sprite[] headSpriteList;

    // Properties
    public abstract string StateName { get;}

    // Methods
    public abstract void UpdateSoldier();
    protected void InitializeSprites(SoldierSprite soldierSprite)
    {
        headSpriteList = new Sprite[endIndexOfSprites - startIndexOfSprites + 1];
        for(int spriteIndex = startIndexOfSprites; spriteIndex <= endIndexOfSprites; spriteIndex++)
            headSpriteList[spriteIndex - 1] = SpriteManager.Instance.spriteAtlas.GetSprite(StateName + spriteIndex);
    }
    public void ChangeSprite(int directionAngle , SoldierSprite soldierSprite)
    {
        int spriteIndex = 0; 
        if (-90 < directionAngle && directionAngle <= 90)
        {
            if (soldierSprite.HeadSpriteRenderer.flipX)
                soldierSprite.HeadSpriteRenderer.flipX = false;
            spriteIndex = directionAngle + 90;
        }
        if (90 < directionAngle && directionAngle <= 180)
        {
            soldierSprite.HeadSpriteRenderer.flipX = true;
            spriteIndex = 270 - directionAngle;
        }
        if (-180 <= directionAngle && directionAngle <= -90)
        {
            soldierSprite.HeadSpriteRenderer.flipX = true;
            spriteIndex = -(directionAngle + 90);
        }
        soldierSprite.HeadSpriteRenderer.sprite = headSpriteList[spriteIndex];
    }
}