using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassesAndObjects
{
    // класс даты
    class Date
    {
        private int day; // день
        private int month; // месяц
        private int year; // год

        // инициализация 
        public void Init(int d, int m, int y) 
        {
            day = d;
            month = m;
            year = y;
        }

        // конструктор класса 
        public Date(int d, int m, int y) 
        {
            day = d;
            month = m;
            year = y;
        }

        // узнать день 
        public int GetDay()   
        {
            return day;
        }

        // узнать месяц 
        public int GetMonth()
        {
            return month;
        }

        // узнать год 
        public int GetYear() 
        {
            return year;
        }
    }

}
