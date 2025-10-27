using System;


namespace GCMS_Business
{
    //this class is static to prevent any object creation form this class
    //all of the methods will be static inside this class

    /// <summary>
    /// this class for holding User session information
    /// </summary>
    public static class clsUserSession
    {
        public static clsUsers CurrentUser { get; set; }
    }
}
