using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using System.IO;

namespace OrderDispatcher
{
  public partial class ConfigFolders : Form
  {
    public ConfigFolders()
    {
      InitializeComponent();
    }

    private void ConfigFolders_Load_1(object sender, EventArgs e)
    {
      showWatched();
    }

    public void showWatched()
    {
      lBoxWatched.Items.Clear();
      string OrderDispatcherXml = GlobalClass.pathsXML;
      XDocument RitzOrderDispatcherXml = XDocument.Load(OrderDispatcherXml);
      var qryHotFolders = from f in RitzOrderDispatcherXml.Elements("folder_paths").Elements("incoming_orders").Elements("location")
                          select f;
      foreach (XElement location in qryHotFolders)
      {
        string availability = "           ... Currently Unavailable.";
        if (Directory.Exists(location.Value))
        {
          availability = "           ... Available.";
        }
        lBoxWatched.Items.Add(location.Value + availability);
      }
    } // end showWatched

    private void btnAdd_Click(object sender, EventArgs e)
    {
      string newWatchItem = string.Empty;
      FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
      folderBrowserDialog.ShowNewFolderButton = false;
      folderBrowserDialog.Description = "Select a folder to monitor.";
      DialogResult dialogResult = folderBrowserDialog.ShowDialog();

      if (dialogResult == DialogResult.OK)
      {
        newWatchItem = folderBrowserDialog.SelectedPath;
        Environment.SpecialFolder root = folderBrowserDialog.RootFolder;

        saveWatchItem(newWatchItem);
      }
    } // end btnAdd_Click

    public void saveWatchItem(string newWatchItem)
    {
      string OrderDispatcherXml = GlobalClass.pathsXML;
      XDocument RitzOrderDispatcherXml = XDocument.Load(OrderDispatcherXml);
      var qryHotFolders = from f in RitzOrderDispatcherXml.Elements("folder_paths").Elements("incoming_orders")
                          select f;
      foreach (XElement location in qryHotFolders)
      {
        location.Add(new XElement("location", newWatchItem));
      }
      RitzOrderDispatcherXml.Save(OrderDispatcherXml);
      showWatched();
      lblMessage.Text = "The folder has been added to the watch list.  Please restart the application to apply the changes.";

      Form1 fc = (Form1)Application.OpenForms["Form1"];
      fc.lblSettingsChanged.Text = "Settings have been updated.  Please restart the application to apply the new settings.";
      RitzOrderDispatcherXml.Save(OrderDispatcherXml);
    } //end saveWatchItem

    private void btnRemove_Click(object sender, EventArgs e)
    {
      if (lBoxWatched.SelectedItem == null)
      {
        MessageBox.Show("Please select a folder to remove.");
      }
      else
      {
        string selectedItem = Convert.ToString(lBoxWatched.SelectedItem);
        string[] selectedItemSplit = selectedItem.Split('.');
        string removeItem = selectedItemSplit[0].Trim();
        string OrderDispatcherXml = GlobalClass.pathsXML;
        XDocument RitzOrderDispatcherXml = XDocument.Load(OrderDispatcherXml);
        var qryRemoveItem = from f in RitzOrderDispatcherXml.Elements("folder_paths").Elements("incoming_orders").Elements("location")
                            where (string)f.Value == removeItem
                            select f;
        var folderItem = qryRemoveItem.ToList();
        foreach (XElement folder in folderItem)
        {
          folder.Remove();
        }
        lBoxWatched.Items.Remove(lBoxWatched.SelectedItem);
        RitzOrderDispatcherXml.Save(OrderDispatcherXml);
        lblMessage.Text = "The folder has been removed from the watch list.  Please restart the application to apply the changes.";

        Form1 fc = (Form1)Application.OpenForms["Form1"];
        fc.lblSettingsChanged.Text = "Settings have been updated.  Please restart the application to apply the new settings.";
        RitzOrderDispatcherXml.Save(OrderDispatcherXml);
      }
    } // end btnRemove_Click

    private void btnOK_Click(object sender, EventArgs e)
    {
      this.Close();
    } // end btnOK_Click
  }
}
