using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows;

namespace Tester_prog
{
    class Repositiory
    {
        StringBuilder AskBuiler;
        Random randomer;
        List<string> args;
        string[] creator;


        List<string> total_questions;
        List<string> total_answers;

        List<string> passed_questions;
        List<string> passed_answers;


        public string question;
        public string[] answers;

        int total_questions_count;
        int pass_questions_count;
        int good_answers_count;

        int Concrete_Choose;

        public string Questions_Rest()
        {
            return $"Total = {pass_questions_count}/{total_questions_count}";
        }

        public string Correct_Answers()
        {
            return $"Сorrect = {good_answers_count}/{pass_questions_count}";
        }


        public Repositiory()
        {
            randomer = new Random();
            AskBuiler = new StringBuilder();
            args = new List<string>();
            total_questions = new List<string>();
            total_answers = new List<string>();

            passed_answers = new List<string>();
            passed_questions = new List<string>();

            total_questions_count = 0;
            pass_questions_count = 0;
            good_answers_count = 0;
            Concrete_Choose = 0;

            question = string.Empty;
            answers = new string[4];
        }

        public void Download(string Path)
        {
            randomer = new Random();
            AskBuiler = new StringBuilder();
            args = new List<string>();
            total_questions = new List<string>();
            total_answers = new List<string>();

            passed_answers = new List<string>();
            passed_questions = new List<string>();

            total_questions_count = 0;
            pass_questions_count = 0;
            good_answers_count = 0;
            Concrete_Choose = 0;

            question = string.Empty;
            answers = new string[4];

            char splitter = ' ';
            using(StreamReader ReadPath = new StreamReader(Path))
            {
                while (!ReadPath.EndOfStream)
                {
                    args.Add(ReadPath.ReadLine());
                }
            }

            foreach(string Line in args)
            {
                if(splitter == ' ')
                {
                    if (Line.Contains("=") )
                    {
                        splitter = '=';
                    }
                    else
                    {
                        splitter = '–';
                    }
                }
                creator = Line.Split(splitter);
                total_questions.Add(creator[0]);
                foreach (string String in creator)
                {
                    if(creator[0] != String)
                    {
                        AskBuiler.Append(String);
                    }
                }
                total_answers.Add(AskBuiler.ToString());

                AskBuiler.Remove(0, AskBuiler.Length);
            }

            total_questions_count = total_answers.Count;
            if(total_questions_count < 10)
            {
                MessageBox.Show("the test cannot have less than 10 questions, download more information");
                randomer = new Random();
                AskBuiler = new StringBuilder();
                args = new List<string>();
                total_questions = new List<string>();
                total_answers = new List<string>();

                passed_answers = new List<string>();
                passed_questions = new List<string>();

                total_questions_count = 0;
                pass_questions_count = 0;
                good_answers_count = 0;
                Concrete_Choose = 0;

                question = string.Empty;
                answers = new string[4];
            }
            else
            {
                Start();
            }
        }

        private void Start()
        {
            if(pass_questions_count != total_questions_count)
            {
                Concrete_Choose = randomer.Next(0, total_questions.Count);
                question = total_questions[Concrete_Choose];
                Ask_Printer();
            }
            else
            {
                MessageBox.Show($"Congratulations! You passed test! You answered correct to {good_answers_count} of {total_questions_count} questions");
                randomer = new Random();
                AskBuiler = new StringBuilder();
                args = new List<string>();
                total_questions = new List<string>();
                total_answers = new List<string>();

                passed_answers = new List<string>();
                passed_questions = new List<string>();

                total_questions_count = 0;
                pass_questions_count = 0;
                good_answers_count = 0;
                Concrete_Choose = 0;

                question = string.Empty;
                answers = new string[4];
            }
        }

        public void Ask_Printer()
        {
            int Random_Good_Ask = randomer.Next(0, 4);

            for(int i = 0; i < answers.Length; i++)
            {
                if(i == Random_Good_Ask)
                {
                    answers[i] = Button_Text_Builder(total_answers[Concrete_Choose]);
                }
                else
                {
                    if (pass_questions_count + 6 >= total_questions_count)
                    {
                        answers[i] = Button_Text_Builder(passed_answers[Random_Ask()]);
                    }
                    else
                    {
                        answers[i] = Button_Text_Builder(total_answers[Random_Ask()]);
                    }
                }
            }


        }

        private int Random_Ask()
        {
            bool Find = false;

            int return_pos;


            if (pass_questions_count + 6 >= total_questions_count)
            {
                while (true)
                {
                    Find = false;
                    return_pos = randomer.Next(0, passed_questions.Count);

                    if (passed_questions[return_pos] == total_answers[Concrete_Choose])
                    {
                        Find = true;
                    }

                    foreach (string Ask in answers)
                    {
                        if (passed_questions[return_pos] == Ask)
                        {
                            Find = true;
                        }
                    }

                    if(Find == false)
                    {
                        return return_pos;
                    }
                }
            }
            else
            {
                while (true)
                {
                    Find = false;
                    return_pos = randomer.Next(0, total_questions.Count);

                    if (total_answers[return_pos] == total_answers[Concrete_Choose])
                    {
                        Find = true;
                    }
                    foreach (string Ask in passed_answers)
                    {
                        if (total_answers[return_pos] == Ask)
                        {
                            Find = true;
                        }
                    }

                    foreach (string Ask in answers)
                    {
                        if (total_answers[return_pos] == Ask)
                        {
                            Find = true;
                        }
                    }

                    if (Find == false)
                    {
                        return return_pos;
                    }

                }
            }
        }


        public void Click(string Ask)
        {
            if (Ask == Button_Text_Builder(total_answers[Concrete_Choose]))
            {
                good_answers_count++;
            }
            else
            {
                MessageBox.Show($"Correct answer:\n{total_answers[Concrete_Choose]}");
            }

            passed_answers.Add(total_answers[Concrete_Choose]);
            passed_questions.Add(total_questions[Concrete_Choose]);

            total_answers.Remove(total_answers[Concrete_Choose]);
            total_questions.Remove(total_questions[Concrete_Choose]);

            pass_questions_count++;


            Start();
        }

        private string Button_Text_Builder(string StringToBuild)
        {
            string FinishString = string.Empty;
            AskBuiler.Remove(0, AskBuiler.Length);
            foreach(string String in StringToBuild.Split(' '))
            {
                AskBuiler.Append(String + " ");
                if (AskBuiler.Length >= 70)
                {
                    FinishString += "\n";
                    AskBuiler.Remove(0, AskBuiler.Length);
                }
                FinishString += String + " ";
            }
            return FinishString;
        }
    }
}
