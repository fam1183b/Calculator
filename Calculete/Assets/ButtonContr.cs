using System;
using UnityEngine;
using UnityEngine.UI;

public class ButtonContr : MonoBehaviour
{
    private Text TxtMane;
    public GameObject TxtMini;
    private float i = 0f;
    private string f = "";

    public void TextChang(string s)
    {
        TxtMane = GetComponent<Text>();
        if (TxtMane.text.Contains("е") || TxtMane.text.Contains("f"))
        {
            TxtMane.text = "";
        }
        if (s != "<" && s != "/" && s != "*" && s != "-" && s != "+" && s != "=" && s != ",")
        {
            TxtMane.text = TxtMane.text + s;
        }
        else if (s == "," && TxtMane.text.Contains(",") != true)
        {
            TxtMane.text = TxtMane.text + s;
        }
        else if (s == "<")
        {
            TxtMane.text = TxtMane.text.Remove(TxtMane.text.Length - 1);
        }
        else if (s == "=")
        {
            if (TxtMane.text == "")
            {
                TxtMane.text = TxtMini.GetComponent<Text>().text;
                TxtMini.GetComponent<Text>().text = "";
            }
            else
            {
                Calc("");
                TxtMane.text = TxtMini.GetComponent<Text>().text;
                TxtMini.GetComponent<Text>().text = "";
            }
        }
        else
        {
            Calc(s);
        }
    }
    private void Calc(string s)
    {
        i = Convert.ToSingle(TxtMane.text);
        TxtMane.text = "";
        if (TxtMini.GetComponent<Text>().text == "")
        {
            TxtMini.GetComponent<Text>().text = i.ToString();
        }
        else
        {
            switch (f)
            {
                case "/":
                    TxtMini.GetComponent<Text>().text = (Convert.ToSingle(TxtMini.GetComponent<Text>().text) / i).ToString();
                    break;
                case "*":
                    TxtMini.GetComponent<Text>().text = (Convert.ToSingle(TxtMini.GetComponent<Text>().text) * i).ToString();
                    break;
                case "-":
                    TxtMini.GetComponent<Text>().text = (Convert.ToSingle(TxtMini.GetComponent<Text>().text) - i).ToString();
                    break;
                case "+":
                    TxtMini.GetComponent<Text>().text = (Convert.ToSingle(TxtMini.GetComponent<Text>().text) + i).ToString();
                    break;
            }
        }
        f = s;
    }
}
