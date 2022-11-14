using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleLinq
{
    class Program
    {
        static List<Letter> letters = new List<Letter>();
        static public List<int> GetNewLetterIds_ClassicWay()
        {
            var res = new List<int>();
            for (int i = 0; i < letters.Count(); i++)
            {
                if (letters[i].IsNew)
                    res.Add(letters[i].Id);
            }
            return res;
        }

        static public IEnumerable<int> GetNewLetterIds_LinqWay()
        {
            return letters.Where(letter => letter.IsNew).Select(letter => letter.Id);
        }
        static void Main(string[] args)
        {
            letters.Add (new Letter("Первое письмо"));
            letters.Add(new Letter("Про жука"));
            letters.Add(new Letter("Пауки окружают"));

            List<int> newLetters = GetNewLetterIds_ClassicWay();
            foreach (var id in newLetters) Console.WriteLine(id);

            letters[2].Read();
            var t = GetNewLetterIds_LinqWay(); // не выполнился запрос Linq
            //var t = GetNewLetterIds_LinqWay().ToList(); // выполнился запрос

            letters.Add(new Letter("Черная пятница"));

            foreach (var id in t) Console.WriteLine(id);
        }
    }

    class Letter
    {
        static int counter = 0;

        bool isNew = true;
        public int Id { get; }
        public string Mess { get; set; }

        public bool IsNew 
        {
            get { return isNew; }
        }

        public Letter(string mess)
        {
            Id = ++counter;
            Mess = mess;
        }

        public void Read()
        { isNew = false; }
    }
}
