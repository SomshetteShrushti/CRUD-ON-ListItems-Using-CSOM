using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.SharePoint.Client;

namespace CSOMCRUDOperations
{
    public partial class Form1 : System.Windows.Forms.Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (ClientContext ctx = new ClientContext("http://vm-021-tzc02/sites/CSOMSite/"))
            {
                Web web = ctx.Web;
                List list = web.Lists.GetByTitle("Employee");
                ListItemCreationInformation listItemCreationInformation = new ListItemCreationInformation();
                ListItem listItem = list.AddItem(listItemCreationInformation);
                listItem["Title"] = "Shrushti";
                listItem["Amount"] = 23000;
                listItem["ExpiryDate"] = DateTime.Now;
                listItem.Update();
                ctx.ExecuteQuery();

            }
            MessageBox.Show("Item Added Successfully");
        }

        /// <summary>
        /// To delete the from the list using item id
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            using (ClientContext ctx = new ClientContext("http://vm-021-tzc02/sites/CSOMSite/"))
            {
                // THis will delete single item from the list 
                Web web = ctx.Web;
                List list = web.Lists.GetByTitle("Employee");
                ListItem listItem = list.GetItemById(2);
                listItem.DeleteObject();
                ctx.ExecuteQuery();


            }
            MessageBox.Show("Item deleted sucessfully");
        }

        /// <summary>
        /// To update the item from the list. get item by ID or by the camelquery 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            using (ClientContext ctx = new ClientContext("http://vm-021-tzc02/sites/CSOMSite/"))
            {
                Web web = ctx.Web;
                List list = web.Lists.GetByTitle("Employee");
                ListItem listItem = list.GetItemById(3);
                listItem["Title"] = "Somshette";
                listItem["Amount"] = 43000;
                listItem["ExpiryDate"] = DateTime.Now;
                listItem.Update();
                ctx.ExecuteQuery();

            }
            MessageBox.Show("Item Updated Successfully");
        }

        /// <summary>
        /// Method to Get all the Items from the list and display it in th mesagebox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            using (ClientContext ctx = new ClientContext("http://vm-021-tzc02/sites/CSOMSite/"))
            {

                Web web = ctx.Web;
                List list = web.Lists.GetByTitle("Employee");
                CamlQuery query = new CamlQuery();
                query.ViewXml = "<View/>";
                ListItemCollection items = list.GetItems(query);
                ctx.Load(list);
                ctx.Load(items);
                ctx.ExecuteQuery();
                foreach (ListItem item in items)
                {
                    MessageBox.Show(item.Id + " - " + item["Title"]);
                }
                Console.ReadLine();

            }
            MessageBox.Show("Item Fetched  Successfully");
        }
    }
}
