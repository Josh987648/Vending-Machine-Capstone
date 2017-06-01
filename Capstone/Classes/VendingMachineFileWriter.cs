using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Capstone.Classes;

namespace Capstone.Classes
{
    public class VendingMachineFileWriter
    {
        private string fullPath;

        // logger! constructor 
        public VendingMachineFileWriter()
        {
            string directory = Directory.GetCurrentDirectory();
            this.fullPath = Path.Combine(directory, "log.txt");
        }

        public void LogMessage(string message)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(fullPath, true))
                {
                    sw.WriteLine(message);
                    sw.Flush();
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine("Error writing file " + ex.ToString());
            }
        }
    }
}

