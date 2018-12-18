using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bolt;

public class HealthUpdate : MonoBehaviour {
	public GameObject Player;
	public GameObject Boss;
	private float PlayerMaxHealth;
	private float PlayerCurrentHealth;
	public SimpleHealthBar PlayerHealthBar;
	private float BossMaxHealth;
	private float BossCurrentHealth;
	public SimpleHealthBar BossHealthBar;

	// Use this for initialization
	void Start () {
		PlayerMaxHealth = (float)Variables.Application.Get("PlayerHealthMax");
		if(Boss) BossMaxHealth = (float)Variables.Object(Boss).Get("Health");
	}
	
	// Update is called once per frame
	void Update () {
		PlayerCurrentHealth = (float)Variables.Object(Player).Get("Health");
		PlayerHealthBar.UpdateBar( PlayerCurrentHealth, PlayerMaxHealth );
		if(Boss){
			BossCurrentHealth = (float)Variables.Object(Boss).Get("Health");
			BossHealthBar.UpdateBar( BossCurrentHealth, BossMaxHealth );
		}
	}
}
