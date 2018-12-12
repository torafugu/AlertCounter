using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlertCounter
{
    class Program
    {
        static void Main(string[] args)
        {
            const int ALERT_ID_INDEX = 0;
            const int RESULT_CODE_INDEX = 13;


            Hashtable alertIDCount = new Hashtable();
            Hashtable alertIDResultCd = new Hashtable();

            String line;
            FileStream fs = new FileStream(args[0], FileMode.Open);
            StreamReader sr = new StreamReader(fs);
            while ((line = sr.ReadLine()) != null)
            {
                string[] arr = line.Split('\t');
                String alertID = arr[ALERT_ID_INDEX];
                String resultCode = arr[RESULT_CODE_INDEX];

                //if (resultCode.Length > 3 && !resultCode.EndsWith("@")) {
                if (resultCode.Length == 3 && alertID.StartsWith("inb"))
                {
                    if (alertIDCount[alertID] == null)
                    {
                        alertIDCount[alertID] = 1;
                        alertIDResultCd[alertID] = resultCode;
                        System.Console.WriteLine(alertID + ":" + alertIDResultCd[alertID]);
                    } else
                    {
                        alertIDCount[alertID] = (int)alertIDCount[alertID] + 1;
                        alertIDResultCd[alertID] = alertIDResultCd[alertID] + "," + resultCode;

                        //if ((int)alertIDCount[alertID] > 3)
                        //{
                            System.Console.WriteLine(alertID + ":" + alertIDResultCd[alertID]);
                        //}
                    }
                }                     
            }
            sr.Close();
            fs.Close();
        }
    }
}
