using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TreeViewFile
{
   public partial class Form1 : Form
   {
      public Form1()
      { InitializeComponent(); }
      private static string path = "C:\\_CSharp_Projekte_\\Temp";

      private void Form1_Load(object sender, EventArgs e)
      {
         if (Directory.Exists(path))
            Directory.SetCurrentDirectory(path);
         else
            MessageBox.Show("Verzeichnis nicht gefunden");

         ///fill in
         ///
         string[] folderArray;
         folderArray = Directory.GetDirectories(path);

         treeView1.Nodes.Clear();
         var rootDirectoryInfo = new DirectoryInfo(path);
         
         var stack = new Stack<TreeNode>();                        //working!

         //TreeNode[] arr;             //arr = null        (arr == null) - true
         //arr = new TreeNode[1];      //arr.Length = 1    (arr == null) - false
         //int x = 1;
         //Array.Resize(ref arr, x);                                 //array version^

         var paths = new List<TreeNode>();
         var rootDirectory = new DirectoryInfo(path);
         var node = new TreeNode(rootDirectory.Name) { Tag = rootDirectory };

         //arr[0] = node;                         //arr[0] = rootDirectory
         stack.Push(node);

         while (stack.Count > 0)
         //while (arr.Length > 0)
         //while (paths.Count > 0)
         {
            var currentNode = stack.Pop();
            //var currentNodeArr = arr[0];
            //var currentNodeLst = paths[0];

            var directoryInfo = (DirectoryInfo)currentNode.Tag;
            //var directoryInfoArr = (DirectoryInfo)currentNodeArr.Tag;
            //var directoryInfoLst = (DirectoryInfo)currentNodeLst.Tag;

            //foreach (var directory in directoryInfoLst.GetDirectories())
            //{
            //   var childDirectoryNode = new TreeNode(directory.Name) { Tag = directory };
            //   currentNodeLst.Nodes.Add(childDirectoryNode);
            //   paths.Add(node);
            //}
            //foreach (var file in directoryInfoLst.GetFiles())
            //   currentNodeLst.Nodes.Add(new TreeNode(file.Name));

            foreach (var directory in directoryInfo.GetDirectories())
            {
               var childDirectoryNode = new TreeNode(directory.Name) { Tag = directory };
               currentNode.Nodes.Add(childDirectoryNode);
               stack.Push(childDirectoryNode);
            }
            foreach (var file in directoryInfo.GetFiles())
               currentNode.Nodes.Add(new TreeNode(file.Name));
         }
         treeView1.Nodes.Add(node);

         //treeView1.Nodes.Add(CreateDirectoryNode(rootDirectoryInfo));
      }



      //private static TreeNode CreateDirectoryNode(DirectoryInfo directoryInfo)
      //{
      //   var directoryNode = new TreeNode(directoryInfo.Name);
      //   foreach (var directory in directoryInfo.GetDirectories())
      //      directoryNode.Nodes.Add(CreateDirectoryNode(directory));
      //   foreach (var file in directoryInfo.GetFiles())
      //      directoryNode.Nodes.Add(new TreeNode(file.Name));
      //   return directoryNode;
      //}

      private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
      {
         string[] folderArray;
         folderArray = Directory.GetFiles(path);
         foreach (string aFolder in folderArray)
            listBox1.Items.Add(aFolder);
      }
   }
}
