using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OrderDispatcher
{
  static class GlobalClass
  {
    private static string OrderDispatcherXml = @"C:\Program Files\ITS\Ritz_Order_Manager\OrderManager.xml";
    private static string logPath = @"C:\Program Files\ITS\Ritz_Order_Manager\Logs\OrderManagerLog.txt";

    public static string pathsXML
    {
      get { return OrderDispatcherXml; }
      set { OrderDispatcherXml = value; }
    }

    public static string logFile
    {
      get { return logPath; }
      set { logPath = value; }
    }
  }
}
