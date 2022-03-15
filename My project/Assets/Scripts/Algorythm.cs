using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Algorythm: MonoBehaviour
{
    
    [SerializeField]
    private Transform[] nodesTable;
    [SerializeField]
    public List<GameObject> nodes = new List<GameObject>();

    public GameObject CurrentNodeObject;
    public List<Node> instanceNodes = new List<Node>();   // public to use in package manager
    private float maxvalue = float.MaxValue;


    private float[] distanceBeetwenNodes;
    bool[] visitedNodes;
    List<int> sequenceVisitedNodes;

    private int[] routesTable;

    List<int> routeAB; 
    // Start is called before the first frame update
    void Awake()
    {
      

        nodesTable = GetComponentsInChildren<Transform>();

        nodes = GetAllChildren();

        foreach (GameObject node in nodes)
        {
            instanceNodes.Add(node.GetComponent<Node>()); // all edges in instanceNodes :)])


        }


        initializeGraph();

       // startAlgorythm(2);

        //findRouteBetweenAandB(2, 5);

    }


    private void initializeGraph()
    {
        initializeNodes();
    }
    private void initializeNodes()
    {
        foreach(Node node in instanceNodes)
        {
            node.initializeId();
        }
        foreach (Node node in instanceNodes)
        {
            node.initializeEdges();
        }
    }
   

    public int findClosestNode(Transform transform)
    {
        return 1;
    }

    public List<int> findRouteBetweenAandB(int NodeAId, int NodeBId)
    {
        startAlgorythm(NodeAId);
        //przyjmij A
        // przyjmnij B
        ///wroc sciezke ( liste nodow przez ktore przejdzie)

        routeAB = new List<int>();

        int i = NodeBId;
        routeAB.Add(NodeBId);
        while (routesTable[i] != -1)
        {
           routeAB.Add(routesTable[i]);
            i = routesTable[i];
        }

        


        return routeAB;
    }


    public List<GameObject> GetAllChildren()
    {
        if (nodesTable == null)
            return nodes;

        foreach (Transform child in nodesTable)
        {
            nodes.Add(child.gameObject);
        }

        nodes.RemoveAt(0);
        return nodes;
    }


    void startAlgorythm(int startNodeId)
    {
        distanceBeetwenNodes = new float[nodes.Count()];
        visitedNodes = new bool[nodes.Count()];

        routesTable = new int[nodes.Count()];
        routesTable[startNodeId] = -1;

        sequenceVisitedNodes = new List<int>();

        makeTable(startNodeId);


    }


    void makeTable( int startNodeId)
    {

      
        for (int i = 0; i < nodes.Count(); i++)    
        {
            distanceBeetwenNodes[i] = maxvalue;
        }

         distanceBeetwenNodes[startNodeId] = 0;

        int currentNodeId = startNodeId;
        int algorithmsIteration = 0;
        

        while (!(visitedNodes.All(x => x)))   // whole table is visited 
        {
            for (int i = 0; i < nodes.Count(); i++)
            {

                distanceBeetwenNodes[i] = updatedValue(i, currentNodeId, distanceBeetwenNodes[i]);

            }

          
            currentNodeId = findNearestNeighbour();

            
            visitedNodes[currentNodeId] = true;
            algorithmsIteration++;

        }


    }



    int findNearestNeighbour()
    {
        int nearestNeighbourId = -1;
        float nearestDistance = float.MaxValue;


        for (int i = 0; i < nodes.Count(); i++)
        {
            if (distanceBeetwenNodes[i] < nearestDistance && visitedNodes[i] == false)
            {
                nearestDistance = distanceBeetwenNodes[i];
                nearestNeighbourId = i;

            }

        }

       

        return nearestNeighbourId;
    }



    float updatedValue(int to, int from, float value)
    {

        if (instanceNodes[from].edgeList == null)
        {
            return value;
        }



        for (int k = 0; k < instanceNodes[from].edgeList.Count(); k++)
        {
            if (instanceNodes[from].edgeList[k].getidEnd()== to)
            {
                if ((distanceBeetwenNodes[from] + instanceNodes[from].edgeList[k].getDistance()) < value)

                {
                    value = distanceBeetwenNodes[from] + instanceNodes[from].edgeList[k].getDistance();

                    routesTable[to] = from;
                }
                
            }
        }




        return value;

    }



    public List<Node> getInstanceNodes()
    {
        return this.instanceNodes;
    }

}
