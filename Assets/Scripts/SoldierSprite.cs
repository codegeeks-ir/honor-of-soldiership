﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class SoldierSprite : MonoBehaviour {
    // Fields
	[SerializeField] private Direction direction;
    [SerializeField] private SpriteManager spriteManager;
	[SerializeField] private SpriteRenderer headSpriteRenderer;
	[SerializeField] private SpriteRenderer bodySpriteRenderer;
	[SerializeField] private SpriteRenderer legsSpriteRenderer;
    private HeadState headState;
    private BodyState bodyState;
    private LegsState legsState;

    // Properties
    public SpriteRenderer HeadSpriteRenderer {
        get { return headSpriteRenderer; }
        set { headSpriteRenderer = value;}
    }

    public SpriteRenderer BodySpriteRenderer
    {
        get { return bodySpriteRenderer; }
        set { bodySpriteRenderer = value; }
    }

    public SpriteRenderer LegsSpriteRenderer
    {
        get { return legsSpriteRenderer; }
        set { legsSpriteRenderer = value;}
    }

    public SpriteManager GetSpriteManager
    {
        get { return spriteManager; }
    }

    // Methods
    public static void InitilizeStates()
    {
        HeadState.InitializeHeadList();
        BodyState.InitializeBodyList();
        LegsState.InitializelegsList();
    }

    void Start () {
        SoldierSprite.InitilizeStates();
        headState = HeadState.headList["Head-Idle"];
        bodyState = BodyState.bodyList["Body-Idle"];
        legsState = LegsState.legsList["Legs-Idle"];
	}

	void Update () {
		ChangeSprite(direction.GetAngle);
	}

	void ChangeSprite(int directionAngle)
	{
        bodyState.ChangeSprite(directionAngle , this);
        headState.ChangeSprite(directionAngle , this);
        legsState.ChangeSprite(directionAngle , this);
	}
}
