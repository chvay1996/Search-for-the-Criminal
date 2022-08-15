using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Search_for_the_Criminal
{
    class Program
    {
        static void Main ( string [] args )
        {
            Work work = new Work ();
            work.Works ();
        }
    }

    class Work
    {
        private List<Criminal> _criminals = new List<Criminal> ();

        public Work ()
        {
            _criminals.Add ( new Criminal ( "Абрам Роман Петрович", 192, 120, "Русский", "Нет" ) );
            _criminals.Add ( new Criminal ( "Грозный Иван Иванович", 205, 100, "Чеченец", "Да" ) );
            _criminals.Add ( new Criminal ( "Вова Викторович Колбасин", 180, 120, "Русский", "Нет" ) );
            _criminals.Add ( new Criminal ( "Сергей Алексеевич Федоров", 210, 86, "Русский", "Да" ) );
            _criminals.Add ( new Criminal ( "Султан Никитович Носков", 170, 90, "Араб", "нет" ) );
            _criminals.Add ( new Criminal ( "Кирилл Николаевич Юдин", 151, 76, "Русский", "нет" ) );
            _criminals.Add ( new Criminal ( "Алексей Викторович Папонин", 180, 120, "Русский", "нет" ) );
            _criminals.Add ( new Criminal ( "Алах Аламович Алахич", 170, 90, "Араб", "да" ) );
            _criminals.Add ( new Criminal ( "Александр Тимурович Гарбов", 150, 60, "Украинец", "нет" ) );
            _criminals.Add ( new Criminal ( "Пётр Александрович Головач", 180, 120, "Русский", "да" ) );
            _criminals.Add ( new Criminal ( "Хабиб Хабибович Хабибов", 180, 90, "Чеченец", "да" ) );
            _criminals.Add ( new Criminal ( "Вова Викторович Колбасин", 180, 120, "Русский", "нет" ) );
            _criminals.Add ( new Criminal ( "Вадим Петрович Хлебкин", 150, 60, "Украинец", "нет" ) );
        }

        public void Works ()
        {
            bool isWork = true;
            string input;

            while ( isWork == true )
            {
                Console.WriteLine ( "\t\t\t\t\t Поиск преступников" );
                Console.WriteLine ( "1 - Показать весь список людей." +
                    "\n2 - Поиск." +
                    "\n3 - Выйти" );
                Console.Write ( "Введите номер задачи:\t" );
                input = Console.ReadLine ();

                switch ( input )
                {
                    case "1":
                        ShowPeople ();
                        break;
                    case "2":
                        SearchForPrisoners ();
                        break;
                    case "3":
                        isWork = false;
                        break;
                    default:
                        Console.WriteLine ("Хм... Кажется кто-то не туда нажал!");
                        break;
                }
                Console.ReadLine ();
                Console.Clear ();
            }
        }

        private void ShowPeople ()
        {
            foreach ( var criminal in _criminals )
            {
                criminal.ShowDetails ();
            }
        }

        private void SearchForPrisoners ()
        {
            Console.Write ("Введите рост преступника:\t");
            int height = int.Parse ( Console.ReadLine () );
            Console.Write ("Введите вес преступника:\t");
            int weight = int.Parse ( Console.ReadLine () );
            Console.Write ("Введите национальность преступника:\t");
            string nationality = Console.ReadLine ();

            var foundCriminal = from Criminal criminals in _criminals where criminals.Height == height && criminals.Weight == weight && criminals.Nationality == nationality select criminals;

            if ( foundCriminal.Count () == 0 )
            {
                Console.WriteLine ( "Таких преступников нет!" );
            }
            else
            {
                Console.WriteLine ( "\nНайден" );

                foreach ( var criminal in foundCriminal )
                {
                    criminal.ShowDetails ();
                }
            }
        }
    }

    class Criminal
    {
        public Criminal ( string fIO, int height, int weight, string nationality, string isCustody )
        {
            Height = height;
            Weight = weight;
            Nationality = nationality;
            IsCustody = isCustody;
            FIO = fIO;
        }

        public int Height { get; private set; }
        public int Weight { get; private set; }
        public string Nationality { get; private set; }
        public string IsCustody { get; private set; }
        public string FIO { get; private set; }

        public void ShowDetails ()
        {
            Console.WriteLine ( $"\n{FIO}, За решёткой - {IsCustody}, Рост - {Height}, Вес - {Weight}, Национальность - {Nationality}" );
        }
    }
}
/*Задача:
У нас есть список всех преступников.
В преступнике есть поля: ФИО, заключен ли он под стражу, рост, вес, национальность.
Вашей программой будут пользоваться детективы.
У детектива запрашиваются данные (рост, вес, национальность)
и детективу выводятся все преступники которые подходят под эти параметры, 
но уже заключенные под стражу выводиться не должны.*/