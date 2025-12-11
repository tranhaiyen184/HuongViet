using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HuongViet.Models;

namespace HuongViet.GUI
{
    public partial class FrmUpdateReservation : Form
    {
        private Reservation reservation;

        public FrmUpdateReservation(Reservation reservation)
        {
            InitializeComponent();
            this.reservation = reservation;
            LoadReservationData();
        }

        private void LoadReservationData()
        {
            // This method will be implemented when the form UI is created
            // It should populate all form fields with the reservation data
            if (reservation != null)
            {
                // TODO: Populate form fields with reservation data
                // Example:
                // txtCustomerName.Text = reservation.CustomerName;
                // txtContactPhone.Text = reservation.ContactPhone;
                // dtpReservationDate.Value = reservation.ReservationDate;
                // etc.
            }
        }
    }
}
