using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitychanRote : MonoBehaviour
{
    public Button rBtn;
    public Button lBtn;
    public Button uBtn;
    public Button dBtn;
    void Start()
    {
        rBtn = GameObject.Find("Right").GetComponent<Button>();
        lBtn = GameObject.Find("Left").GetComponent<Button>();
        uBtn = GameObject.Find("Up").GetComponent<Button>();
        dBtn = GameObject.Find("Down").GetComponent<Button>();

        rBtn.onClick.AddListener(OnclickRight);
        lBtn.onClick.AddListener(OnclickLeft);
        uBtn.onClick.AddListener(OnclickUp);
        dBtn.onClick.AddListener(OnclickDown);
    }

    // Update is called once per frame
    void Update()
    {
        RightRote();
        LeftRote();
        UpRote();
        DownRote();
    }

    public void RightRote()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.rotation = Quaternion.Euler(0, -90, 0);
        }
    }
    public void LeftRote()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.rotation = Quaternion.Euler(0, 90, 0);

        }
    }
    public void UpRote()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }
    public void DownRote()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }

    public void OnclickRight()
    {
        transform.rotation = Quaternion.Euler(0, -90, 0);
    }
    public void OnclickLeft()
    {
        transform.rotation = Quaternion.Euler(0, 90, 0);
    }
    public void OnclickUp()
    {
        transform.rotation = Quaternion.Euler(0, 180, 0);
    }
    public void OnclickDown()
    {
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }
}
