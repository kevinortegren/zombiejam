using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Question
{
    public string question;
    public string answer1;
    public string answer2;
    public int correctAnswer;
}

public class QuestionBank : MonoBehaviour
{
    public static List<Question> Questions = new List<Question>();

    private static bool initied = false;

    public static void Initialize()
    {
        if (initied)
            return;

        Question q = new Question();
        q.question = "Hello?";
        q.answer1 = "Yes";
        q.answer2 = "No";
        q.correctAnswer = 1;
        Questions.Add(q);

        Question q1 = new Question();
        q1.question = "Second Question!";
        q1.answer1 = "Yes2";
        q1.answer2 = "No2";
        q1.correctAnswer = 0;
        Questions.Add(q1);

        initied = true;   
    }

    public static Question GetQuestion()
    {
        int r = Random.Range(0, Questions.Count-1);

        print("R: " + r + " - " + Questions.Count);

        Question q = Questions[r];

        Questions.Remove(q);

        return q;
    }

}

