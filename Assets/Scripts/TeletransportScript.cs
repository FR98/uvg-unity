using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TeletransportScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay(Collider collider) {
        if(collider.gameObject.tag == "Player") {
            changeScene("Drift Track");
        }
    }

    public void changeScene(string newScene) {
        SceneManager.LoadScene(newScene);
    }
}
