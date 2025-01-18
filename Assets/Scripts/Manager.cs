using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    public GameObject SetupScreen;
    public GameObject VictoryScreen;
    public GameObject Player;
    public Vector2 initPosition;
    public Quaternion initRotation;

    void Start ()
    {
        initPosition = Player.transform.position;
        initRotation = Player.transform.rotation;
    }
    public void loadScene()
    {
        SceneManager.LoadScene("GamePlay");
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Player.transform.position = initPosition;
            Player.transform.rotation = initRotation;
            SetupScreen.gameObject.SetActive(false);
            VictoryScreen.gameObject.SetActive(false);
            Player.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            Player.transform.position = initPosition;
            Player.transform.rotation = initRotation;
            SetupScreen.gameObject.SetActive(true);
            VictoryScreen.gameObject.SetActive(false);
            Player.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        }
    }
}
