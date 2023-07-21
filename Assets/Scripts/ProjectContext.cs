using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectContext : MonoBehaviour
{
    public static ProjectContext Instance { get; private set; }

    public PauseManager PauseManager { get; private set; }

    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(this);
    }

    public void Initialize()
    {
        PauseManager = new PauseManager();
    }

    private void Start()
    {
        Initialize();
    }
}
