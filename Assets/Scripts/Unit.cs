using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Unit : MonoBehaviour
{

	public string unitName;

	public int damage;

	public int maxHP;
	public int currentHP;
	public int HeatLevel;
	public int StatusInt;

	public bool TakeDamage(int dmg)
	{
		currentHP -= dmg;

		if (currentHP <= 0)
			return true;
		else
			return false;
	}


	public void checkHeat(int HeatLevel){

		switch(HeatLevel){
			case 0:
			print("neutral");
			damage += 0;
			break;
			case 1:
			print("Warm");
			damage += 2;
			break;
			case 2:
			print("Hot");
			damage += 2;
			break;
			case 3:
			print("Risky");
			damage += 2;
			break;
			case 4:
			print("Explosive!");
			damage += 2;
			break;	
			default:
			currentHP = currentHP - 2;
			HeatLevel = 0;
			//checkStatus(HeatLevel);
			damage -= 8;
			break;

		}
	}
	public void Heal(int amount)
	{
		currentHP += amount;
		if (currentHP > maxHP)
			currentHP = maxHP;
	}


}