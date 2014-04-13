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
        q1.question = "Who is Mario's brother?";
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
		q3.question = "Which is NOT a Pokémon game?";
		q3.answer1 = "Emerald";
		q3.answer2 = "Bronze";
		q3.correctAnswer = 1;
		Questions.Add(q3);

		Question q4 = new Question();
		q4.question = "Which is an island of Africa?";
		q4.answer1 = "Mayotte";
		q4.answer2 = "Angola";
		q4.correctAnswer = 0;
		Questions.Add(q4);

		Question q5 = new Question();
		q5.question = "Which country has the smallest population?";
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
		q7.question = "When was Facebook founded?";
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
		q9.question = "Year of Superman's first appearance?";
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

		Question q11 = new Question();
		q11.question = "Which is not a 3D tool?";
		q11.answer1 = "Traxol";
		q11.answer2 = "Maya";
		q11.correctAnswer = 0;
		Questions.Add(q11);

		Question q12 = new Question();
		q12.question = "Where did coffee originate from?";
		q12.answer1 = "Yemen";
		q12.answer2 = "Turkey";
		q12.correctAnswer = 0;
		Questions.Add(q12);

		Question q13 = new Question();
		q13.question = "Who is a playable character in Super Smash Bros?";
		q13.answer1 = "Mewtwo";
		q13.answer2 = "Ness";
		q13.correctAnswer = 1;
		Questions.Add(q13);

		Question q14 = new Question();
		q14.question = "Latin word for fart?";
		q14.answer1 = "Flatulus";
		q14.answer2 = "Eruct";
		q14.correctAnswer = 0;
		Questions.Add(q14);

		Question q15 = new Question();
		q15.question = "Which is not a place in Lord of the Rings?";
		q15.answer1 = "Minas Thorath";
		q15.answer2 = "Minas Morgul";
		q15.correctAnswer = 0;
		Questions.Add(q15);

		Question q16 = new Question();
		q16.question = "Which is the max level in WoW vanilla?";
		q16.answer1 = "60";
		q16.answer2 = "70";
		q16.correctAnswer = 0;
		Questions.Add(q16);

		Question q17 = new Question();
		q17.question = "Who has been the president of the USA?";
		q17.answer1 = "John tyler Jacksson";
		q17.answer2 = "Martin Van Buren";
		q17.correctAnswer = 1;
		Questions.Add(q17);

		Question q18 = new Question();
		q18.question = "Name of very known bug in Pokémon?";
		q18.answer1 = "Ningano";
		q18.answer2 = "Missingno";
		q18.correctAnswer = 1;
		Questions.Add(q18);

		Question q19 = new Question();
		q19.question = "How many levels are in Mario Bros?";
		q19.answer1 = "32";
		q19.answer2 = "26";
		q19.correctAnswer = 0;
		Questions.Add(q19);

		Question q20 = new Question();
		q20.question = "Frodo's sword is named?";
		q20.answer1 = "Narsil";
		q20.answer2 = "Sting";
		q20.correctAnswer = 1;
		Questions.Add(q20);

		Question q21 = new Question();
		q21.question = "Who is Iron Man?";
		q21.answer1 = "Tony Stark";
		q21.answer2 = "Steve Rogers";
		q21.correctAnswer = 0;
		Questions.Add(q21);

		Question q22 = new Question();
		q22.question = "What is Mario's profession?";
		q22.answer1 = "Plumber";
		q22.answer2 = "Pizza baker";
		q22.correctAnswer = 0;
		Questions.Add(q22);

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

