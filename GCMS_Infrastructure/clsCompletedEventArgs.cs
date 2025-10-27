using System;


namespace GCMS_Infrastructure
{

    /// <summary>
    /// This class is shared for all the controls that will use the completed event arguments
    /// </summary>
    public class clsCompletedEventArgs : EventArgs
    {
        public decimal TotalPayment { get; set; }
        public int Seconds { get; set; }


        public clsCompletedEventArgs(decimal TotalPayment, int Seconds)
        {
            this.TotalPayment = TotalPayment;
            this.Seconds = Seconds;
        }

    }
}
