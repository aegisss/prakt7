﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace проводник
{
    public class Cursor
    {
        public int max, min, pos;
        public Cursor(int max, int min, int pos)
        {
            this.max = max;
            this.min = min;
            this.pos = pos;
        }
    }

    public class Menuska
    {

        public static int Start(List<ReadedFile> files, string firstLine)
        {
            Console.Clear();
            Cursor cursor = new Cursor(files.Count, 1, 1);
            GetMenu.ShowMenu(GetMenu.ToMenuString(files), firstLine);
            while (true)
            {
                Console.SetCursorPosition(0, cursor.pos);
                Console.Write("->");
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.Q:
                        Outputi();
                        break;
                    case ConsoleKey.UpArrow:
                        Console.SetCursorPosition(0, cursor.pos);
                        Console.Write("  ");
                        if (cursor.pos == cursor.min)
                            cursor.pos = cursor.max;
                        else
                            cursor.pos--;
                        break;
                    case ConsoleKey.DownArrow:
                        Console.SetCursorPosition(0, cursor.pos);
                        Console.Write("  ");
                        if (cursor.pos == cursor.max)
                            cursor.pos = cursor.min;
                        else
                            cursor.pos++;
                        break;
                    case ConsoleKey.Escape:
                        return -1;
                    case ConsoleKey.Enter:
                        return cursor.pos;
                }
            }

        }

        public static int GB = 1073741824;
        public static void Outputi()
        {
            DriveInfo[] c = DriveInfo.GetDrives();
            Console.WriteLine("\n\n");
            foreach (DriveInfo d in c)
            {
                Console.WriteLine();
                Console.WriteLine(d.Name);
                Console.WriteLine(d.DriveFormat + " - тип диска");
                Console.WriteLine(d.TotalSize / (int)GB + "ГБ - Всего места");
                Console.WriteLine(d.AvailableFreeSpace / (int)GB + "ГБ - Осталось места");
            }
            Console.ReadKey();
            Program.Main(new string[0]);
        }
    }
}