﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _00_AdressBook.Services;

internal class FileService
{
    public void Save(string filePath, string content)
    {
        using var sw = new StreamWriter(filePath);
        sw.WriteLine(content);
    }

    public string Read(string filePath, string v) 
    { 
        try
        {
            using var sr = new StreamReader(filePath);
            return sr.ReadToEnd();

        }
        catch { return null!; }
    }
}