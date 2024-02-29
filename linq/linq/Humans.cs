using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using static System.Convert;

namespace linq
{
    struct People
    {
        public string Name;
        public string Surname;
        public string Patronymic;
        public int Age;
        public int Weight;
        public override string ToString()
        {
            return $"{Name} {Surname} {Patronymic}. Возраст {Age} и вес {Weight}";
        }
    }
    internal class Humans
    {
        public List<People> peoples { get; private set; }
        public Humans(string PathToData)
        {
            if (File.Exists(PathToData))
            {
                Initialize(PathToData);
            }
        }
        public void Fill_ListBox(ListBox list)
        {
            list.Items.Clear();
            foreach (var obj in peoples)
            {
                list.Items.Add(obj);
            }
        }
        private void Initialize(string path)
        {
            peoples = new List<People>();
            string[] lines = File.ReadAllLines(path);
            People obj = new People();
            foreach (string line in lines)
            {
                string[] splits;
                if (line.Trim() != null)
                {
                    splits = line.Trim().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    obj.Name = splits[0];
                    obj.Surname = splits[1];
                    obj.Patronymic = splits[2];
                    obj.Age = ToInt32(splits[3]);
                    obj.Weight = ToInt32(splits[4]);
                    peoples.Add(obj);
                }
            }
        }
        
    }
}
