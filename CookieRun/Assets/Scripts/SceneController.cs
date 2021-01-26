using UnityEngine;
using UnityEngine.SceneManagement;

class SceneController : MonoBehaviour
{
	public void GoGameScene()
	{
		SceneManager.LoadScene(1);
	}
}