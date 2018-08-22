using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsTrayApplication
{
    class Program
    {
        //Add Notify Icon and Task 
        static NotifyIcon notifyIcon;
        static Task taskOperation;
        static ContextMenu contextMenu;
        static void Main(string[] args)
        {
            //Creating Context Menu we have added one option in the menu here "Close"
            contextMenu = new ContextMenu();
            MenuItem menuItem = new MenuItem();
            menuItem.Click += MenuItem_Click;
            menuItem.Text = "Close";
            contextMenu.MenuItems.Add(menuItem);


            //Creating the Tray Icon, we can refer the custum icons also here
            notifyIcon = new NotifyIcon();
            notifyIcon.Text = "Windows Tray App is running...";
            //We can have our custum icon files in place of SystemIcons.Application , just provide the filepath 
            notifyIcon.Icon = new Icon(SystemIcons.Application, 40, 40);
            notifyIcon.Visible = true;

            //create and start the seperate task to show the ballon tip in the tray icon
            taskOperation = new Task(() => TaskOperation());
            taskOperation.Start();

            Console.WriteLine("Application Started...");
            //Run the Application in continuous mode
            Application.Run();

        }

        /// <summary>
        /// Seperate thread to handle the Menu Items and Ballon tip popup
        /// </summary>
        private static void TaskOperation()
        {
            notifyIcon.ContextMenu = contextMenu;
            notifyIcon.Visible = true;
            notifyIcon.ShowBalloonTip(500, "Windows App", "Windows Tray App is Running...", ToolTipIcon.Info);
        }

        /// <summary>
        /// Events to be trigerred when the MenuItem is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void MenuItem_Click(object sender, EventArgs e)
        {
            //DO SOMETHING
            //Exiting the Application
            Application.Exit();
        }
    }
}
