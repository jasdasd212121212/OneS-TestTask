using UnityEngine.SceneManagement;

public class LevelModel
{
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}