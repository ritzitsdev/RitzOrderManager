using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace OrderDispatcher
{
  public class LogIt
  {
    public LogIt(string userMsg)
    {
      DateTime dateToday = DateTime.Now;
      string timeStamp = dateToday.ToString();
      //string logPath = @"C:\Program Files\ITS\Ritz_Order_Manager\Logs\OrderManagerLog.txt";
      string logPath = GlobalClass.logFile;

      File.AppendAllText(logPath, timeStamp + " -- " + userMsg + Environment.NewLine);
    }
  }
}
