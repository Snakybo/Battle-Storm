﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class EnemyManager:MonoBehaviour {
	public Transform parent;
	public Transform start;
	public Transform end;
	
	public float spawnDelay;
	
	private GameObject enemy;
	
	public GameObject[] enemies;
	public Transform[] spawnpositions;
	public Transform spawnposition;
	public List<GameObject> enemyList;
	void Start() {
		enemyList = new List<GameObject>();
	}
	void FixedUpdate(){
		for(int i = 0; i < enemyList.Count; i++){
			if(enemyList[i].gameObject == null){
				enemyList.RemoveAt(i);
			}
		}
	}
	public void spawnEnemy(string name,float health,float speed,int spawn) {
		Debug.Log(spawn);
		switch(spawn){
			case 0:
			spawnposition = spawnpositions[0];
			break;
			case 1:
			spawnposition = spawnpositions[1];
			break;
			case 2:
			spawnposition = spawnpositions[2];
			break;
		}
		enemy = Instantiate(Resources.Load("Prefabs/Entity/"+name), spawnposition.position, Quaternion.identity) as GameObject;
		Enemy en = enemy.GetComponent<Enemy>();
		en.hitpoints = health;
		en.speed = speed;
		enemy.GetComponent<PathFollower>().target = end;
		enemy.transform.parent = parent;
		enemyList.Add(enemy.transform.gameObject);
	}
}
