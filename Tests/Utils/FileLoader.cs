using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace AdventOfCode2020.Utils
{
    public class FileLoader
    {
        public static IEnumerable<T> ReadListFromFile<T>(string fileName)
        {
            var assembly = typeof(FileLoader).GetTypeInfo().Assembly;
            var names = assembly.GetManifestResourceNames();
            var resourceName = names.First(s => s.EndsWith(fileName, StringComparison.CurrentCultureIgnoreCase));

            using var stream = assembly.GetManifestResourceStream(resourceName);
            if (stream == null)
            {
                throw new FileNotFoundException("File not found", fileName);
            }
            
            var values = new List<T>();
            
            using var reader = new StreamReader(stream);
            string? line;
            while ((line = reader.ReadLine()) != null)
            {
                values.Add((T)Convert.ChangeType(line, typeof(T)));
            }

            return values;
        }
    }
}