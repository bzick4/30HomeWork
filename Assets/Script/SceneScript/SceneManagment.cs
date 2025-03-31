using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagment : MonoBehaviour
{
    [SerializeField] private TMP_Text _level;
    [SerializeField] private int numberScene;
    
    private void Update()
    {
        _level.text = numberScene.ToString();
    }
    
    public void Exit()
    {
        SceneManager.LoadScene(0);
    }
    
    public void Restart()
    {
        SceneManager.LoadScene(numberScene);
    }
    
    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        
        if(SceneManager.GetActiveScene().buildIndex==6)
        SceneManager.LoadScene(0);
    }
}
