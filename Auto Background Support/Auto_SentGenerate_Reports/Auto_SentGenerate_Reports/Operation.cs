using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace Auto_SentGenerate_Reports
{
    class Operation
    {
        public string ipconfig(string filePath)
        {
            StreamReader streamReader = new StreamReader(filePath);
            string text = streamReader.ReadToEnd();
            streamReader.Close();
            return text;
        }
    }
}
