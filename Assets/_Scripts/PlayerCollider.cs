﻿using UnityEngine;
using System.Collections;

public class PlayerCollider : MonoBehaviour {
    public GameController gameController;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            this.gameController.MissesValue -= 1;

        }
    }
}
