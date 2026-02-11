using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
public class Test : MonoBehaviour
{
    public Object bt;
    public Transform parentPanel;
    // Start is called once before the first execution of Update after the MonoBehaviour is created


    void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            Instantiate(bt, parentPanel);
        }
        DontDestroyOnLoad(gameObject);
        SceneManager.LoadScene("New Scene");
        HashSet<string> a = new HashSet<string>();
        a.Add("a");
        a.Remove("b");
    }

    // Update is called once per frame
    void Update()
    {
        List<int> a = new List<int>();
        a.Add(1);
       
    }


    public enum Suit
    {
        A=0, B=C, C=0
    }

}

