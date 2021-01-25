using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;

public class MapLoader : MonoBehaviour
{
	// Start is called before the first frame update
	private Dictionary<char, string> tile = new Dictionary<char, string>() {
		{'.',  "None"},         // none
        { '-', "Platform" },    // Platform
        { '|', "Obstacle" },    // Obstacle
        { 'j', "Jelly" },       // jelly
        { 'h', "Heal" }         // Heal
    };

	[SerializeField] private Transform mapParent;

	/// <summary>
	/// current stage (default: 1)
	/// </summary>
	private int currentStage;

	/// <summary>
	/// working directory
	/// </summary>
	private string path;

	private const int Height = 5, Width = 10;

	void Start()
	{
		currentStage = 1;
		path = System.Environment.CurrentDirectory;
		LoadMap();
	}

	// Update is called once per frame
	void Update()
	{

	}

	private void LoadMap()
	{
		Vector2 position = Vector2.zero;
		float dx = 2f, dy = 2f;
		for (int mapId = 1; mapId <= 4; mapId++)
		{
			string[] mapInfo = ReadMap(mapId);
			for (int i = Height - 1; i >= 0; i--)
			{
				for (int j = 0; j < Width; j++)
				{
					GameObject gobj = Instantiate(GameObject.Find(tile[mapInfo[i][j]]), position + new Vector2(dx * ((Width - 1) - j), dy * ((Height - 1) - i)), Quaternion.identity);
					gobj.transform.parent = mapParent;
				}
			}
			position.x += Width * dx;
		}
	}

	private string[] ReadMap(int mapId)
	{
		string textValue = System.IO.File.ReadAllText(path + "/Assets/Map/stage" + currentStage + "/" + mapId + ".txt");
		return textValue.Split('\n');
	}
}
