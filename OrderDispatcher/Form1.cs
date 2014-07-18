using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Xml.Linq;
using System.Xml;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace OrderDispatcher
{
  public partial class Form1 : Form
  {
    public ListBox listBox;
    public Form1()
    {
      InitializeComponent();
      listBox = new ListBox();
      listBox.FormattingEnabled = true;
      listBox.Location = new System.Drawing.Point(12, 68);
      listBox.Name = "listBox";
      listBox.Size = new System.Drawing.Size(571, 238);
      listBox.TabIndex = 2;
      this.Controls.Add(listBox);
    }

    private void Form1_Load(object sender, EventArgs e)
    {
      showExisting();
      startMonitoring();
      watchOutlab();
      clearOldLogs();
    } // end Form1_Load

    public void showExisting()
    {
      string OrderDispatcherXml = GlobalClass.pathsXML;
      XDocument RitzOrderDispatcherXml = XDocument.Load(OrderDispatcherXml);
      var qryHotFolders = from f in RitzOrderDispatcherXml.Elements("folder_paths").Elements("incoming_orders").Elements("location")
                          select f;
      foreach (XElement location in qryHotFolders)
      {
        try
        {
          string[] orders = Directory.GetDirectories(location.Value, "*.order");
          foreach (string order in orders)
          {
            this.Invoke((MethodInvoker)delegate { listBox.Items.Add(String.Format("New Order Created -- {0}", order)); });
          }
        }
        catch (Exception e)
        { }
      }
    } // end showExisting

    public void startMonitoring()
    {
      string OrderDispatcherXml = GlobalClass.pathsXML;
      XDocument RitzOrderDispatcherXml = XDocument.Load(OrderDispatcherXml);
      var qryHotFolders = from f in RitzOrderDispatcherXml.Elements("folder_paths").Elements("incoming_orders").Elements("location")
                          select f;
      foreach (XElement location in qryHotFolders)
      {
        if (Directory.Exists(location.Value))
        {
          FileSystemWatcher fsWatcher = new FileSystemWatcher();
          fsWatcher.Path = location.Value;
          fsWatcher.Filter = "*.order";
          fsWatcher.IncludeSubdirectories = false;
          fsWatcher.NotifyFilter = NotifyFilters.CreationTime | NotifyFilters.DirectoryName | NotifyFilters.FileName;
          //fsWatcher.Created += new FileSystemEventHandler(OnCreated);
          fsWatcher.Renamed += new RenamedEventHandler(OnRenamed);
          fsWatcher.EnableRaisingEvents = true;
        }
      }
    } // end startMonitoring

    public void watchOutlab()
    {
      string OrderDispatcherXml = GlobalClass.pathsXML;
      XDocument RitzOrderDispatcherXml = XDocument.Load(OrderDispatcherXml);
      var outlabFolder = RitzOrderDispatcherXml.Descendants("outlab_folder").ElementAt(0).Value;

      FileSystemWatcher orderWatcher = new FileSystemWatcher();
      orderWatcher.Path = outlabFolder;
      orderWatcher.Filter = "*.order";
      orderWatcher.IncludeSubdirectories = false;
      orderWatcher.NotifyFilter = NotifyFilters.DirectoryName | NotifyFilters.FileName;
      orderWatcher.Deleted += new FileSystemEventHandler(OnDeleted);
      orderWatcher.EnableRaisingEvents = true;
    } // end watchOutlab

    public void OnDeleted(object sender, FileSystemEventArgs e)
    {
      string userMsg = "Order " + e.Name.Replace(".order", "") + " has been transmitted to the outlab.";
      this.Invoke((MethodInvoker)delegate { lblSettingsChanged.Text = userMsg; });
      logIt(userMsg);
    } // end OnDeleted

    public void OnCreated(object sender, FileSystemEventArgs e)
    {
      this.Invoke((MethodInvoker)delegate { listBox.Items.Add(String.Format("Path : \"{0}\" || Action : {1}", e.FullPath, e.ChangeType)); });
    } // end OnCreated

    public void OnRenamed(object sender, RenamedEventArgs e)
    {
      this.Invoke((MethodInvoker)delegate { listBox.Items.Add(String.Format("New Order Created -- {0}", e.FullPath)); });
      string userMsg = "New Order Created -- " + e.Name.Replace(".order", "");
      logIt(userMsg);
    } // end OnRenamed

    private void btnRefresh_Click(object sender, EventArgs e)
    {
      btnRefresh.Text = "Refreshing";
      for (int n = listBox.Items.Count - 1; n >= 0; --n)
      {
        listBox.Items.RemoveAt(n);
      }
      showExisting();
      btnRefresh.Text = "Refresh Order List";
      lblSettingsChanged.Text = "";
    } // end btnRefresh_Click

    private void btnPrintHere_Click(object sender, EventArgs e)
    {
      if (listBox.SelectedItem == null)
      {
        MessageBox.Show("Please select an order.");
      }
      else
      {
        moveDirectory("instore", listBox.SelectedItem);
      }
    } // end btnPrintHere_Click

    private void btnOutlab_Click(object sender, EventArgs e)
    {
      if (listBox.SelectedItem == null)
      {
        MessageBox.Show("Please select an order.");
      }
      else
      {
        fixBookCover(listBox.SelectedItem);
        moveDirectory("outlab", listBox.SelectedItem);
      }
    } // end btnOutlab_Click

    public void moveDirectory(string destination, object order)
    {
      string listBoxSelected = Convert.ToString(order);
      // get destination folder from xml
      string OrderDispatcherXml = GlobalClass.pathsXML;
      XDocument RitzOrderDispatcherXml = XDocument.Load(OrderDispatcherXml);
      var dest = RitzOrderDispatcherXml.Descendants(destination + "_folder").ElementAt(0).Value;
      // let user know we're moving the folder
      listBox.Text = listBoxSelected + "   Moving folder...";

      string orderPath = listBoxSelected.Remove(0, 21);   // remove the new order created message
      string orderDirName = orderPath.Split('\\').Last();   // get just the name of the order folder
      string orderDest = Path.Combine(dest, orderDirName.Replace("order", "temp"));   // set temp path for order move

      try
      {
        if (!Directory.Exists(orderDest))    // create the temp path if it doesnt already exist
        {
          Directory.CreateDirectory(orderDest);
        }
        // get the name of all the files in the order folder
        var orderFiles = from fullFileName in Directory.EnumerateFiles(orderPath)
                         select Path.GetFileName(fullFileName);
        foreach (string orderFile in orderFiles)
        {
          string orderDestFull = Path.Combine(orderDest, orderFile);
          if (File.Exists(orderDestFull))    // if we move a file we cant overwrite
          {
            File.Delete(orderDestFull);
          }

          File.Move(Path.Combine(orderPath, orderFile), orderDestFull);
        }

        Directory.Move(orderDest, Path.Combine(dest, orderDirName));    //rename from temp back to order in the new location
        Directory.Delete(orderPath);

        string userMsg = string.Empty;
        switch (destination)
        {
          case "instore":
            userMsg = "Order " + orderDirName.Replace(".order", "") + " was sent to be printed in-store.";
            break;

          case "outlab":
            userMsg = "Order " + orderDirName.Replace(".order", "") + " was sent to be printed at the outlab.";
            break;
        }
        lblSettingsChanged.Text = userMsg;
        logIt(userMsg);
      }
      catch (Exception e)
      {
        lblSettingsChanged.Text = "Error moving order files.\n" + e.ToString();
      }
      listBox.Items.Remove(listBox.SelectedItem);      
    } // end moveDirectory

    private void fixBookCover(object listBoxSelected)
    {
      //if a custom book cover was ordered with a classic photo book change product name of classic book to include w/ custom cover
      string order = Convert.ToString(listBoxSelected);
      string orderPath = order.Remove(0, 21);
      string orderDirName = orderPath.Split('\\').Last();
      string orderXmlFile = orderDirName.Replace("order", "xml");
      string orderXmlPath = orderPath + "\\" + orderXmlFile;
      XDocument orderXml = XDocument.Load(orderXmlPath);
      var qryOrderXml = from orderInfo in orderXml.Descendants("order_item")
                        select orderInfo;
      foreach (XElement orderItem in qryOrderXml)
      {
        if (orderItem.Attribute("product").Value == "7002623")
        {
          string coverPath = orderItem.Element("image").Attribute("path").Value;
          int coverPathId = getPathId(coverPath);
          changeBookDesc(orderXmlPath, coverPathId);
        }
      }
    } //end fixBookCover

    private static int getPathId(string path)
    {
      string[] arrayPath = path.Split('_');
      string pathId = arrayPath[1];
      pathId = pathId.Remove(pathId.Length - 4, 4);
      int numPathId = -1;
      numPathId = Convert.ToInt32(pathId);
      return numPathId;
    }

    private void changeBookDesc(string orderXmlPath, int coverPathId)
    {
      XDocument orderXml = XDocument.Load(orderXmlPath);
      var qryOrderXml = from orderInfo in orderXml.Descendants("order_item")
                        select orderInfo;
      foreach (XElement orderItem in qryOrderXml)
      {
        string bookPath = orderItem.Element("image").Attribute("path").Value;
        int bookPathId = getPathId(bookPath);
        string strPageCount = orderItem.Element("attributes").Attribute("page_count").Value;
        int pageCount = Convert.ToInt32(strPageCount);
        if (coverPathId - bookPathId == pageCount)
        {
          string itemDesc = orderItem.Attribute("description").Value;
          string[] arrayItemDesc = itemDesc.Split(',');
          string newItemDesc = arrayItemDesc[0] + " w/ Custom Cover";
          orderItem.Attribute("description").Value = newItemDesc;
          orderItem.Attribute("name").Value = newItemDesc;
        }       
      }
      orderXml.Save(orderXmlPath);
    } //end changeBookDesc

    private void configureFoldersToolStripMenuItem_Click(object sender, EventArgs e)
    {
      ConfigFolders form = new ConfigFolders();
      form.Show();
    } // end configureFolderToolStripMenuItem_Click

    private void exitToolStripMenuItem_Click(object sender, EventArgs e)
    {
      Application.Exit();
    } // end exitToolStripMenuItem_Click

    private void btnDetails_Click(object sender, EventArgs e)
    {
      if (listBox.SelectedItem == null)
      {
        MessageBox.Show("Please select an order to display.");
      }
      else
      {
        string details = getOrderDetails(listBox.SelectedItem);
        MessageBox.Show(details);
      }
    } // end btnDetails_Click

    public static string getOrderDetails(object order)
    {
      string listBoxSelected = Convert.ToString(order);
      string orderPath = listBoxSelected.Remove(0, 21);
      string orderDirName = orderPath.Split('\\').Last();
      string orderXmlFile = orderDirName.Replace("order", "xml");
      string orderXmlPath = orderPath + "\\" + orderXmlFile;
      XDocument orderXml = XDocument.Load(orderXmlPath);

      var qryTimeStamp = orderXml.Element("apm_order").Attribute("timestamp").Value;
      string timeStamp = qryTimeStamp.Remove(16, 9);
      timeStamp = timeStamp.Replace("T", " ");

      string fname = string.Empty;
      string lname = string.Empty;
      string phone = string.Empty;
      string email = string.Empty;
      var qryCustomerInfo = from customerInfo in orderXml.Descendants("shipment")
                            select customerInfo;
      foreach (XElement customer in qryCustomerInfo)
      {
        fname = customer.Attribute("fname").Value;
        lname = customer.Attribute("lname").Value;
        phone = customer.Attribute("phone").Value;
        email = customer.Attribute("email").Value;
      }

      string details = "Order placed " + timeStamp + "\n";
      details += "Customer Name:  " + fname + " " + lname + "\n";
      details += "Phone: " + phone + "\n";
      details += "Email: " + email + "\n\n";
      details += "Order Info:\n";

      string productName = string.Empty;
      string quantity = string.Empty;
      var qryOrderInfo = from orderInfo in orderXml.Descendants("order_item")
                         select orderInfo;
      foreach (XElement orderItem in qryOrderInfo)
      {
        productName = orderItem.Attribute("name").Value;
        quantity = orderItem.Attribute("quantity").Value;
        details += "qty " + quantity + " -- " + productName + "\n";
      }
      return details;
    } // end getOrderDetails

    public void logIt(string userMsg)
    {
      DateTime dateToday = DateTime.Now;
      string timeStamp = dateToday.ToString();
      //string logPath = @"C:\Program Files\ITS\Ritz_Order_Manager\Logs\OrderManagerLog.txt";
      string logPath = GlobalClass.logFile;

      File.AppendAllText(logPath, timeStamp + " -- " + userMsg + Environment.NewLine);
    } // end logIt

    private void clearOldLogs()
    {
      DateTime tenDaysAgo = DateTime.Today.AddDays(-10);
      string dateToDelete = tenDaysAgo.ToString();
      //string logPath = @"C:\Program Files\ITS\Ritz_Order_Manager\Logs\OrderManagerLog.txt";
      string logPath = GlobalClass.logFile;

      if (File.Exists(logPath))
      {
        var logEntries = File.ReadLines(logPath).ToList();
        for(int l = logEntries.Count - 1; l > -1; l--)
        {
          string[] logEntry = logEntries[l].Split(new Char[]{'-'});
          DateTime logDate = Convert.ToDateTime(logEntry[0]);
          if(DateTime.Compare(logDate, tenDaysAgo) < 0)   // < 0 means it's older than 10 days
          {
            logEntries.RemoveAt(l);
          }
        }
        File.WriteAllLines(logPath, logEntries);
      }
    } // end clearOldLogs

    private void btnHistory_Click(object sender, EventArgs e)
    {
      if(txtBoxHistory.Text == "")
      {
        MessageBox.Show("Please enter an order number.");
      }
      else
      {
        string orderNumber = txtBoxHistory.Text;
        //string logPath = @"C:\Program Files\ITS\Ritz_Order_Manager\Logs\OrderManagerLog.txt";
        string logPath = GlobalClass.logFile;
        string orderHistory = string.Empty;

        if (File.Exists(logPath))
        {
          var logEntries = File.ReadLines(logPath).ToList();
          foreach (string logEntry in logEntries)
          {
            if(logEntry.Contains(orderNumber))
            {
              orderHistory += logEntry + Environment.NewLine;
            }
          }
        }
        if (orderHistory == "")
        {
          orderHistory = "Order not found.";
        }
        MessageBox.Show(orderHistory);
        txtBoxHistory.Text = "";
      }
    } // end btnHistory_Click

  }
}
