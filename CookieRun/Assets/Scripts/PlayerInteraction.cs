using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    int playerHealth = 1000;
    int score = 0;
    private void GetDamage(int damage)
    {
        playerHealth -= damage;
    }

    private void HealHealth(int heal)
    {
        playerHealth += heal;
    }

    private void AddScore(int _score)
    {
        score += _score;
    }

    public int GetScore()
    {
        return score;
    }

    private void OnTriggerEnter(Collider other)
    {
        switch(other.tag)
        {
            case "Obstacle":
                GetDamage(50);
                break;
            case "Heal":
                HealHealth(200);
                break;
            case "Jelly":
                AddScore(100);
                break;
        }
    }

}
