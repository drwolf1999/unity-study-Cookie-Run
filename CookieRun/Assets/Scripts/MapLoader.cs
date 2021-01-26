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

	private static Vector2 lastMapPosition;

	/// <summary>
	/// working directory
	/// </summary>
	private string path;

	private const int Height = 5, Width = 10;

	void Start()
	{
		path = System.Environment.CurrentDirectory;
		lastMapPosition = Vector2.zero;
		for (int i = 1; i <= 3; i++)
		{
			LoadMap(i);
		}
	}

	// Update is called once per frame
	void Update()
	{

	}

	private void LoadMap(int spawnStage)
	{
		Vector2 position = lastMapPosition;
		float dx = 2f, dy = 2f;
		for (int mapId = 1; mapId <= 4; mapId++)
		{
			string[] mapInfo = ReadMap(mapId, spawnStage);
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
		lastMapPosition = position;
	}

	private string[] ReadMap(int mapId, int stage)
	{
		string textValue = System.IO.File.ReadAllText(path + "/Assets/Map/stage" + stage + "/" + mapId + ".txt");
		return textValue.Split('\n');
	}
}
