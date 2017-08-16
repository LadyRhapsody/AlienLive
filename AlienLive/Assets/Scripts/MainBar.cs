using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MainBar : MonoBehaviour
{

    public static MainBar instance = null;
    public NPC[] npcs;
    public Transform NPCStartTarget;
    public GameManager gameManager;
    public int waitSeconds;

    private List<NPC> npcList;
    private Chair[] chairs = new Chair[24];
    private Transform NpcHolder;
    private bool open = true;
    private int barLevel;


    public void AddNpcToList(NPC script)
    {
        npcList.Add(script);
    }

    void Awake()
    {
        if (instance == null)

            //if not, set instance to this
            instance = this;

        //If instance already exists and it's not this:
        else if (instance != this)

            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);

        //Sets this to not be destroyed when reloading scene
        DontDestroyOnLoad(gameObject);


        Init();
    }

    void Init()
    {

        npcList = new List<NPC>();

        chairs = new Chair[11];
        chairs = GetComponentsInChildren<Chair>();
        Debug.Log(chairs.Length);
        barLevel = 1;

        InvokeRepeating("NewCustomer", 10, waitSeconds / barLevel);


    }

    private void NewCustomer()
    {
        Debug.Log("New Costumer?");
        int random = Random.Range(0, 10);
        int randomNpc = Random.Range(0, npcs.Length);

        if (random % 4 == 0)
        {
            Debug.Log("New Costumer!");
            // TODO: prüfen ob freie Stühle vorhanden. 
            if (npcList.Count <= 3 * barLevel)
            {
                NPC toIns = npcs[randomNpc];
                NpcHolder = transform;
                NPC npc = Instantiate(toIns, NPCStartTarget.position, Quaternion.identity) as NPC;
                npc.transform.SetParent(transform);
                // TODO: Prüfen ob essen vorhanden ist.  
            }
        }
    }



    void Update()
    {
        if (open)
        {
            foreach (var n in npcList)
            {
                if (n.HasTarget())
                {
                    int chairNum = Random.Range(0, chairs.Length);
                    if (!chairs[chairNum].IsTarget)
                    {
                        n.StartMove(chairs[chairNum].transform, chairs[chairNum].Direction(), chairs[chairNum].LookFloat());
                        chairs[chairNum].IsTarget = true;
                        n.MoveToChair();
                    }
                }
                else
                {
                    n.MoveToChair();
                }
            }
        }
    }
}
