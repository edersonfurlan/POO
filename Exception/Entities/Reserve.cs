using System;
using Reservation.Entities.Exceptions;

namespace Reservation.Entities
{
    class Reserve
    {
        public int RoomNumber { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }

        public Reserve()
        {
        }

        public Reserve(int roomNumber, DateTime checkIn, DateTime checkOut)
        {
            if (checkOut <= checkIn)
                throw new DomainException("Reservation date for update must be future dates");

            RoomNumber = roomNumber;
            CheckIn = checkIn;
            CheckOut = checkOut;
        }

        public int Duration()
        {
            TimeSpan duration = CheckOut.Subtract(CheckIn);
            return (int)duration.TotalDays;
        }

        public void UpdateDates(DateTime checkIn, DateTime checkOut)
        {
            DateTime now = DateTime.Now;

            if (checkIn < now || checkOut < now)
                throw new DomainException("Reservation date for update must be future dates");

            if (checkOut <= checkIn)
                throw new DomainException("Reservation date for update must be future dates");

            CheckIn = checkIn;
            CheckOut = checkOut;
        }

        public override string ToString()
        {
            return "Room"
                   + RoomNumber
                   + ", check-in: "
                   + CheckIn.ToString("dd/MM/yyyy")
                   + ", check-out: "
                   + CheckOut.ToString("dd/MM/yyyy")
                   + ", "
                   + Duration()
                   + " nights";
        }
    }
}
