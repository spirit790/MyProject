using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed = 1f;
    public RaycastHit hit;
    public RaycastHit hit2; 

    Transform tr;
    public GameMgr gameMgr;
    public Button rBtn;
    public Button lBtn;
    public Button uBtn;
    public Button dBtn;



    public void Start()
    {
        gameMgr = GameObject.Find("GameMgr").GetComponent<GameMgr>();
        rBtn = GameObject.Find("Right").GetComponent<Button>();
        lBtn = GameObject.Find("Left").GetComponent<Button>();
        uBtn = GameObject.Find("Up").GetComponent<Button>();
        dBtn = GameObject.Find("Down").GetComponent<Button>();

        rBtn.onClick.AddListener(OnclickRight);
        lBtn.onClick.AddListener(OnclickLeft);
        uBtn.onClick.AddListener(OnclickUp);
        dBtn.onClick.AddListener(OnclickDown);
    }


    void Update()
    {
        MoveD();
    }

    public void MoveD()
    {
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            //SavePlLastState();
            MoveSystem(Vector3.left);
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            //SavePlLastState();
            MoveSystem(Vector3.right);
        }
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            //SavePlLastState();
            MoveSystem(Vector3.back);
        }
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            //SavePlLastState();
            MoveSystem(Vector3.forward);
        }
    }

    public void MoveSystem(Vector3 dir)
    {
        
        if (Physics.Raycast(transform.position, transform.TransformDirection(dir), out hit, 1.0f))
        {
            tr = hit.collider.transform;
            if (hit.collider.tag == "Ball")
            {
                if (Physics.Raycast(tr.position, tr.TransformDirection(dir), out hit2, 1.0f))
                {
                    if (hit2.collider.tag == "Ball") { }
                    else if (hit2.collider.tag == "Wall") { }
                    else if (hit2.collider.tag == "Bucket") { }
                    else
                    {
                        transform.Translate(dir);
                        tr.Translate(dir);
                        gameMgr.CheckBallPosition();
                        gameMgr.PlayerMoveCount();
                    }
                }
                else
                {
                    transform.Translate(dir);
                    tr.Translate(dir);
                    gameMgr.CheckBallPosition();
                    gameMgr.PlayerMoveCount();
                }
            }
        }
        else
        {
            transform.Translate(dir);
            gameMgr.CheckBallPosition();
            gameMgr.PlayerMoveCount();
        }
    }



    //public void movepllist()
    //{
    //    playerpositions.add(transform.position);
    //}
    //public void moveballlist()
    //{
    //    if (hit.collider.tag != "ball")
    //    {
    //        ballpositions.add(vector3.zero);
    //    }
    //    else
    //    {
    //        ballpositions.add(tr.position);
    //    }        
    //}
    //public void Movecancell()
    //{
    //    if (playerPositions.Count == 0)
    //        return;

    //    tr.position = ballPositions[ballPositions.Count - 1];
    //    transform.position = playerPositions[playerPositions.Count - 1];

    //    ballPositions.RemoveAt(ballPositions.Count - 1);
    //    playerPositions.RemoveAt(playerPositions.Count - 1);

    //    moveCount--;
    //    Count.text = moveCount.ToString();
    //}



    public void OnclickRight()
    {
        MoveSystem(Vector3.left);
    }
    public void OnclickLeft()
    {
        MoveSystem(Vector3.right);
    }
    public void OnclickUp()
    {
        MoveSystem(Vector3.back);
    }
    public void OnclickDown()
    {
        MoveSystem(Vector3.forward);
    }    
}