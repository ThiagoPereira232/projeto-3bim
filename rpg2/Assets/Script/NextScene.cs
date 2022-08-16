using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    [SerializeField] private string sceneName;
    [SerializeField] DestinationIdentifier destinationPortal;
    [SerializeField] Transform spawnPoint;
    private Player player;

    public Animator transition;
    public float transitionTime = 1f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            StartCoroutine(Teleport());
        }
    }

    IEnumerator Teleport()
    {
        DontDestroyOnLoad(gameObject);
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);
        yield return SceneManager.LoadSceneAsync(sceneName);

        FindObjects();

        var destPortal = FindObjectsOfType<NextScene>().First(x => x != this && x.destinationPortal == this.destinationPortal);
        player.transform.position = new Vector2(destPortal.spawnPoint.position.x, destPortal.spawnPoint.position.y);
        
        Destroy(gameObject);
    }

    private void FindObjects()
    {
        player = FindObjectOfType<Player>();
    }

    public enum DestinationIdentifier { A, B, C, D, E }
}
