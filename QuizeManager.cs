using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using Unity.VisualScripting.Antlr3.Runtime;
using Unity.VisualScripting;

public class QuizeManager : MonoBehaviour
{
    public TextAsset csvFile;
    private List<QuestionData> questions = new List<QuestionData> ();//���f�[�^��ێ�����

    // Start is called before the first frame update
    void Start()
    {
        if (csvFile != null) 
        {
            ParserCSV();
            DisplayQuestion(0);
        }
        else
        {
            Debug.LogError("CSV�t�@�C�����ǂݍ��݂܂���");
        }
        
    }

    void ParserCSV()
    {
        string[] lines = csvFile.text.Split('\n');
        for (int i = 0; i < lines.Length; i++)
        {
            string[] data = lines[i].Split(',');
            QuestionData question= new QuestionData();
            question.questionText = data[0];
            question.choices = new string[] { data[1], data[2], data[3], data[4] };
            question.correnctAnswer = int.Parse(data[5]);

            questions.Add(question);

        }
    }
    // Update is called once per frame
    void DisplayQuestion(int index)
    {
        if (index >= 0 && index <questions.Count)
        {
            QuestionData currentQuestion = questions[index];
            Debug.Log($"���:{currentQuestion.questionText}");
            //�I�����\��
            for (int i = 0;i < currentQuestion.choices.Length; i++)
            {
                Debug.Log($"�I����{i + 1}:{currentQuestion.choices[i]}");
            }
            //����ԍ���\��
            Debug.Log($"����ԍ�:{currentQuestion.correnctAnswer}");
        }
        else
        {
            Debug.LogError("�w�肳�ꂽ���͑��݂��܂���B");
        }
    }

    public class QuestionData
    {
        public string questionText;
        public string[] choices;
        public int correnctAnswer;
    }
}
