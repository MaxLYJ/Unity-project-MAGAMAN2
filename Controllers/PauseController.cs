using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseController : MonoBehaviour {

    public Text liveText;
    public Text eTankText;
    public GameObject PauseMenu;
    public GameController gameController;
    public Megaman myPlayer;
    public Button defualtActiveButtonOnPause;

    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
        checkInput();
	}

    void checkInput()
    {
        if (Input.GetKeyDown("return"))
        {
            Debug.Log("DETECTED");

            PauseMenu.SetActive(true);
            defualtActiveButtonOnPause.Select();
            myPlayer.GetComponent<Megaman>().canInput = false;
            updateUI();
            Time.timeScale = 0f;
        }
    }

    void updateUI()
    {
        liveText.text = gameController.getLives().ToString();
        eTankText.text = gameController.getTanks().ToString();
    }

    public void resume()
    {
        Time.timeScale = 1;
        PauseMenu.SetActive(false);
        myPlayer.GetComponent<Megaman>().canInput = true;
    }

    public void useTank()
    {
        
        int numTanks = gameController.getTanks();
        if (numTanks > 0 && (myPlayer.GetComponent<Health>().health < myPlayer.GetComponent<Health>().maxHealth))
        {
            myPlayer.GetComponent<Health>().health = myPlayer.GetComponent<Health>().maxHealth;
            gameController.updateTanks(-1);
        }

        resume();
    }
}
