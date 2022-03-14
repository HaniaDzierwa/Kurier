using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private GameObject packageManager;
    private GameObject player;
    private Algorythm graph;

    private LineRenderer pathRenderer;

    private PlayerManager playerManager;

    private Transform[] nodesPossitionsTable;

    private string garageSceneName;

    void Start()
    {
        player = GameObject.Find("Player");
        graph = GameObject.Find("Graph").GetComponent<Algorythm>();
        packageManager = GameObject.Find("PackageManager");
        garageSceneName = "Garage";

        pathRenderer = GameObject.Find("PathRenderer").GetComponent<LineRenderer>();

        
    }

    // Update is called once per frame
    void Update()
    {
        if ( nodesPossitionsTable == null)
        {
            return;
        }

         for (int m = 0; m < this.nodesPossitionsTable.Count(); m++)
        {
            pathRenderer.SetPosition(m, nodesPossitionsTable[m].position);
        }
    }

  
    public void playerAndNodeColiision(int collidedNodeId)
    {
        int destinationNodeId = packageManager.GetComponent<PackageManager>().getPackageDestinationNodeId();
        if (destinationNodeId == -1)
        {
            Debug.Log("No package");
            return;
        }

        //
        // int startNodeId = graph.GetComponent<Algorythm>().findClosestNode(playerTransform);
        List<int> foundRoute = graph.GetComponent<Algorythm>().findRouteBetweenAandB(collidedNodeId, destinationNodeId);


        this.nodesPossitionsTable = getNodesPossition(foundRoute);
        pathRenderer.positionCount = foundRoute.Count();
      
        
           

        Debug.Log("A");
    }

    public void enterGarage()
    {
        SceneManager.LoadScene(garageSceneName);
    }

    private Transform[] getNodesPossition( List<int> foundRoute)
    {
        Transform[] nodesPossition = new Transform [foundRoute.Count()];

        int k = 0;
        for (int i = 0; i < foundRoute.Count(); i++)
        {
            for (int j = 0; j < graph.nodes.Count(); j++)
            {
                if (graph.nodes[j].GetComponent<Node>().getIdNode() == foundRoute[i])
                {
                    nodesPossition[k] = graph.nodes[j].transform;
                    k++;
                }

            }
        }  

        return nodesPossition;

    }

}
