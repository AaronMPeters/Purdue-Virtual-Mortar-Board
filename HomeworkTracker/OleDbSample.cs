using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Xml.Serialization;
using System.Windows.Forms;


namespace HomeworkTracker
{
    // OleDbSample.cs
    public class OleDbSample
    {
        public static void go()
        {
            // Set Access connection and select strings.
            // The path to BugTypes.MDB must be changed if you build the sample
            // from the command line:
#if USINGPROJECTSYSTEM
		string strAccessConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=..\\..\\BugTypes.MDB";
#else
            string strAccessConn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\Aaron\\Documents" +
                    "\\Databases\\PurdueGPA.accdb";
#endif
            string strAccessSelect = "SELECT * FROM tblHW";

            // Create the dataset and add the Categories table to it:
            DataSet myDataSet = new DataSet();
            OleDbConnection myAccessConn = null;
            try
            {
                myAccessConn = new OleDbConnection(strAccessConn);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: Failed to create a database connection. \n{0}", ex.Message);
                return;
            }

            try
            {

                OleDbCommand myAccessCommand = new OleDbCommand(strAccessSelect, myAccessConn);
                OleDbDataAdapter myDataAdapter = new OleDbDataAdapter(myAccessCommand);

                myAccessConn.Open();
                myDataAdapter.Fill(myDataSet, "tblHW");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: Failed to retrieve the required data from the DataBase.\n{0}", ex.Message);
                return;
            }
            finally
            {
                myAccessConn.Close();
            }

            // A dataset can contain multiple tables, so let's get them all
            // into an array:
            DataTableCollection dta = myDataSet.Tables;
            foreach (DataTable dt in dta)
            {
                MessageBox.Show("Found data table {0}", dt.TableName);
            }

            // The next two lines show two different ways you can get the
            // count of tables in a dataset:
            MessageBox.Show(myDataSet.Tables.Count + " tables in data set");
            MessageBox.Show(dta.Count + " tables in data set");
            // The next several lines show how to get information on a
            // specific table by name from the dataset:
            MessageBox.Show(myDataSet.Tables["tblHW"].Rows.Count + " rows in tblHW table");
            // The column info is automatically fetched from the database, so
            // we can read it here:
            MessageBox.Show(myDataSet.Tables["tblHW"].Columns.Count + " columns in tblHW table");
            DataColumnCollection drc = myDataSet.Tables["tblHW"].Columns;
            int i = 0;
            foreach (DataColumn dc in drc)
            {
                // Print the column subscript, then the column's name and its
                // data type:
                MessageBox.Show("Column name " + dc.ColumnName + " is " + i + " of type " + dc.DataType);
            }
            DataRowCollection dra = myDataSet.Tables["tblHW"].Rows;
            foreach (DataRow dr in dra)
            {
                // Print the CategoryID as a subscript, then the CategoryName:
                MessageBox.Show("CategoryName " + dr[0] + " is " + dr[1]);
            }

        }
    }
}
