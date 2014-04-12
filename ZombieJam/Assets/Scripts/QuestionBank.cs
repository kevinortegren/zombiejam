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
        q.question = "2+1?";
        q.answer1 = "3";
        q.answer2 = "5";
        q.correctAnswer = 0;
        Questions.Add(q);

        Question q1 = new Question();
        q1.question = "Who is Marios brother?";
        q1.answer1 = "Solid Snake";
        q1.answer2 = "Luigi";
        q1.correctAnswer = 1;
        Questions.Add(q1);

		Question q2 = new Question();
		q2.question = "What hero wears green?";
		q2.answer1 = "Link";
		q2.answer2 = "Zelda";
		q2.correctAnswer = 0;
		Questions.Add(q2);

		Question q3 = new Question();
		q3.question = "NOT a pokemon game?";
		q3.answer1 = "Emerald";
		q3.answer2 = "Bronze";
		q3.correctAnswer = 1;
		Questions.Add(q3);

		Question q4 = new Question();
		q4.question = "A island of africa?";
		q4.answer1 = "Mayotte";
		q4.answer2 = "Angola";
		q4.correctAnswer = 0;
		Questions.Add(q4);

		Question q5 = new Question();
		q5.question = "Smallest population in country?";
		q5.answer1 = "Pitcairn islands";
		q5.answer2 = "Cocos islands";
		q5.correctAnswer = 0;
		Questions.Add(q5);

		Question q6 = new Question();
		q6.question = "What does Sonic gather?";
		q6.answer1 = "Coins";
		q6.answer2 = "Rings";
		q6.correctAnswer = 1;
		Questions.Add(q6);

		Question q7 = new Question();
		q7.question = "Facebook was founded?";
		q7.answer1 = "2004";
		q7.answer2 = "2003";
		q7.correctAnswer = 0;
		Questions.Add(q7);

		Question q8 = new Question();
		q8.question = "What hero came first?";
		q8.answer1 = "Batman";
		q8.answer2 = "Superman";
		q8.correctAnswer = 1;
		Questions.Add(q8);

		Question q9 = new Question();
		q9.question = "year of Supermans first apperance?";
		q9.answer1 = "1938";
		q9.answer2 = "1939";
		q9.correctAnswer = 0;
		Questions.Add(q9);

		Question q10 = new Question();
		q10.question = "Who killed Superman?";
		q10.answer1 = "Dr Doom";
		q10.answer2 = "Doomsday";
		q10.correctAnswer = 1;
		Questions.Add(q10);

        initied = true;   
    }

    public static Question GetQuestion()
    {
        int r = Random.Range(0, Questions.Count-1);

        //print("R: " + r + " - " + Questions.Count);

        Question q = Questions[r];
        Questions.Remove(q);

        return q;
    }

}

