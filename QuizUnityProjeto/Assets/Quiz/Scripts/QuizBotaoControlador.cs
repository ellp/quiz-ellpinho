using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class QuizBotaoControlador : MonoBehaviour
{
    public Sprite btnNormal, btnPress;
    public TextMeshProUGUI txtNormal, txtPress;
    private Image img;
    private void Start()
    {
        img = GetComponent<Image>();
        Invoke("AttText", 0.1f);//chamar a função com delay para prevenir bug
    }
    
    public void Click()
    {
        img.sprite = btnPress;
        txtNormal.enabled = false;
        txtPress.enabled = true;
        Invoke("Reset", 0.1f);
    }
    private void Reset()
    {
        img.sprite = btnNormal;
        txtNormal.enabled = true;
        txtPress.enabled = false;
    }
    public void CarregarCena(string cena)
    {
        SceneManager.LoadScene(cena);
    }
    public void AttText()
    {
        txtPress.text = txtNormal.text;
    }
}
