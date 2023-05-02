using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P8T3_Y2S1
{
    internal class Program
    {
        Student[] list = new Student[54];
      
        static void Main(string[] args)
        {
            new Program();
        }

        public Program()
        {
            Console.WriteLine("Sorted List:");
            Console.WriteLine();
            ReadFile();
            SelectionSort2();
            DisplayAll();
            Console.ReadLine();
            Console.Clear();

            Console.WriteLine("Unique Ages: ");
            Console.WriteLine();
            int imaxage = UniqueAges();
            Console.WriteLine();
            DisplayOfAge(imaxage);
            Console.ReadLine();

            Console.WriteLine("Role Call:");
            Console.WriteLine();
            ReadFile2();
            Console.ReadLine();

        }

        public void ReadFile()
        {
            String sline;
            StreamReader read = new StreamReader("Students.txt");
            for (int i = 0; i < list.Length; i++)
            {
                sline = read.ReadLine();
                String[] fields = sline.Split(',');
                list[i] = new Student(fields[0], int.Parse(fields[1]));
            }
            read.Close();
            
        }

        public void ReadFile2()
        {
            String sline;
            StreamReader read = new StreamReader("Students2.txt");
            for (int i = 0; i < 25; i++)
            {
                sline = read.ReadLine();
                String[] fields = sline.Split(',');
                Student temp = new Student(fields[0], int.Parse(fields[1]));
                bool done = false;
                for (int j = 0; j < list.Length ; j++)
                {
                    
                    if (temp.Equals(list[j]) == true)
                    {
                        Console.WriteLine(temp.getName() + " Present");
                        done = true;
                    }
                    
                }
                if (done == false)
                {
                    Console.WriteLine(temp.getName() + " Absent");
                }
            }
            read.Close();
        }

        public void DisplayAll()
        {
            for (int i = 0; i < list.Length;i++) 
            {
                list[i].Display();
            }
        }

        public int UniqueAges()
        {
            int iage, icount;
            iage = list[0].getAge();
            icount = 1;
            int imaxage = -1; int imaxagecount = -1;
            for (int i = 1; i < list.Length; i++)
            {
                if (i < list.Length && iage == list[i].getAge())
                {
                    icount++;
                }
                else
                {
                    if (icount > imaxagecount)
                    {
                        imaxage = iage;
                        imaxagecount = icount;
                    }
                    Console.WriteLine("{0} {1}", iage, icount);
                    icount = 1;
                    if (i < list.Length)
                    {
                        iage = list[i].getAge();
                    }
                }
            }
            Console.WriteLine("Most Frequent: {0}", imaxage);
            return imaxage;
        }

        public void DisplayOfAge(int imaxage)
        {
            bool bfound = false; //0 not found, 1 found, 2 lost
            for (int i = 0; i < list.Length; i++)
            {
                if (list[i].getAge() == imaxage)
                {
                    bfound = true;
                    Console.WriteLine(list[i].getName());
                }
                else
                {
                    if (bfound == true)
                    {
                        break;
                    }
                }
            }
        }

        
         public void SelectionSort2()
         {  
            int minPos;
            for (int pass = 0; pass < list.Length - 1; pass++)
            {
                minPos = FindMinPos(pass);   //Elements before pass are already sorted                
                Student temp = list[pass];
                list[pass] = list[minPos];
                list[minPos] = temp;
            }

         }

        public int FindMinPos(int pass)
        {
            if (pass == list.Length - 1)
            {
                return pass;
            }
            int minPos = FindMinPos(pass + 1);
            if (list[pass].getAge() < list[minPos].getAge())
            {
                return pass;
            }
            else
            {
                return minPos;
            }
        }
    }

    class Student
    {
        private string sname;
        private int iage;
        public Student (String sname, int iage)
        {
            this.sname = sname;
            this.iage = iage;
        }

        public override bool Equals(object obj)
        {
            Student objstudent = (Student)obj;  
            if ((objstudent.getName() == getName()) && (objstudent.getAge() == getAge()))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public String getName()
        {
            return sname;
        }

        public int getAge() 
        {
            return iage;    
        }

        public void Display()
        {
            Console.WriteLine("{0} {1}", getName(), getAge());
        }



    }

    
}

