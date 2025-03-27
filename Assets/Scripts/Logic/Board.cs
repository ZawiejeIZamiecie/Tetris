using System.Collections;
using UnityEngine;

public class Board : MonoBehaviour
{
    [SerializeField]
    Transform spawnPosition;

    [SerializeField]
    Transform raycastOrigin;

    [SerializeField]
    string playerName;

    GameObject nextBlock;

    Figure currentFigure;

    RaycastHit[] hits = new RaycastHit[10];

    int score;


    IEnumerator Start()
    {
        GameManager.Instance.OnInput += UpdateInput;
        nextBlock = GameManager.Instance.GetNextFigure();
        while (true)
        {
            SpawnNewBlock();
            CheckLines();
            yield return new WaitForSeconds(20);
        }
    }

    void OnDestroy()
    {
        GameManager.Instance.OnInput -= UpdateInput;
    }

    void UpdateInput(string playerName, Vector2 inputValue)
    {
        if(this.playerName == playerName)
            currentFigure.Move(inputValue);
    }

    void SpawnNewBlock()
    {
        currentFigure = Instantiate(nextBlock, spawnPosition.position, Quaternion.identity).GetComponent<Figure>();
        nextBlock = GameManager.Instance.GetNextFigure();
        GameManager.Instance.OnFigure(playerName, nextBlock.GetComponent<Figure>().icon);
    }

    void CheckLines()
    {
        Ray ray = new Ray();
        for (int i = 0; i < 20; i++)
        {
            ray.origin = new Vector3(raycastOrigin.position.x, 10 + i);
            ray.direction = Vector3.left;
            var hitCount = Physics.RaycastNonAlloc(ray, hits, 11, (1 << LayerMask.NameToLayer("Block")));
            if (hitCount == 10)
            {
                for (int j = 0; j < hitCount; j++)
                {
                    Destroy(hits[j].transform.gameObject);
                }
                score++;
                GameManager.Instance.OnScore(playerName, score);
            }
        }
    }
}
