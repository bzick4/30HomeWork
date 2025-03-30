using UnityEngine;

public class Pause : MonoBehaviour
{
    [SerializeField] private WalkBall _WalkBall;
    [SerializeField] private MazeSpawner _MazeSpawner;
    [SerializeField] private AudioListener _Audio;

    private void Awake()
    {
        ScriptOff();
    }

    public void ScriptOn()
    {
        _WalkBall.enabled = true;
        _MazeSpawner.enabled = true;
        _Audio.enabled =true;
    }

    public void ScriptOff()
    {
        _WalkBall.enabled = false;
        _MazeSpawner.enabled = false;
        _Audio.enabled = false;
    }
}
