using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class LevelControler : MonoBehaviour {
    public Button[] grids;
    // Use this for initialization
    public Button seletedButton;
    public int x = 1, y = 1;
    public string sceneToLoad;

	void Start () {
        EventSystem.current.SetSelectedGameObject(grids[getIndexFromCoords(x, y)].gameObject);
        seletedButton = grids[getIndexFromCoords(x, y)];
    }

    float isVertical = 0, isHorizontal = 0;
	// Update is called once per frame
	void Update () {


        float dx = Input.GetAxis("Horizontal");
        float dy = -Input.GetAxis("Vertical");


        if(dx != 0 && isHorizontal * dx <= 0)
        {
            x = 3 + x + (dx > 0 ? 1 : -1);
            x = x % 3;
        }

        if (dy != 0 && isVertical * dy <= 0)
        {
            y = 3 + y + (dy > 0 ? 1 : -1);
            y = y % 3;
        }

        isVertical = dy;
        isHorizontal = dx;
        EventSystem.current.SetSelectedGameObject(grids[getIndexFromCoords(x, y)].gameObject);
        seletedButton = grids[getIndexFromCoords(x, y)];

    }

    public void OnlevelSelected()
    {
        Button selectedButton = seletedButton;

        LevelSelectOption lo = selectedButton.GetComponent<LevelSelectOption>();
        if (lo != null)
        {
            SceneManager.LoadScene(lo.LevelName);
        }
        else
        {
            Debug.LogWarning("No option associated with:" + selectedButton.name);
        }
    }


    int getIndexFromCoords(int x, int y)
    {
        return y * 3 + x;
    }
}
