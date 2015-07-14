using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ImageUploader
{
    public class ImageUploader: System.Web.UI.Page
    {

        protected global::System.Web.UI.HtmlControls.HtmlGenericControl divContent;

        protected void Page_Load(object sender, EventArgs e)
        {
            HttpFileCollection uploadFiles = Request.Files;

            string summary = "<p>number of files to upload:" + (uploadFiles.Count - 1) + "</p>";

            // Build HTML listing the files received.
            summary += "<p>Files Uploaded:</p><ol>";
            
            // Loop over the uploaded files and save to disk.
            int i;
            for (i = 0; i < uploadFiles.Count; i++)
            {
                HttpPostedFile postedFile = uploadFiles[i];

                string pfilename = Path.GetFileName(postedFile.FileName);
                string pext = Path.GetExtension(pfilename);
                pext = pext.ToLower();

                List<string> validExtensions = new List<string> { ".jpg", ".jpeg", ".png", ".tiff", ".tif", ".gif" };



                if (pfilename.Length > 0 && validExtensions.Contains(pext))
                {
                    // Access the uploaded file's content in-memory:
                    //System.IO.Stream inStream = postedFile.InputStream;
                    //byte[] fileData = new byte[postedFile.ContentLength];
                    //inStream.Read(fileData, 0, postedFile.ContentLength);

                    // Save the posted file in our "data" virtual directory.
                    //postedFile.SaveAs(Server.MapPath("images") + "\\" + postedFile.FileName);
                    postedFile.SaveAs(Server.MapPath("~/images/") + pfilename);
                
                    //string fileName = postedFile.FileName;
                    //fileName = Server.MapPath("~/images/" + fileName);
                    //postedFile.SaveAs(fileName);

                    // Also, get the file size and filename (as specified in
                    // the HTML form) for each file:
                    summary += "<li><b>" + pfilename + ": " + pext + " "
                        + postedFile.ContentLength.ToString() + " bytes</b></li>";
                }
                else
                {
                    summary += "<li><i>" + pfilename + ": " + pext + " "
                        + " Extension not supported - not uploaded</i>";
                }

            }
            summary += "</ol>";

            // If there are any form variables, get them here:
            //summary += "<p>Form Variables:</p><ol>";

            //Load Form variables into NameValueCollection variable.
            //NameValueCollection coll = Request.Form;

            // Get names of all forms into a string array.
            //String[] arr1 = coll.AllKeys;
            //for (i = 0; i < arr1.Length; i++)
            //{
            //    summary += "<li>" + arr1[i] + "</li>";
            //}
            //summary += "</ol>";

            divContent.InnerHtml = summary;


        }
    }
}