using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
public class PackageManager : MonoBehaviour
{

    [Header("Notification variables")]
    [SerializeField]
    private Text notificationText;
    [SerializeField]
    private Image notificationImage;

    [SerializeField]
    private GameObject notification;
    [SerializeField]

    private int showUpTime = 3;
    //public GameObject packageDestination;
    public GameObject[] packagesDestinationsTable; // tablica wszystkich paczek 
    [SerializeField]
    public List<GameObject> packagesDestinations; // lista gdzie sa usuwane elementy ktory juz byly wybrane
    [SerializeField]
    private GameObject currentPackageDestination;
    public GameObject pickPackageObj;
    public GameObject deliverdPackageObj;
    private PickPackage pickPackage;
    private DeliverdPackage deliverdPackage;
    private bool packageInDelivery = false;
    //public GameObject package;
  

    [SerializeField]
    private GameObject graph; 


    void Start()
    {
        pickPackageObj = GameObject.FindGameObjectWithTag("PickPackage");
        deliverdPackageObj = GameObject.FindGameObjectWithTag("DeliverdPackage");

        pickPackage = pickPackageObj.GetComponent<PickPackage>();
        deliverdPackage = deliverdPackageObj.GetComponent<DeliverdPackage>();

        packagesDestinationsTable = GameObject.FindGameObjectsWithTag("PackageDestination");
        packagesDestinations = new List<GameObject>(packagesDestinationsTable);
        notification = GameObject.FindGameObjectWithTag("NotificationPickPackage");
        notification.SetActive(false);

        graph = GameObject.Find("Graph");
        
    }
    void Update()
    {
        if (packagesDestinations.Count() == 0)
        {
            EndGame();
        }


        if (pickPackage.packagePicked && !this.packageInDelivery)
        {
            packageInDelivery = true;

            selectPackageDestination();
            StartCoroutine(ShowNotification("Paczka zosta³a odebrana", new Color32(42, 132, 69, 255)));
        }

        if (this.packageInDelivery)
        {
            if (this.currentPackageDestination.GetComponent<DeliverdPackage>().deliverdPackage)//paczka dostarczona
            {

                StartCoroutine(ShowNotification("Paczka zosta³a dostarczona", new Color32(00, 00, 255, 150)));
                this.currentPackageDestination.GetComponent<DeliverdPackage>().resetDeliverPoint();
                this.pickPackage.resetPickPoint();

                packageInDelivery = false;
                this.currentPackageDestination.GetComponent<SpriteRenderer>().color = new Color32(0, 0, 0, 255);
                packagesDestinations.Remove(this.currentPackageDestination);
            }

        }

       

    }
    public void selectPackageDestination()
    {
            GameObject destination = packagesDestinations[Random.Range(0, packagesDestinations.Count)];
           
            destination.GetComponent<SpriteRenderer>().color = new Color32(255, 0, 0, 255);
            this.currentPackageDestination = destination;
        

    }
    IEnumerator ShowNotification(string textPassed, Color32 desiredColor)
    {
        notificationText.text = textPassed;
        notificationImage.color = desiredColor;
        notification.SetActive(true);
        yield return new WaitForSeconds(showUpTime);
        notification.SetActive(false);

    }

    public void EndGame()
    {
        StartCoroutine(ShowNotification("EndGame", new Color32(00, 255, 00, 150)));
        UnityEditor.EditorApplication.isPlaying = false;
       
    }

    public int getPackageDestinationNodeId()
    {
        if (!this.currentPackageDestination)
            return -1;



        // find the nearest node from package 

        List<Node> instanceNodes =  graph.GetComponent<Algorythm>().getInstanceNodes();

        Node tMin = null;
        float minDist = Mathf.Infinity;
        Vector2 currentPos = currentPackageDestination.transform.position;
        foreach( Node node in instanceNodes)
        {
            float distance = Vector2.Distance(node.transform.position, currentPos);
            if(distance<minDist)
            {
                tMin = node;
                minDist = distance;
            }
        }

       // Node closestNode = tMin;

        Debug.Log(tMin.getIdNode());

        //zmienic || coresponding node
        return tMin.getIdNode();
    }

   
}
