using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBananas : MonoBehaviour
{
    public GameObject bananaPrefab;
    public GameObject bananabunchPrefab;
    public float respawnTime = 2.0f;
    private int[] bananaPos = new int[] {0,-3,3,-6,6};
    private int bananaCount;
    // private Camera cam;
    // private Vector2 screenBounds;

    // Start is called before the first frame update
    void Start()
    {
        // screenBounds = cam.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, cam.transform.position.z));
        StartCoroutine(bananaTime());
    }

    private void createBanana(){
        if (bananaCount < 5){
            GameObject a = Instantiate(bananaPrefab) as GameObject;
            a.transform.position = new Vector3(bananaPos[Random.Range(0,5)], Random.Range(-4,6), -1);
            bananaCount += 1;
            //Debug.Log("Banana!");
        }else{
            GameObject a = Instantiate(bananabunchPrefab) as GameObject;
            a.transform.position = new Vector3(bananaPos[Random.Range(0,5)], Random.Range(-4,6), -1);
            bananaCount = 0;
            //Debug.Log("BananaBunch!");
        }
    }

    IEnumerator bananaTime(){
        while(true){
            yield return new WaitForSeconds(respawnTime);
            createBanana();
        }
    }
}
