using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GCMS_Business;
using GCMS_Infrastructure;

namespace GCMS.People
{
    public partial class frmAddNewPerson : Form
    {
        public frmAddNewPerson()
        {
            InitializeComponent();
        }

        //to close the screen
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        //Validation for each Text Box
        private byte _ValidateFirstName()
        {
            byte ErrorCounter = 0;



            //Validating FirstName

            if (string.IsNullOrWhiteSpace(tbFirstName.Text))
            {
                errorProvider1.SetError(tbFirstName, "First Name is required.");
                //adding on error to the co
                ErrorCounter++;
            }
            else if (clsValidationHelper.ContainsNumber(tbFirstName.Text))
            {
                errorProvider1.SetError(tbFirstName, "First Name can't contain a number.");
                //adding on error to the Counter
                ErrorCounter++;
            }
            else if (!clsValidationHelper.IsValidCharacterRange(15, tbFirstName.Text))
            {
                errorProvider1.SetError(tbFirstName, "First Name can't be more than 15 character.");
                //adding on error to the Counter
                ErrorCounter++;
            }
            else
                errorProvider1.SetError(tbFirstName, string.Empty);


            return ErrorCounter;
        }
        private byte _ValidateSecondName()
        {
            byte ErrorCounter = 0;

            //Validating Second Name

            if (string.IsNullOrWhiteSpace(tbSecondName.Text))
            {
                errorProvider1.SetError(tbSecondName, "Second Name is required.");
                //adding on error to the Counter
                ErrorCounter++;
            }
            else if (clsValidationHelper.ContainsNumber(tbSecondName.Text))
            {
                errorProvider1.SetError(tbSecondName, "Second Name can't contain a number.");
                //adding on error to the Counter
                ErrorCounter++;
            }
            else if (!clsValidationHelper.IsValidCharacterRange(15, tbSecondName.Text))
            {
                errorProvider1.SetError(tbSecondName, "Second Name can't be more than 15 character.");
                //adding on error to the Counter
                ErrorCounter++;
            }
            else
                errorProvider1.SetError(tbSecondName, string.Empty);

            return ErrorCounter;

        }
        private byte _ValidateThirdName()
        {
            byte ErrorCounter = 0;

            //Validating Third Name
            if (string.IsNullOrWhiteSpace(tbThirdName.Text))
            {
                errorProvider1.SetError(tbThirdName, string.Empty);
            }
            else if (clsValidationHelper.ContainsNumber(tbThirdName.Text))
            {
                errorProvider1.SetError(tbThirdName, "Third Name can't contain a number.");
                //adding on error to the Counter
                ErrorCounter++;
            }
            else if (!clsValidationHelper.IsValidCharacterRange(15, tbThirdName.Text))
            {
                errorProvider1.SetError(tbThirdName, "Third Name can't be more than 15 character.");
                //adding on error to the Counter
                ErrorCounter++;
            }
            else
                errorProvider1.SetError(tbThirdName, string.Empty);


            return ErrorCounter;

        }
        private byte _ValidateLastName()
        {
            byte ErrorCounter = 0;

            //Validating Last Name

            if (string.IsNullOrWhiteSpace(tbLastName.Text))
            {
                errorProvider1.SetError(tbLastName, "Last Name is required.");
                //adding on error to the Counter
                ErrorCounter++;
            }
            else if (clsValidationHelper.ContainsNumber(tbLastName.Text))
            {
                errorProvider1.SetError(tbLastName, "Last Name can't contain a number.");
                //adding on error to the Counter
                ErrorCounter++;
            }
            else if (!@clsValidationHelper.IsValidCharacterRange(15, tbLastName.Text))
            {
                errorProvider1.SetError(tbLastName, "Last Name can't be more than 15 character.");
                //adding on error to the Counter
                ErrorCounter++;
            }
            else
                errorProvider1.SetError(tbLastName, string.Empty);

            return ErrorCounter;

        }
        private byte _ValidatePhoneNumber()
        {
            byte ErrorCounter = 0;


            //Validating Phone number

            if (string.IsNullOrWhiteSpace(tbPhone.Text))
            {
                errorProvider1.SetError(tbPhone, "Phone number is required.");
                //adding on error to the Counter
                ErrorCounter++;
            }
            else if (clsValidationHelper.ContainsLetter(tbPhone.Text))
            {
                errorProvider1.SetError(tbPhone, "Phone number can't contain a letter.");
                //adding on error to the Counter
                ErrorCounter++;
            }
            else if (!clsValidationHelper.IsValidCharacterRange(15, tbPhone.Text))
            {
                errorProvider1.SetError(tbPhone, "Phone number can't be more than 15 character.");
                //adding on error to the Counter
                ErrorCounter++;
            }
            else
                errorProvider1.SetError(tbPhone, string.Empty);


            return ErrorCounter;
        }
        private byte _ValidateEmail()
        {
            byte ErrorCounter = 0;


            //Validating Email

            if (string.IsNullOrWhiteSpace(tbEmail.Text))
            {
                errorProvider1.SetError(tbEmail, "Email is required.");
                //adding on error to the Counter
                ErrorCounter++;
            }
            else if (!clsValidationHelper.IsEmailValid(tbEmail.Text))
            {
                errorProvider1.SetError(tbEmail, "Email Format is not valid");
                //adding on error to the Counter
                ErrorCounter++;
            }
            else if (!clsValidationHelper.IsValidCharacterRange(50, tbEmail.Text))
            {
                errorProvider1.SetError(tbEmail, "Eamil can't be more than 50 character.");
                //adding on error to the Counter
                ErrorCounter++;
            }
            else
                errorProvider1.SetError(tbEmail, string.Empty);

            return ErrorCounter;
        }



        // Validation for the entire input textboxes
        private bool _IsInputValid()
        {
            byte ErrorCounter = 0;

            ErrorCounter += _ValidateFirstName();
            ErrorCounter += _ValidateSecondName();
            ErrorCounter += _ValidateThirdName();
            ErrorCounter += _ValidateLastName();
            ErrorCounter += _ValidatePhoneNumber();
            ErrorCounter += _ValidateEmail();

            //if the Error counter is 0 that means that all of the information is valid
            //otherwise there is a wrong info that must be edited

            return (ErrorCounter == 0);
        }

        //Private method to add new person
        private bool _AddNewPerson()
        {
            bool IsAdded = false;


            clsPeople Person = new clsPeople();

            Person.FirstName =tbFirstName.Text;
            Person.SecondName =tbSecondName.Text;
            Person.ThirdName =tbThirdName.Text;
            Person.LastName =tbLastName.Text;
            Person.PhoneNumber = tbPhone.Text;
            Person.Email =tbEmail.Text;

            if(Person.Save())
            {
                lblNewPersonID.Text = Person.PersonID.ToString();
                IsAdded = true;
            }

            return IsAdded;
        }


        //this method is to handl Add new person button click 
        private void btnAddNewPerson_Click(object sender, EventArgs e)
        {
            if(_IsInputValid())
            {
               if(_AddNewPerson())
                {
                    tbFirstName.Enabled = false;
                    tbSecondName.Enabled = false;
                    tbThirdName.Enabled = false;
                    tbLastName.Enabled = false;
                    tbPhone.Enabled = false;
                    tbEmail.Enabled = false;
                    btnAddNewPerson.Enabled = false;

                    MessageBox.Show("New person has been added.", "Added", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
               else
                {
                    MessageBox.Show("Coudn't Add New Person.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;

                }
            }
            else
            {
                MessageBox.Show("Invalid Person Data.\nPlease check the errors...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        
    }
}
