using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kino
{
    class Program
    {

        static int Saali_suurus()//размер зала
        {
            Console.WriteLine("Vali saali suurus: 1,2,3");//выбор размера зала
            int suurus = int.Parse(Console.ReadLine());//считывает переменную suurus, которая считывает со строки
            return suurus;//возращает suurus
        }
        static int[,] saal = new int[,] { };//двухмерный массив с запятой 
        static int[] ost = new int[] { };//одномерный массив
        static int kohad, read, mitu; 
        static void Saali_taitmine(int suurus)//тут зал строится
        {
            Random rnd = new Random();//Создается рандом 
            if (suurus == 1)//если первый зал(1) указал пользователь, то в зале будет
            {
                kohad = 20;//20 мест в каждом ряду
                read = 10;//10 рядов
            }
            else if (suurus == 2)//если второй зал(2) указал пользователь, то в зале будет
            {
                kohad = 20;//20 мест в каждом ряду
                read = 20;//20 рядов
            }
            else if (suurus == 3)//если третий зал(3) указал пользователь, то в зале будет
            {
                kohad = 30;//30 мест в каждом ряду
                read = 20;//20 рядов
            }
            else//иначе
            {
                Console.WriteLine("Sellist saali pole olemas");//пишет, что такого зала не существует
                //не работает, не успел
            }
            saal = new int[read, kohad];//объявляется двумерный массив saal 

            for (int rida = 0; rida < read; rida++)//если rida < read то прибавляется 1 и так до максимума read(максимум зависит от выбора размера зала)
            {
                for (int koht = 0; koht < kohad; koht++)//если koht < kohad то прибавляется 1 и так до максимума kohad(максимум зависит от выбора размера зала)
                {
                    saal[rida, koht] = rnd.Next(0, 2);//в зале появляются рандомные цифра 0 или 1
                }
            }
        }
        static void Saal_ekraanile()//тут происходит вывод на экран зала
        {
            Console.Write("   ");//отступ от левой стороны
            for (int koht = 0; koht < kohad; koht++)//начинается цикл 
            {
                if (koht.ToString().Length == 2)
                {
                    Console.Write(" {0}", koht + 1);
                }
                else
                {
                    Console.Write(" {0}", koht + 1);
                }
            }
            Console.WriteLine();
            for (int rida = 0; rida < read; rida++)//создаются ряды
            {
                Console.Write("\nRida " + (rida + 1).ToString() + ": ");//выводятся на экран Rida: и каждый раз плюсуется Rida1, Rida2...(максимум зависит от размера зала)
                for (int koht = 0; koht < kohad; koht++)//создаются местра в рядах
                {
                    Console.Write(saal[rida, koht] + "   ");//выводятся на экран нули(свободно) и единицы(место занятно)
                }
            }
        }
        static void Muuk()//тут производится покупка билетов
        {
            Console.WriteLine("\nSisesta rida:");//Спрашивает какой ряд
            int pileti_rida = int.Parse(Console.ReadLine());//Считывает какой ряд указал пользователь
            Console.WriteLine("Mitu piletid:");//Спрашивает сколько билетов
            mitu = int.Parse(Console.ReadLine());//Считывает сколько билетов купить
            ost = new int[mitu];//объявляется одномерный массив ost
            int p = (kohad - mitu) / 2;//объявляется переменная p, в котором места минус количество билетов делённое на 2
            bool t = false;//bool true или false 
            int k = 0;//объявляется переменная k
            do
            {
                if (saal[pileti_rida, p] == 0)
                {
                    ost[k] = p;
                    Console.WriteLine("koht {0} on vaba", p);//выводит на экран, то что место свободно
                    t = true;
                }
                else
                {
                    Console.WriteLine("koht {0} on kinni", p);//выводит на экран, то что место занято
                    t = false;
                    ost = new int[mitu];//объявляется одномерный массив ost покупки билетов
                    k = 0;//счётчик
                    p = (kohad - mitu) / 2;
                    break;
                }//прерывается программа
                p = p + 1;//
                k++;//прибавляется по 1 к счётчику
            } while (mitu != k);
            if (t == true)//если место свободно, тогда будет получено место для пользователя
            {
                Console.WriteLine("Sinu kohad on:");//выводит на экран твоё место
                foreach (var koh in ost)//
                {
                    Console.WriteLine("{0}\n", koh);//Выводит на экран  твоё место
                }
            }
            else//иначе
            {
                Console.WriteLine("Selles reas ei ole vabu kohti. Kas tahad teises reas otsida?");//выводит на экран то что нет мест в ряду и спрашивают не хотят ли выбрать другой ряд
            }
        }
        static void Main(string[] args)  
        {
            int suurus = Saali_suurus();//объявляется переменная suurus 
            Saali_taitmine(suurus);//
            while (true)//бесконечный цикл
            {
                Saal_ekraanile();//работает в цикле вывод на экран зала
                Muuk();//работает в цикле покупка билетов
            }
        }
    }
}
