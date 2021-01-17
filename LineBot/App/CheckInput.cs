//using System;
//using System.Text.RegularExpressions;

//namespace LineBot.App
//{
//    public class CheckInput
//    {
//        public CheckInput()
//        {
//        }
//    }
//    static public bool CheckInput(string dialogue, string input)
//    {
//        bool result = true;
//        switch (dialogue)
//        {
//            case ("answer"):
//                result = CheckAnswerFormat(input);
//                break;
//            case ("studentId"):
//                result = CheckStudentIdFormat(input);
//                break;
//            default: break;
//        }
//        return result;
//    }

//    static public bool CheckStudentIdFormat(string input)
//    {
//        bool result = true;
//        if (!Regex.IsMatch(input, @"^stu_[1-4][0-9]*$"))
//        {
//            result = false;
//        }
//        return result;
//    }

//    static public bool CheckAnswerFormat(string input)
//    {
//        bool result = true;
//        if (input.Length != 5) result = false;
//        if (!Regex.IsMatch(input, @"^[a-eA-E]*$"))
//        {
//            result = false;
//        }
//        return result;
//    }
//}
