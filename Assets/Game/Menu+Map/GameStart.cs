using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStart : MonoBehaviour {

    
    GameObject originalGameObject;
    List<GameObject> childrenofOG;
    List<GameObject> maps;

    // Start is called before the first frame update
    void Start()
    {
        GameObject originalGameObject = GameObject.Find("GameParent");
        for (int i = 0; i > 3; i++) {
            childrenofOG.Add(originalGameObject.transform.GetChild(i).gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void onGameDetectM1() {
        childrenofOG[1].gameObject.SetActive(false);
        childrenofOG[2].gameObject.SetActive(false);

        startGame(0);
    }
    void onGameDetectM2() {
        childrenofOG[0].gameObject.SetActive(false);
        childrenofOG[2].gameObject.SetActive(false);

        startGame(1);
    }
    void onGameDetectM3() {
        childrenofOG[1].gameObject.SetActive(false);
        childrenofOG[2].gameObject.SetActive(false);

        startGame(2);
    }
    void respawnGameM1() {
        childrenofOG[0].gameObject.SetActive(true);
        childrenofOG[1].gameObject.SetActive(true);

        stopGame(0);
    }
    void respawnGameM2() {
        childrenofOG[0].gameObject.SetActive(true);
        childrenofOG[2].gameObject.SetActive(true);

        stopGame(1);
    }
    void respawnGameM3() {
        childrenofOG[0].gameObject.SetActive(true);
        childrenofOG[1].gameObject.SetActive(true);

        stopGame(2);
    }

    void startGame(int map) {
        childrenofOG[map].transform.GetChild(0).gameObject.SetActive(true);

    }

    void stopGame(int map) {
        childrenofOG[map].transform.GetChild(0).gameObject.SetActive(false);
    }
}
