using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EzySlice;
public class Slicer : MonoBehaviour
{


    public Material material;
    public GameObject CutObject;
    isCut GetCup;
    CharacterMovement cM;
    private void Start()
    {
        GetCup = EventManager.GEtIsCutObject.Invoke();
        cM = EventManager.GEtMovement.Invoke();
    }
    private void OnEnable()
    {

    }
    private void OnDisable()
    {


    }
    Slicer slicer()
    {
        return GetComponent<Slicer>();
    }

    public SlicedHull cut(GameObject gam, Material mat = null)
    {
        return gam.Slice(transform.position, transform.up, mat);
    }
    void addComponent(GameObject gam)
    {
      //  gam.AddComponent<BoxCollider>();
   //gam.GetComponent<CapsuleCollider>().center=new Vector3(gam.GetComponent<CapsuleCollider>().center.x ,0, gam.GetComponent<CapsuleCollider>().center.z);
        // gam.AddComponent<MeshCollider>().convex=true;
        // gam.GetComponent<MeshCollider>().isTrigger = false;
        // gam.AddComponent<Rigidbody>();
         //gam.GetComponent<Rigidbody>().mass = 0.5f;
        //gam.GetComponent<Rigidbody>().freezeRotation=true;
        // gam.GetComponent<Rigidbody>().interpolation=RigidbodyInterpolation.Extrapolate;
        //gam.AddComponent<isCut>();
        //gam.name = "PADDLE";
        
      
      EventManager.inPrefab.Invoke();
    }
    private void Update()
    {


    }
    private void OnTriggerEnter(Collider other)
    {
        GetCup = EventManager.GEtIsCutObject.Invoke();
        if (other.gameObject.GetComponent<isCut>())
        {

            CutObject = other.gameObject;
            material = other.gameObject.GetComponent<MeshRenderer>().material;
            gameObject.GetComponent<BoxCollider>().isTrigger = false;
            Debug.Log("girdi");
            objeDoCut();
        }
    }
 
    private void objeDoCut()
    {
        SlicedHull cutObje = cut(CutObject, material);
        GameObject cutObjeUp = cutObje.CreateUpperHull(CutObject.gameObject, material);
        GameObject cutObjeLower = cutObje.CreateLowerHull(CutObject.gameObject, material);

        if (cM.transform.position.z < transform.position.z)
        {
            
        CutObject.transform.localScale = new Vector3(CutObject.transform.localScale.x, cutObjeLower.GetComponent<Renderer>().bounds.size.z/2, CutObject.transform.localScale.z);
            CutObject.transform.position = cutObjeLower.transform.position - new Vector3(0, 0, cutObjeUp.GetComponent<Renderer>().bounds.size.z / 4);
      
            Destroy(cutObjeLower);
            StartCoroutine(OutTriger());
        }
        else
        {
            CutObject.transform.localScale = new Vector3(CutObject.transform.localScale.x, cutObjeUp.GetComponent<Renderer>().bounds.size.z/2, CutObject.transform.localScale.z);
            CutObject.transform.position = cutObjeUp.transform.position + new Vector3(0,0,cutObjeUp.GetComponent<Renderer>().bounds.size.z / 4);
           
            Destroy(cutObjeUp);
            StartCoroutine(OutTriger());

        }
        

    }
    IEnumerator OutTriger()
    {
        GetCup.OutTrigerSlicer = true;
 
        yield return new WaitForSeconds(1.5f);
        GetCup.OutTrigerSlicer = false;
    }

}