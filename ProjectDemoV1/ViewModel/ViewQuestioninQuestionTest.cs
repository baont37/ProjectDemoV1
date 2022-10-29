using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectDemoV1.ViewModel
{
    public class ViewQuestionInQuestionTest
    {
        public string TestDetailId { get; set; }

        public IReadOnlyList<QuestionInQuestionTest> Questions;

        public ViewQuestionInQuestionTest()
        {
            Questions = new List<QuestionInQuestionTest>();
        }
    }

    public class QuestionInQuestionTest
    {
        public QuestionInQuestionTest()
        {

        }

        public QuestionInQuestionTest(int quetionTestId, int testDetailId, int questionId, int userAnswer, string questionContent, string optionA, string optionB, string optionC, string optionD, byte[] image, int answerId)
        {
            QuetionTestId = quetionTestId;
            TestDetailId = testDetailId;
            QuestionId = questionId;
            UserAnswer = userAnswer;
            QuestionContent = questionContent;
            OptionA = optionA;
            OptionB = optionB;
            OptionC = optionC;
            OptionD = optionD;
            AnswerId = answerId;
            Image = image;
        }

        public int QuetionTestId { get; set; }
        public int TestDetailId { get; set; }
        public int QuestionId { get; set; }
        public int UserAnswer { get; set; }
        public string QuestionContent { get; set; }
        public string OptionA { get; set; }
        public string OptionB { get; set; }
        public string OptionC { get; set; }
        public string OptionD { get; set; }
        public byte[] Image { get; set; }
        public int AnswerId { get; set; }
    }
}