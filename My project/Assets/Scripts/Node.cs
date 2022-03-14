using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class Node : MonoBehaviour
{
    [SerializeField]
    public List<GameObject> neighboursList;

    [SerializeField]
    public List<Edge> edgeList;



    private float distance;

    [SerializeField]
    private int idNode;

    public int getIdNode( )
    {

        return this.idNode;

    }

    
    

    public void initializeId()
    {
        string idString = name.Remove(0, 4);
        this.idNode = int.Parse(idString);
    }
    public void initializeEdges()
    {
        edgeList = new List<Edge>();

        for (int i = 0; i < neighboursList.Count(); i++)
        {
            int currId = this.idNode;
            int neghbId = neighboursList[i].GetComponent<Node>().getIdNode();
            Edge edge = new Edge(Vector2.Distance(neighboursList[i].transform.position, transform.position), currId, neghbId);
            edgeList.Add(edge);


        }
    }

   
    

}