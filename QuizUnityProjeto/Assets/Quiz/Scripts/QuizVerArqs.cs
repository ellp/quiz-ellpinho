using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;

public class QuizVerArqs : MonoBehaviour
{
    public static QuizVerArqs Instance { get; set; }
    public string quizDest;
    private string caminho;
    public List<string> quizes = new List<string>();
    public string nomeArqVazio = "QuizEmBranco.txt";
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
        caminho = Application.dataPath + "/StreamingAssets/QuizesArq/";
        VerificarArquivos();
    }
    void Start()
    {
        
    }
    public void VerificarArquivos()
    {
        quizes.Clear();
        var files = from file in Directory.EnumerateFiles(caminho) select file;
        foreach (var file in files)
        {
            if (file.EndsWith(".txt"))
                quizes.Add(file.Substring(file.LastIndexOf('/')+1));
        }
        quizes.Add(nomeArqVazio);
        if(!quizes.Contains(quizDest))
            quizDest = quizes[0];
    }
    public void DeletarQuiz()
    {
        File.Delete(caminho + quizDest);
    }

}
