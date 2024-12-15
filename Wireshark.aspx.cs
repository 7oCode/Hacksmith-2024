using LanguageExt.TypeClasses;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HackSmith
{
    public partial class Wireshark : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAnalyze_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile)
            {
                try
                {
                    // Validate the file type
                    if (Path.GetExtension(FileUpload1.FileName).ToLower() != ".csv")
                    {
                        StatusLabel.Text = "Please upload a valid CSV file.";
                        return;
                    }

                    // Save the file temporarily on the server
                    string folderPath = Server.MapPath("~/Uploads/");
                    if (!Directory.Exists(folderPath))
                    {
                        Directory.CreateDirectory(folderPath); // Create the folder if it doesn't exist
                    }
                    string filePath = folderPath + Path.GetFileName(FileUpload1.FileName);
                    FileUpload1.SaveAs(filePath); // Save the uploaded file

                    // Read and process the CSV file into a DataTable
                    
                    LogProcessor logProcessor = new LogProcessor();
                    int Scount = logProcessor.CountSynFloodInstances(filePath);
                    
                    if (Scount > 0) {
                        //lblMessage.Visible = true;
                        IsSyn.Visible = true;
                        IsSyn.Text = $"Possible SYN Flood detected! Count: {Scount}.";
                                      }
                    else
                    {
                        StatusLabel.Text = "No SYN Flood detected.";
                    }
/*                    DataTable csvData = ReadCsvFile(filePath);
                    // Bind the DataTable to the GridView to display it as a table
                    GridView1.DataSource = csvData;
                    GridView1.DataBind();*/

                    StatusLabel.ForeColor = System.Drawing.Color.Green;
                    StatusLabel.Text = "File uploaded and processed successfully!";
                }
                catch (Exception ex)
                {
                    StatusLabel.Text = "Error: " + ex.Message;
                }
            }
            else
            {
                StatusLabel.Text = "Please select a file to upload.";
            }
        }

        public class LogProcessor
        {
            public string[] who;
            public int[] num;

            public int CountSynFloodInstances(string filePath)
            {
                int count = 0;
                string keyword = ">  80";
                try
                {
                    using (StreamReader sr = new StreamReader(filePath))
                    {
                        // Skip the header line (if it's a CSV)
                        sr.ReadLine();

                        // Loop through the remaining lines in the log file
                        while (!sr.EndOfStream)
                        {
                            string line = sr.ReadLine();
                            string[] columns = line.Split(',');

                            // Assuming the "Activity" is in the 4th column (index 3)
                            string activity = columns[8];
                            string source = columns[2];
                            var n = 0;
                            // Check if the activity contains the "SYN Flood" keyword (case-insensitive)
                            if (activity.Contains(keyword))
                            {
                                count++;

                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error processing log file: " + ex.Message);
                }

                return count;
            }
        }

        private DataTable ReadCsvFile(string filePath)
        {
            DataTable dt = new DataTable();


            try
            {
                using (StreamReader sr = new StreamReader(filePath))
                {
                    // Read the first line to get the headers
                    string[] headers = sr.ReadLine().Split(',');

                    // Create columns in the DataTable based on headers
                    foreach (string header in headers)
                    {
                        dt.Columns.Add(header.Trim());
                    }

                    // Read the data rows and populate the DataTable
                    while (!sr.EndOfStream)
                    {
                        string[] rows = sr.ReadLine().Split(',');

                        // Check if the number of columns in the row matches the header
                        if (rows.Length == dt.Columns.Count)
                        {
                            // If it matches, add the row
                            dt.Rows.Add(rows);
                        }
                        else
                        {
                            // Handle the mismatch by either skipping the row or handling it as needed
                            // Optionally, log the issue or inform the user
                            Console.WriteLine("Skipping row due to mismatch in column count.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error reading the CSV file: " + ex.Message);
            }

            return dt;
        }

    }
    }