using System;
using System.Collections.Generic;
using System.Linq;


namespace LINQLab
{
    class Program
    {
        static void Main(string[] args)
        {
            //---------------------For nums----------------------
            Console.WriteLine("FOR ARRAY OF NUMBERS");
            Console.WriteLine("----------------------\n");
            int[] nums = { 10, 2330, 112233, 10, 949, 3764, 2942 };

            //1
            int min = (from n in nums
                       select n).Min();
            Console.WriteLine($"Min: {min}");

            //2
            int max = (from n in nums
                       select n).Max();
            Console.WriteLine($"\nMax: {max}");

            //3
            int maxLess = (from n in nums
                           where n < 10000
                           select n).Max();
            Console.WriteLine($"\nMax (less than 10000): {maxLess}");

            //4
            int[] betweenTenHund = (from n in nums
                                    where n > 10 && n < 100
                                    select n).ToArray();
            Console.WriteLine("\nNumbers between 10 and 100:");
            PrintNums(betweenTenHund);
            //There are none in the provided list, so this result is and should be blank.

            //5
            int[] betweenHunThou = (from n in nums
                                    where n >= 100000 && n <= 999999
                                    select n).ToArray();
            Console.WriteLine("\nNumbers from 100000 and 999999:");
            PrintNums(betweenHunThou);

            //6
            int even = (from n in nums
                        where n % 2 == 0
                        select n).Count();
            Console.WriteLine($"\nTotal amount of even numbers: {even}");



            //---------------For students-----------------------

            List<Student> students = new List<Student>();
            students.Add(new Student("Jimmy", 13));
            students.Add(new Student("Hannah Banana", 21));
            students.Add(new Student("Justin", 30));
            students.Add(new Student("Sarah", 53));
            students.Add(new Student("Hannibal", 15));
            students.Add(new Student("Phillip", 16));
            students.Add(new Student("Maria", 63));
            students.Add(new Student("Abe", 33));
            students.Add(new Student("Curtis", 10));

            Console.WriteLine("\n\nFOR LIST OF STUDENTS");
            Console.WriteLine("---------------------");

            //1
            List<Student> over21 = (from s in students
                                    where s.Age >= 21
                                    select s).ToList();

            //2
            int oldestAge = (from s in students
                             select s.Age).Max();

            List<Student> oldestS = (from s in students
                                     where s.Age == oldestAge
                                     select s).ToList();

            Console.WriteLine("\nOldest Student:");
            PrintStudents(oldestS);



            //3
            int youngestAge = (from s in students
                               select s.Age).Min();

            List<Student> youngestS = (from s in students
                                       where s.Age == youngestAge
                                       select s).ToList();

            Console.WriteLine("\nYoungest Student:");
            PrintStudents(youngestS);



            //4 
            int oldestUnder = (from s in students
                               where s.Age < 25
                               select s.Age).Max();

            List<Student> studentUnder = (from s in students
                                          where s.Age == oldestUnder
                                          select s).ToList();
            Console.WriteLine("\nOldest student under 25");
            PrintStudents(studentUnder);


            //5

            List<Student> evenOver = (from s in students
                                      where s.Age > 21 && s.Age % 2 == 0
                                      select s).ToList();

            Console.WriteLine("\nStudents over 21 and even ages:");
            PrintStudents(evenOver);


            //6
            List<Student> teens = (from s in students
                                   where s.Age >= 13 && s.Age <= 19
                                   select s).ToList();

            Console.WriteLine("\nTeenaged students:");
            PrintStudents(teens);



            //7
            char[] vowels = { 'A', 'E', 'I', 'O', 'U' };
            List<Student> startsWithVowel = (from s in students
                                             where s.Name.IndexOfAny(vowels, 0, 1) == 0
                                             select s).ToList();

            Console.WriteLine("\nStudents whose name starts with a vowel:");
            PrintStudents(startsWithVowel);


        }
        public static void PrintNums(int[] nums)
        {
            foreach (int i in nums)
            {
                Console.WriteLine(i);
            }

        }
        public static void PrintStudents(List<Student> students)
        {
            foreach (Student s in students)
            {
                Console.WriteLine($"Name: {s.Name}");
                Console.WriteLine($"Age: {s.Age}");
            }
        }

    }
}
