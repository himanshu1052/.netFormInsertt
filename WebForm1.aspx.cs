using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BOL;
using BLL;
using DAL;
using System.IO; 

namespace UserRegistrationApp
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        

        protected void Page_Load(object sender, EventArgs e)
        {
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;


        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    string fileName = string.Empty;
                    string folderPath = Server.MapPath("~/Uploads/");

                    if (fuPhoto.HasFile)
                    {
                        if (!Directory.Exists(folderPath))
                            Directory.CreateDirectory(folderPath);

                        fileName = Guid.NewGuid().ToString() + Path.GetExtension(fuPhoto.FileName);
                        string filePath = Path.Combine(folderPath, fileName);
                        fuPhoto.SaveAs(filePath);
                    }

                    BOL.User user = new BOL.User
                    {
                        FirstName = txtName.Text.Trim(),
                        LastName = txtLast.Text.Trim(),
                        MobileNo = txtMobile.Text.Trim(),
                        AdharNo = txtAadhar.Text.Trim(),
                        DOB = DateTime.Parse(txtDOB.Text.Trim()),
                        AdressLine1 = txtAddress1.Text.Trim(),
                        AdressLine2 = txtAddress2.Text.Trim(),
                        PinCode = txtPincode.Text.Trim(),
                        District = hdnDistrict.Value.Trim(),
                        State = hdnState.Value.Trim(),
                        Country = hdnCountry.Value.Trim(),
                        City = hdnCity.Value.Trim(),
                        Area = hdnArea.Value.Trim(),
                        Qualification = ddlQualification.SelectedValue,
                        PhotoPath = fileName
                    };

                    UserBLL bll = new UserBLL();
                    bll.AddUser(user);

                    lblMessage.Text = "User Registered Successfully!";
                    lblMessage.CssClass = "success";
                }
                catch (Exception ex)
                {
                    lblMessage.Text = "Error: " + ex.Message;
                    lblMessage.CssClass = "error";
                }
            }
        }

    }
}