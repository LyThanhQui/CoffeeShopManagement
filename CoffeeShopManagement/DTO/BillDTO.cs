using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoffeeShopManagement.DTO
{
    public class BillDTO
    {
        #region field
        //Add ? to value can have null
        private DateTime? dateCheckIn;
        private DateTime? dateCheckOut;
        private int iD;
        private int status;
        private int discount;
      
        #endregion

        #region properties
        public int ID
        {
            get { return iD; }
            set { iD = value; }
        }

        public DateTime? DateCheckOut
        {
            get { return dateCheckOut; }
            set { dateCheckOut = value; }
        }
        public DateTime? DateCheckIn
        {
            get { return dateCheckIn; }
            set { dateCheckIn = value; }
        }
        public int Status
        {
            get { return status; }
            set { status = value; }
        }

        public int Discount { get => discount; set => discount = value; }
    
        #endregion

        #region contructors
        public BillDTO(int id, DateTime? datecheckin, DateTime? datecheckout, int status, int discount = 0)
        {
            this.ID = id;
            this.DateCheckIn = datecheckin;
            this.DateCheckOut = datecheckout;
            this.Status = status;
       
            this.Discount = discount;
        }

        public BillDTO(DataRow row)
        {
            this.ID = (int)row["id"];
            this.DateCheckIn = (DateTime?)row["datecheckin"];

            var dateCheckOutTemp = row["datecheckout"];
            if (dateCheckOutTemp.ToString() != "")
                this.DateCheckOut = (DateTime?)dateCheckOutTemp;

            this.Status = (int)row["status"];
          

            if (row["discount"].ToString() != "")
                this.Discount = (int)row["discount"];


        }
        #endregion
    }
}