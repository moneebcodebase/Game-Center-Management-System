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
using GCMS.Payment;
using GCMS_Infrastructure;

namespace GCMS.User_Control
{
    public partial class ctrlPools : UserControl
    {
        //DataMembers Used in this class

        private clsGames _Game; //private game object
        private DateTime _StartingDateTime;
        private int _Seconds;//To track the elapsed time 


        // this control can't be used unless there is a game that this control will represent
        public ctrlPools(clsGames Game)
        {
            InitializeComponent();

            //Filling the private Game object
            this._Game = Game;

            //filling the form info
            lblGameName.Text = Game.GameName.ToString();


        }



        // the bag which will hold the event data is in the Infrastructure layer (clsCompletedEventArgs)


        //Defining the Event
        public event EventHandler<clsCompletedEventArgs> OnTableCompleted;
        //the event method that will be raised after the table game is completed
        public void RaiseOnTableCompleted(decimal TotalPayment,int Seconds)
        {
            RaiseOnTableCompleted(new clsCompletedEventArgs(TotalPayment, Seconds));
        }
        protected void RaiseOnTableCompleted(clsCompletedEventArgs e )
        {
            OnTableCompleted?.Invoke( this, e );
        }





        //this function is used to reset the game
        private void ResetGame()
        {
            Timer1.Stop();
            lblTimer.Text = "00:00:00";
            btnStartStop.Text = "Start";
            _Seconds = 0;
        }

        private decimal CalculatesTheAmount()
        {
            //Get the total payment amout
            decimal Amount = ((decimal)_Seconds / 60m / 60m) * _Game.Rate;

            //handle the payment amount
            if (Amount < 1)
                Amount = 1;
            else
                Amount = (decimal)((int)(Amount * 100)) / 100m;


            return Amount;
        }





        //Buttons Functionality
        private void btnStartStop_Click(object sender, EventArgs e)
        {
            if (btnStartStop.Text == "Start")
            {
                btnStartStop.Text = "Stop";
                _StartingDateTime =DateTime.Now;
                Timer1.Start();
            }
            else
            {
                btnStartStop.Text = "Start";
                Timer1.Stop();
            }
        }
        //this Timer event is used to change the timer string for every tick
        private void Timer1_Tick(object sender, EventArgs e)
        {
            _Seconds++;

            TimeSpan time = TimeSpan.FromSeconds(_Seconds);
            string str = time.ToString(@"hh\:mm\:ss");
            lblTimer.Text = str;
            lblTimer.Refresh();
        }


        //Button end game
        private void btnEnd_Click(object sender, EventArgs e)
        {
            //if game didn't start then return and do not do anything 
            if (lblTimer.Text == "00:00:00")
                return;



            //First Stop the timer
            Timer1.Stop();

            //Get the total payment amout
            decimal Amount = CalculatesTheAmount();


            //call the payment screen to complete the  process
            frmPaymentScreen frm = new frmPaymentScreen(Amount, frmPaymentScreen.enPaymentType.Rentals);
            frm.DataBack += HandlePayment_DataBack;//Subscribe to the event
            frm.ShowDialog();

        }

        //This method will handle the payment (debt or non-debt)
        private void HandlePayment_DataBack(object sender, int PaymentID , int RenterID )
        {
            if(PaymentID != 0) //this means that the payment processed successuly and now we have a payment id
            {
                //Creating a new rental record and Filling it
                clsRentals NewRental = new clsRentals();
                NewRental.GameID = _Game.GameID;
                NewRental.StartDate = _StartingDateTime;
                NewRental.EndDate = _StartingDateTime.AddSeconds(_Seconds);
                NewRental.TotalFees = CalculatesTheAmount();
                NewRental.OnDebt = false;
                NewRental.PaymentID = PaymentID;
                NewRental.CreatedByUserID = clsUserSession.CurrentUser.UserID;


                //Saving the rental Record
                if(NewRental.Save())
                {
                    //Raise the event
                    RaiseOnTableCompleted(NewRental.TotalFees, _Seconds);
                    //Reset the game
                    ResetGame();
                }
                else
                {
                    MessageBox.Show("Rental is not save", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else // this means that the payment will be paid later on debt
            {
                //Creating a new rental record and Filling it
                clsRentals NewRental = new clsRentals();
                NewRental.GameID = _Game.GameID;
                NewRental.StartDate = _StartingDateTime;
                NewRental.EndDate = _StartingDateTime.AddSeconds(_Seconds);
                NewRental.TotalFees = CalculatesTheAmount();
                NewRental.OnDebt = true;
                NewRental.PaymentID = null;
                NewRental.CreatedByUserID = clsUserSession.CurrentUser.UserID;

                //Saving the rental Record
                if (NewRental.Save())
                {
                    //Creating the dept
                    clsDebts NewDebt = new clsDebts();
                    NewDebt.RenterID = RenterID;
                    NewDebt.RentalID=NewRental.RentalID;
                    NewDebt.IsPaid = false;
                    NewDebt.CreatedByUserID=clsUserSession.CurrentUser.UserID;

                    if(NewDebt.Save())
                    {
                        MessageBox.Show("The game payment has been added to debts.", "Note", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //Raise the event with the amout set to zero because the payment is set to be on debt and
                        // the acuall working time
                        RaiseOnTableCompleted(0, _Seconds);
                        ResetGame();

                    }
                    
                }
                else
                {
                    MessageBox.Show("Failed to add the game payment into debts", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;
                }
            }
        }


       
    }
}
