using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadController : MonoBehaviour
{
	[SerializeField] GameObject deadPanel;
	[SerializeField] Transform deadLine;
	[SerializeField] Transform player;

	// Start is called before the first frame update
	void Start()
	{
			
	}

	// Update is called once per frame
	void Update()
	{
		DeadLineFollow();
	}

	public void Dead()
	{
		deadPanel.SetActive(true);
	}

	public void DeadLineFollow()
	{
		Vector3 position = deadLine.position;
		position.x = player.position.x;
		deadLine.position = position;
	}
}
