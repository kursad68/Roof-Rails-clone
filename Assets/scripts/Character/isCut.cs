using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class isCut : MonoBehaviour
{

    public bool OutTrigerSlicer,gameOver;
    public GameObject lowerPaddle;
    PrefabObject pf;
    CharacterMovement cM;
    GameManager GetGameManagerScript;
    public bool isCutStay,dance;
    private void OnEnable()
    {
        EventManager.GEtIsCutObject += gC;
        EventManager.onEnlargeSize += EnlargeSize;
        EventManager.onFireGround.AddListener(() => {
            
            DownSize();
            OnFireRemoveAndInstance();
        });
        EventManager.inPrefab.AddListener(createPrefab);
    }
    private void OnDisable()
    {
        EventManager.GEtIsCutObject -= gC;
     EventManager.inPrefab.RemoveListener(createPrefab);
     EventManager.onEnlargeSize-=EnlargeSize;
        EventManager.onFireGround.RemoveListener(()=> {
           
            DownSize();
            OnFireRemoveAndInstance();
            });
    }
    isCut gC()
    {
        return GetComponent<isCut>();
    }
   
    private void Start()
    {
        GetGameManagerScript = EventManager.getGameManager.Invoke();
        cM = EventManager.GEtMovement.Invoke();
       createPrefab();

    }
    private void Update()
    {
       if (!OutTrigerSlicer)
            transform.position =new Vector3(cM.transform.position.x,transform.position.y, cM.transform.position.z) ;
       else if (OutTrigerSlicer)
        transform.position= new Vector3(cM.transform.position.x,transform.position.y,transform.position.z);


        if (isCutStay == true)
        {
            StartCoroutine(İsCutOutTime());
        }
        else
        {
            StopAllCoroutines();
        }

        if (gameOver == true)
            GetGameManagerScript.lost();

    }
    IEnumerator İsCutOutTime()
    {
        yield return new WaitForSeconds(3f);
        if (isCutStay == true) 
        {
            if (GetGameManagerScript.isGameEnd == false) {
                GetGameManagerScript.isGameEnd = true;

                StartCoroutine(SpeedToReduce());
            }
            
        }
            

    }
    IEnumerator SpeedToReduce()
    {
        yield return new WaitForSeconds(0.3f);
        if (cM.speed >= 1)
        {
            cM.speed -= 1;
           
        }
        else
        {
            GetGameManagerScript.lost();
            
        }

        StartCoroutine(SpeedToReduce());
    }
    private void DownSize()
    {


        if (transform.localScale.y > 0.5f)
        {
            transform.localScale -= new Vector3(0, pf.GetComponent<Renderer>().bounds.size.z / 2, 0);

        }
        else
        {
            if (GetGameManagerScript.isGameWin == false)
                gameOver = true;
            else
                dance = true;
        }
    }
    private void EnlargeSize(float value)
    {
      
        transform.localScale += new Vector3(0, value, 0);
    }
    private void createPrefab()
    {
        pf = EventManager.GEtPrefabObject.Invoke();
    }

    private void OnFireRemoveAndInstance()
    {
        // GameObject lowPaddle = Instantiate(pf.gameObject, transform.position + new Vector3(0,0, GetComponent<Renderer>().bounds.size.z/2),Quaternion.Euler(90,0,0));
        // GameObject lowPaddle1 = Instantiate(pf.gameObject, transform.position - new Vector3(0, 0, GetComponent<Renderer>().bounds.size.z/2), Quaternion.Euler(90,0,0));
        Debug.Log(gameOver);
        if (!gameOver&&dance==false)
        {
            GameObject lowPaddle = Instantiate(pf.gameObject, transform.position + new Vector3(0, 0, GetComponent<Renderer>().bounds.size.z / 2), Quaternion.Euler(90, 0, 0));
            GameObject lowPaddle1 = Instantiate(pf.gameObject, transform.position - new Vector3(0, 0, GetComponent<Renderer>().bounds.size.z / 2), Quaternion.Euler(90, 0, 0));
        }
      
    }
}
