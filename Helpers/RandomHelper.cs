using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;

namespace QuizBook.Helpers
{
    public static class RandomHelper
    {
        static QuizBookDbEntities1 _db = new QuizBookDbEntities1();
        
        public static void Shuffle<T>(this IList<T> list)
        {
            RNGCryptoServiceProvider provider = new RNGCryptoServiceProvider();
            int n = list.Count;
            while (n > 1)
            {
                byte[] box = new byte[1];
                do provider.GetBytes(box);
                while (!(box[0] < n * (Byte.MaxValue / n)));
                int k = (box[0] % n);
                n--;
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }

        public static List<T_Question> GetQuestions()
        {
           
            List<long> qTypes = _db.T_QuestionType.Select(s => s.Id).Distinct().ToList();
            List<T_Question> batchQuestion = new List<T_Question>();
            var QPerType = _db.T_Settings.FirstOrDefault(s => s.SettingsName == ErecruitHelper.Settings.QUESTIONS_PER_TYPE.ToString());
            var qpt = QPerType != null ? int.Parse(QPerType.SettingsValue) : 15;
            foreach (long typ in qTypes)
            {
                List<T_Question> chosen = new List<T_Question>();
                List<T_Question> questionPerType = _db.T_Question.Where(s => s.TypeId == typ && s.IsActive == true).OrderBy(s => s.PreambleId).ToList();

                

                Shuffle(questionPerType);

                questionPerType = questionPerType.Take(qpt).ToList();

                //Shuffle(questionPerType);

                batchQuestion.AddRange(questionPerType);
            }
            return batchQuestion;
        }
    }
}