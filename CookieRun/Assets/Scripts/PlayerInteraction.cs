using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    int playerHealth = 1000;
    int score = 0;
    [SerializeField] PlayerMovement playerMovement;

    [SerializeField] DeadController deadController;

	private void Update()
	{
/*        Debug.Log(playerHealth);*/
        if (playerHealth <= 0) deadController.Dead();
        GameObject.Find("Health").GetComponent<UnityEngine.UI.Text>().text = playerHealth.ToString();
	}

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

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other + "  " + other.tag);
        Removeable removeable = other.GetComponent<Removeable>();
        switch(other.tag)
        {
            case "Obstacle":
                Debug.Log("!@#!@#");
                GetDamage(50);
                break;
            case "Heal":
                HealHealth(200);
                break;
            case "Jelly":
                AddScore(100);
                break;
            case "Platform":
                playerMovement.ResetJumpStack();
                break;
            case "DeadLine":
                Debug.Log("DEAD!!");
                deadController.Dead();
                break;
        }
        if (removeable != null)
        {
            removeable.DestroyObject();
        }
    }

}
